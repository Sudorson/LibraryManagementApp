using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models.Catalog
{
    public class AssetIndexListingModel
    {
        public int ID { get; set; }
        public string ImgUrl { get; set; }
        public string Titel { get; set; }
        public string AuthorOrDirector { get; set; }
        public string Type { get; set; }
        public string CallNumber { get; set; }
        public string NumberOfCopies { get; set; }



    }
}
