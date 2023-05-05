using CallTracker_Lib.extensions;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CallTracker_Lib.Enums;

namespace CallTracker_Lib.database.wrappers
{
    public class Address
    {
        private static readonly NLog.Logger Logger = logging.LogManager<Address>.GetLogger();

        /// <summary>
        /// Random hex identifier to mark the seperation between address components.
        /// </summary>
        internal static readonly string SeperatorId = "<0x2A0F1D>";

        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public States State { get; set; } = States.TX;
        public string ZipCode { get; set; } = string.Empty;
        public bool IsMailingAddress { get; set; } = false;

        /// <summary>
        /// Get a value indicating if this is a valid Address object (i.e. no components are empty).
        /// </summary>
        public bool IsValid
        {
            get
            {
                return Street.Equals(string.Empty) || 
                    City.Equals(string.Empty) || 
                    ZipCode.Equals(string.Empty);
            }
        }

        public Address(string street, string city, States state, string zipCode)
        {
            Street = street;
            City = city;
            ZipCode = zipCode;
            State = state;
            if (!IsValid)
                throw new ArgumentException("The address components must not be empty!");
        }

        public Address(string street, string city, string zipCode) : this(street, city, States.TX, zipCode) { }

        /// <summary>
        /// Create a new address object by parsing a string retrieved from the database.
        /// <para>
        /// Valid Formats:
        /// <list type="bullet">
        ///     <item><c>mailing&lt;0x2A0F1D&gt;1234 Poplar Street&lt;0x2A0F1D&gt;Nowhere,TX&lt;0x2A0F1D&gt;77858</c></item>
        ///     <item><c>1234 Poplar Street&lt;0x2A0F1D&gt;Nowhere,TX&lt;0x2A0F1D&gt;77858</c></item>
        /// </list>
        /// </para>
        /// </summary>
        /// <param name="dbContent">The database string, in the correct format.</param>
        /// <exception cref="ArgumentException"></exception>
        public Address(string dbContent)
        {
            if (dbContent.StartsWith($"mailing{SeperatorId}"))
            {
                IsMailingAddress = true;
                dbContent = dbContent.Remove(0, $"mailing{SeperatorId}".Length);
            }

            string[] components = dbContent.Split(SeperatorId, StringSplitOptions.RemoveEmptyEntries);
            if (components.Length != 4) //4 = street, city, state, zip-code
                throw new ArgumentException("Address string did not contain the appropiate number of components (4).");

            Street = components[0];
            City = components[1];
            State = (States)Enum.Parse(typeof(States), components[2]);
            ZipCode = components[3];
            if (!IsValid)
                throw new ArgumentException("The address components must not be empty!");
        }

        public string ToDbString()
        {
            StringBuilder sb = new();
            if (IsMailingAddress)
                sb = sb.Append("mailing").Append(SeperatorId);
            sb = sb.Append(Street)
                .Append(SeperatorId).Append(City).Append(',')
                .Append(SeperatorId).Append(State.ToString())
                .Append(SeperatorId).Append(ZipCode);
            return sb.ToString();
        }

        /// <summary>
        /// Get a human-readable string for displaying. This string is not ready for database storage.
        /// To retrieve a database string, call <see cref="ToDbString"/>.
        /// </summary>
        /// <returns>A string for displaying this address, or an empty string if the address is not valid according to <see cref="IsValid"/></returns>
        public override string ToString()
        {
            if (!IsValid)
                return string.Empty;
            return $"{(IsMailingAddress ? "Mailing: " : "")}{Street}  {City}, {State.ToDescriptionString()} {ZipCode}";
        }
    }
}
