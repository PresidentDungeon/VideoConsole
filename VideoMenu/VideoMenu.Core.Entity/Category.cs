using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenu.Core.Entity
{
   public class Category
    {
        public int id { get; set; }
        public string title { get; set; }

        public override string ToString()
        {
            return title ?? "Unknown category";
        }
    }
}
