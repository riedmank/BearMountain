using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static BearMountain.Models.ApplicationUser;

namespace BearMountain.Models.Handlers
{
    public class OutdoorProductsHandler : AuthorizationHandler<OutdoorProductsRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OutdoorProductsRequirement requirement)
        {
            if (!context.User.HasClaim(e => e.Type == ClaimTypes.Email))
            {
                return Task.CompletedTask;
            }

            var userEmail = context.User.FindFirst(email => email.Type == ClaimTypes.Email).Value;

            if (userEmail.Contains("bearmountain.com"))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
