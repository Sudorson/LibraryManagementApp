using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData.Models
{
    public class BranchHours
    {
        public int ID { get; set; }
        public int OpenTime { get; set; }
        public int CloseTime { get; set; }
        public int DayOfWork { get; set; }

        public LibraryBranch Branch { get; set; }




    }
}
