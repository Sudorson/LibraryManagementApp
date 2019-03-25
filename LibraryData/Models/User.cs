using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData.Models
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual LibraryCard UserNLibraryCardame { get; set; }
        public virtual LibraryBranch LibraryBranch { get; set; }


    }
}
