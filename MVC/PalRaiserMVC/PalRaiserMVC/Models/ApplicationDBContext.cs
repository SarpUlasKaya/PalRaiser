using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalRaiserMVC.Models
{
    public class ApplicationDBContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Goal>().HasKey(goal => new { goal.GoalId, goal.ProjectId });
            builder.Entity<Update>().HasKey(update => new { update.UpdateId, update.ProjectId });
            builder.Entity<TopicReply>().HasKey(reply => new { reply.ReplyId, reply.TopicId });
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Update> Updates { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<TopicReply> TopicReplies { get; set; }

    }
}
