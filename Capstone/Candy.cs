using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
   public class Candy :Item
    {
        public Candy(string type, decimal price, string location, string name, int availableProduct) : base(type, price, location, name, availableProduct)
        {
            
        }

    }
}
