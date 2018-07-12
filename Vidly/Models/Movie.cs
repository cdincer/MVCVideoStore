using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name.")]
        public string Name { get; set; }


        public Genre Genre { get; set; }


        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }

        [DisplayName("Number in Stock")]
        [Range(1, 20)]
        public int StockAmount { get; set; }

        [DisplayName("Release Date")]
        public DateTime ReleaseDate { get; set; }


    }
}