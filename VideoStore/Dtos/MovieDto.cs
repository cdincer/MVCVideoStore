using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VideoStore.Models;

namespace VideoStore.Dtos
{
  
        public class MovieDto
        {

            public int Id { get; set; }
         
            public string Name { get; set; }

            [Required]
            public byte GenreId { get; set; }

            
            public int StockAmount { get; set; }
           
            public DateTime ReleaseDate { get; set; }

        }
    }
