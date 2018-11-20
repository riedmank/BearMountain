using BearMountain.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearMountain.Components
{
    public class ItemsInCart : ViewComponent
    {
        private BearMountainDbContext _context;

        public ItemsInCart(BearMountainDbContext context)
        {
            _context = context;
        }
    }
}
