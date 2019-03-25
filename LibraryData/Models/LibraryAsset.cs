using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData.Models
{
    public abstract class LibraryAsset
    {
        public int ID { get; set; }
        public string Titel { get; set; }
        public int Year { get; set; }
        public decimal Cost { get; set; }
        public string ImgUrl { get; set; }
        public int NumberOfCopies { get; set; }
        
        public Status Status { get; set; }
        public virtual LibraryBranch Location { get; set; }



    }
}
