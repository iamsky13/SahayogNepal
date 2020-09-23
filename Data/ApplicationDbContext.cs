using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SahayogNepal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahayogNepal.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Donor> Donors { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
     : base(options)
        {
        }

        public ApplicationDbContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Donor>().HasKey(x => x.Id);
            builder.Entity<Patient>().HasKey(x => x.Id);
            base.OnModelCreating(builder);

        }
    }
}
