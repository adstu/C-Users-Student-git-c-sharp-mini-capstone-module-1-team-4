using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public  class VendingMachine
    {
        public int UserInput { get; set; }
        public bool IsiItOn { get; set; }
        public Dictionary<string, string> ItemLocation { get; private set; }
        public decimal AvailableBalance { get; private set; }
        // display inventory // it will be a derived property.



    }
}
