using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BearMountain.Models
{
    public class BasketItem
    {
        [Key]
        public int ID { get; set; }

        public int UserBasketID { get; set; }

        public int ProductID { get; set; }

        public int Quantity { get; set; }

        public bool CheckedOut { get; set; }

        public UserBasket UserBasket { get; set; }

        public Product Product { get; set; }
    }
}
