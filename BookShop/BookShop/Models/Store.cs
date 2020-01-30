using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BookShop.Models
{
    public class Store
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Ilość sztuk")]
        public int Amount { get; set; }
        [Required]
        [Display(Name = "Kwota")]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Tytuł książki")]
        public int BookID { get; set; }
        [Required]
        [Display(Name = "Nazwa wydawcy")]
        public int PublisherID { get; set; }

        [ForeignKey("BookID")]
        public virtual Book Book { get; set; }
        [ForeignKey("PublisherID")]
        public virtual Publisher Publisher { get; set; }

    }
}
