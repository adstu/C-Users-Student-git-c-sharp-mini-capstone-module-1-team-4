using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
   public class Candy :Item
    {
        public string Type { get; } = "Candy";
        public string Location { get; }
        public int AvailableProduct { get;  set; }
        public Dictionary<string, decimal> NameAndPrice { get; set; }

    }
}
