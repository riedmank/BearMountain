using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BearMountain.Models.Handlers
{
    public class BearMountainEmailHandler : AuthorizationHandler<EmailRequirement>
    {
        /// <summary>
        /// Makes a decision if authorization is allowed based on a specific requirement.
        /// </summary>
        /// <param name="context">The authorization context.</param>
        /// <param name="requirement">The requirement to evaluate.</param>
        /// <returns>Returns a completed task</returns>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, EmailRequirement requirement)
        {
            if (!context.User.HasClaim(e => e.Type == "Email"))
            {
                return Task.CompletedTask;
            }

            var userEmail = context.User.FindFirst(email => email.Type == "Email").Value;

            if (userEmail.Contains("@bearmountain.com"))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
