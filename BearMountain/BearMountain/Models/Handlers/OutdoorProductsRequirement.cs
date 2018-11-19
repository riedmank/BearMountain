using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearMountain.Models.Handlers
{
    public class OutdoorProductsRequirement : IAuthorizationRequirement
    {
        public OutdoorProductsRequirement()
        {

        }
    }
}
