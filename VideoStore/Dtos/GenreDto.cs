using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoStore.Dtos
{
    public class GenreDto
    {
        public byte Id { get; set; }
        public string Name { get; set; }
    }
}