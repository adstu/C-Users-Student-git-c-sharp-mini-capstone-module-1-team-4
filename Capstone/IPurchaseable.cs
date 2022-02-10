using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
   public interface IPurchaseable
    {
       

        public Dictionary<string, decimal> NameAndPrice { get; set; }

    }
}
