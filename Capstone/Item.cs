using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Capstone
{
    public class Item
    {
        public string Type { get; }
        public decimal Price { get; }
        public string Location { get; }
        public string Name { get; }
        public int AvailableProduct { get; set; }

        public Item(string type, decimal price, string location, string name, int availableProduct)
        {
            this.Type = type;
            this.Price = price;
            this.Location = location;
            this.Name = name;
            this.AvailableProduct = availableProduct;
        }

        

    }
}
