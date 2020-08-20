using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenu.Models
{
    class Video
    {
        public int id { get; set; }
        public string title { get; set; }
        public DateTime releaseDate { get; set; }
        public string story { get; set; }

        public override string ToString()
        {
            return $"Id: {id} ({releaseDate.ToString("dd/MM/yyyy")}) {title}";
        }
    }
}
