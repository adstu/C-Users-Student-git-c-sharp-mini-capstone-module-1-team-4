using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Drinks : Item
    {
        public Drinks(string type, decimal price, string location, string name, int availableProduct) : base(type, price, location, name , availableProduct)
        {
           
        }
    }
}
