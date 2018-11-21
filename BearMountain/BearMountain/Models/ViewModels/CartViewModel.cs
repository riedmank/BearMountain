using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearMountain.Models.ViewModels
{
    public class CartViewModel
    {
        public int ProductID { get; set; }

        public int UserBasketID { get; set; }

        public string SKU { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public int Quantity { get; set; }

        public bool CheckedOut { get; set; }
    }
}
