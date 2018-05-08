﻿using System;
using Geoloc.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Geoloc.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, UserRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Relation> Relations { get; set; }
        public DbSet<UserInMeeting> UserInMeetings { get; set; }
    }
}
