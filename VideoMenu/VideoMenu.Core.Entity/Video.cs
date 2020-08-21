using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenu.Core.Entity
{
    public class Video
    {
        public int id { get; set; }
        public string title { get; set; }
        public DateTime releaseDate { get; set; }
        public string story { get; set; }
        public Category? category { get; set; }

        public override string ToString()
        {
            return (category != null) ? $"Id: {id} ({releaseDate.ToString("dd/MM/yyyy")}) {title}\n - {category.ToString()}" : $"Id: {id} ({releaseDate.ToString("dd/MM/yyyy")}) {title}\n - Unknown category";
        }
    }
}
