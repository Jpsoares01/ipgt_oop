using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipgt_oop.MVVM.Models
{
    internal class Card
    {
        public int id { get; set; }
        public string number { get; set; }
        public decimal balance { get; set; } 

        public Bank bank { get; set; }

    }
}
