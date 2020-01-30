using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Utility;

namespace BookShop.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required, StringLength(40, MinimumLength = 3)]
        [UppercaseFirst]
        [Display(Name = "Tytuł")]
        public string Name { get; set; }
        [Required, StringLength(40, MinimumLength = 3)]
        [UppercaseFirst]
        [Display(Name = "Gatunek")]
        public string Genre { get; set; }
        [Required]
        [Range(1900, 2020)]
        [Display(Name = "Rok wydania")]
        public int Year { get; set; }
    }
}
