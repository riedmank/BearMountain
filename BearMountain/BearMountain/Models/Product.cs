using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BearMountain.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }

        public string SKU { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public ICollection<BasketItem> BasketItems { get; set; }
    }
}
