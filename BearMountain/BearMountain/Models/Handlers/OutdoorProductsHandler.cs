using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearMountain.Models.Handlers
{
    public class OutdoorProductsHandler : AuthorizationHandler<OutdoorProductsRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OutdoorProductsRequirement requirement)
        {
            

            return Task.CompletedTask;
        }
    }
}
