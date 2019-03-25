using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData.Models
{
    public class LibraryBranch
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public DateTime OpenDate { get; set; }

        public virtual IEnumerable<User> Users { get; set; }
        public virtual IEnumerable<LibraryAsset> LibraryAssets { get; set; }


    }
}
