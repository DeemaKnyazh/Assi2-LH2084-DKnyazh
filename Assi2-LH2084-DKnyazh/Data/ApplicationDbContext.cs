﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using COMP2084_Assignment2_DmitryKnyazhevskiy.Models;
using Assi2_LH2084_DKnyazh.Models;

namespace Assi2_LH2084_DKnyazh.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
            public DbSet<Camper> Campers { get; set; } = default!;
        public DbSet<CampSession> CampSessions { get; set; } = default!;
        public DbSet<Status> Status { get; set; } = default!;
    }
}