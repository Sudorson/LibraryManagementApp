﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData.Models
{
    public class Chechout
    {
        public int ID { get; set; }
        public DateTime Since { get; set; }
        public DateTime Until { get; set; }

        public LibraryAsset LibraryAsset { get; set; }
        public LibraryCard LibraryCard { get; set; }





    }
}
