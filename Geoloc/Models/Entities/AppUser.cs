﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Geoloc.Models.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IList<Location> Locations { get; set; }
    }
}