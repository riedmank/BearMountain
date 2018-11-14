using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearMountain.Data
{
    public class BearMountainDbContext : DbContext
    {
        public BearMountainDbContext(DbContextOptions<BearMountainDbContext> options) : base(options)
        {

        }


    }
}
