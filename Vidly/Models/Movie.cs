using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }

        [DisplayName("Number in Stock")]
        public int StockAmount { get; set; }

        [DisplayName("Release Date")]
        public DateTime ReleaseDate { get; set; }


    }
}