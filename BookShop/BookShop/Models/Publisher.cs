using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Utility;

namespace BookShop.Models
{
    public class Publisher
    {
        public int Id { get; set; }

        [Required, StringLength(30, MinimumLength = 2)]
        [UppercaseFirst]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Required, StringLength(40, MinimumLength = 4)]
        [UppercaseFirst]
        [Display(Name = "Ulica")]
        public string Street { get; set; }
        [Required, Range(1, Int32.MaxValue)]
        [Display(Name = "Numer Ulicy")]
        public int StreetNumber { get; set; }
        [Required]
        [Display(Name = "Kod pocztowy")]
        [PostalCode]
        public string PostalCode { get; set; }
        [Required, StringLength(30, MinimumLength = 2)]
        [BookShop.Utility.UppercaseFirst]
        [Display(Name = "Miasto")]
        public string City { get; set; }
        [Required]
        [Display(Name = "Numer komórki")]
        [CelluarNumber]
        public string Phone { get; set; }

    }
}
