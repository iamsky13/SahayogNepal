using Microsoft.AspNetCore.Identity;
using SahayogNepal.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahayogNepal.Models
{
    public class ApplicationUser:IdentityUser
    {
        public UserType UserType { get; set; }
    }
}
