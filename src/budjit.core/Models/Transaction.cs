﻿using System;
using System.Collections.Generic;
using System.Text;

namespace budjit.core.Models
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public String Merchant { get; set; }
        public String Description { get; set; }
        public decimal Alteration { get; set; }
        public decimal Balance { get; set; }
    }
}