﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData.Models
{
    public class LibraryCard
    {
        public int ID { get; set; }
        public decimal Fees { get; set; }
        public DateTime Created { get; set; }

        public IEnumerable<Chechout> Chechouts { get; set; }




    }
}
