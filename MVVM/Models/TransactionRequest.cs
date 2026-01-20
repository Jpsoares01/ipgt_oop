using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipgt_oop.MVVM.Models
{
    internal class TransactionRequest
    {

        public int scrId { get; set; }

        public string dstCardNumber { get; set; }

        public decimal amount { get; set; }

        public int entity { get; set; }
        public string reference { get; set; }

    }
}
