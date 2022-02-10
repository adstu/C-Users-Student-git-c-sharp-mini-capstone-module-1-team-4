using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
   public class Candy :VendingMachine
    {
        public string Type { get; } = "Candy";
        public decimal Price { get; }
        public string Location { get; }
        public string Name { get; }
        public int AvailableProduct { get; private set; }

        
        
    }
}
