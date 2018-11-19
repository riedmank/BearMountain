using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BearMountain.Models
{
    public class ApplicationUser : IdentityUser 
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ProductTypes InterestedProduct { get; set; }

        public enum ProductTypes
        {
            [Display(Name = "Outdoor Gear")]
            outdoors,
            [Display(Name = "Kitchen")]
            kitchen,
            [Display(Name = "School")]
            school,
            [Display(Name = "Automotive")]
            automotive,
            [Display(Name = "Circus")]
            circus
        }

    }
}
