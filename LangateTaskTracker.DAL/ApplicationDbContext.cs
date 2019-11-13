using System;
using System.Collections.Generic;
using System.Text;
using LangateTaskTracker.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LangateTaskTracker.DAL
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<TrackerTask> TrackerTasks { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>()
                .HasMany(u => u.Tasks)
                .WithOne(t => t.User);
        }
    }
}
