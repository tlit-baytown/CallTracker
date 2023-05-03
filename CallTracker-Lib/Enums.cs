using System.ComponentModel;
using static CallTracker_Lib.utility.Enums;

namespace CallTracker_Lib.utility
{
    /// <summary>
    /// This class represents the various Enums used throughout Survey Manager.
    /// </summary>
    public class Enums
    {
        /// <summary>
        /// Enum reprenting the two boolean operations available for filtering.
        /// </summary>
        public enum BooleanOps
        {
            /// <summary>
            /// Represents the boolean operation AND
            /// </summary>
            AND,
            /// <summary>
            /// Represents the boolean operation OR
            /// </summary>
            OR
        }

        /// <summary>
        /// Enum representing the different SQL Query types that can be built
        /// </summary>
        public enum QType
        {
            /// <summary>
            /// Represents an Insert SQL Query
            /// </summary>
            INSERT,
            /// <summary>
            /// Represents a Select SQL Query
            /// </summary>
            SELECT,
            /// <summary>
            /// Represents an Update SQL Query
            /// </summary>
            UPDATE,
            /// <summary>
            /// Represents a Delete SQL Query
            /// </summary>
            DELETE
        }

        /// <summary>
        /// Enum representing the different errors that can happen when interacting with the database.
        /// </summary>
        public enum DatabaseError
        {
            /// <summary>
            /// No error has occured.
            /// </summary>
            [Description("No database error has occured.")]
            NoError,
            AppOwnerInsert,
            AppOwnerUpdate,
            AppOwnerDelete,
            AppOwnerIncomplete,
            AddressInsert,
            AddressUpdate,
            AddressDelete,
            AddressIncomplete,
            CallLogInsert,
            CallLogUpdate,
            CallLogDelete,
            CallLogIncomplete,
            CompanyInsert,
            CompanyUpdate,
            CompanyDelete,
            CompanyIncomplete,
            CompanyContactNull,
            ContactInsert,
            ContactUpdate,
            ContactDelete,
            ContactIncomplete
        }

        /// <summary>
        /// Enum representing the various validator errors from the <see cref="Validator"/> class.
        /// </summary>
        public enum ValidatorError
        {
            [Description("No error has occured and all validation succeeded.")]
            None
        }

        public enum States
        {
            [Description("Alabama")]
            AL,
            [Description("Alaska")]
            AK,
            [Description("Arkansas")]
            AR,
            [Description("Arizona")]
            AZ,
            [Description("California")]
            CA,
            [Description("Colorado")]
            CO,
            [Description("Connecticut")]
            CT,
            [Description("D.C.")]
            DC,
            [Description("Delaware")]
            DE,
            [Description("Florida")]
            FL,
            [Description("Georgia")]
            GA,
            [Description("Hawaii")]
            HI,
            [Description("Iowa")]
            IA,
            [Description("Idaho")]
            ID,
            [Description("Illinois")]
            IL,
            [Description("Indiana")]
            IN,
            [Description("Kansas")]
            KS,
            [Description("Kentucky")]
            KY,
            [Description("Louisiana")]
            LA,
            [Description("Massachusetts")]
            MA,
            [Description("Maryland")]
            MD,
            [Description("Maine")]
            ME,
            [Description("Michigan")]
            MI,
            [Description("Minnesota")]
            MN,
            [Description("Missouri")]
            MO,
            [Description("Mississippi")]
            MS,
            [Description("Montana")]
            MT,
            [Description("North Carolina")]
            NC,
            [Description("North Dakota")]
            ND,
            [Description("Nebraska")]
            NE,
            [Description("New Hampshire")]
            NH,
            [Description("New Jersey")]
            NJ,
            [Description("New Mexico")]
            NM,
            [Description("Nevada")]
            NV,
            [Description("New York")]
            NY,
            [Description("Oklahoma")]
            OK,
            [Description("Ohio")]
            OH,
            [Description("Oregon")]
            OR,
            [Description("Pennsylvania")]
            PA,
            [Description("Rhode Island")]
            RI,
            [Description("South Carolina")]
            SC,
            [Description("South Dakota")]
            SD,
            [Description("Tennessee")]
            TN,
            [Description("Texas")]
            TX,
            [Description("Utah")]
            UT,
            [Description("Virginia")]
            VA,
            [Description("Vermont")]
            VT,
            [Description("Washington")]
            WA,
            [Description("Wisconsin")]
            WI,
            [Description("West Virginia")]
            WV,
            [Description("Wyoming")]
            WY
        }
    }

    /// <summary>
    /// Extension class used for enums to get a description string.
    /// </summary>
    public static class EnumExtensions
    {
        public static string ToDescriptionString<T>(this T val) where T : Enum
        {
            if (val == null)
                return string.Empty;
            try
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])val
                .GetType()
                .GetField(val.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false);
                return attributes.Length > 0 ? attributes[0].Description : string.Empty;
            } catch (Exception) { return string.Empty; }
        }
    }
}