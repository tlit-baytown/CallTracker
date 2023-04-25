using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallTracker_Lib.interfaces
{
    /// <summary>
    /// All classes that are considered to be database wrappers should implement this interface.
    /// </summary>
    internal interface IDBWrapper
    {
        /// <summary>
        /// Defines the behavior for inserting the object's data into the database.
        /// </summary>
        /// <returns>True: the record was inserted successfully; False: the record could not be inserted.</returns>
        public bool Insert();

        /// <summary>
        /// Defines the behavior for updating the object's data in the database.
        /// </summary>
        /// <returns>True: the record was updated successfully; False: the record could not be updated.</returns>
        public bool Update();

        /// <summary>
        /// Defines the behavior for deleting the object's data in the database.
        /// </summary>
        /// <returns>True: the record was deleted successfully; False: the record could not be deleted.</returns>
        public bool Delete();
    }
}
