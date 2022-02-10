using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Chips: Item
    {
        public string Type { get; } = "Chips";
        public decimal Price { get; }
        public string Location { get; }
        public string Name { get; }
        public int AvailableProduct { get;  set; }
    }
}
