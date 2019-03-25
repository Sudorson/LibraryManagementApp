using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData.Models
{
    public class CheckoutHistry
    {
        public int ID { get; set; }
        public DateTime Checkout { get; set; }
        public DateTime? Checkin { get; set; }

        public LibraryAsset LibraryAsset { get; set; }
        public LibraryCard LibraryCard { get; set; }





    }
}
