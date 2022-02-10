using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
   public interface IPurchaseable
    {
        public string Type { get; }
        public decimal Price { get; }
        public string Location { get; }
        public string Name { get; }
        public int AvailableProduct { get; set; }
    }
}
