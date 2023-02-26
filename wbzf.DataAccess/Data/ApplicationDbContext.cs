using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using wbzf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wbzf.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<coachingForm> coachingForms { get; set; }
        public DbSet<donation> donations { get; set; }
        public DbSet<ScholarshipApplication> scholarshipApplications { get; set; }
        public DbSet<Profession> professions { get; set; }
        public DbSet<Purpose> purposes { get; set; }
        public DbSet<Scheme> Schemes { get; set; }
    }
}
