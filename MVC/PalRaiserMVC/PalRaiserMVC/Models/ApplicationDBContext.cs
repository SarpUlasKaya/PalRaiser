using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalRaiserMVC.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TopicReply>().HasKey(reply => new { reply.TopicReplyId, reply.TopicId });
            builder.Entity<Goal>().HasKey(goal => new { goal.GoalId, goal.ProjectId });
            builder.Entity<Update>().HasKey(update => new { update.UpdateId, update.ProjectId });
            builder.Entity<Comment>().HasKey(comment => new { comment.CommentId, comment.PostId });
            builder.Entity<ProjectRating>().HasKey(projectRating => new { projectRating.UserId, projectRating.ProjectId });
            builder.Entity<PostRating>().HasKey(postRating => new { postRating.UserId, postRating.PostId });
            builder.Entity<TopicRating>().HasKey(topicRating => new { topicRating.UserId, topicRating.TopicId });
            builder.Entity<TopicReplyRating>().HasKey(topicReplyRating => new { topicReplyRating.UserId, topicReplyRating.TopicReplyId, topicReplyRating.TopicId });
            builder.Entity<FollowRequest>().HasKey(followRequest => new { followRequest.SenderId, followRequest.ReceiverId });
            builder.Entity<CommentRating>().HasKey(commRating => new { commRating.UserId, commRating.CommentId, commRating.PostId });
            //base.OnModelCreating(builder);
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Update> Updates { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<TopicReply> TopicReplies { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ProjectRating> ProjectRatings { get; set; }
        public DbSet<TopicRating> TopicRatings { get; set; }
        public DbSet<TopicReplyRating> TopicReplyRatings { get; set; }
        public DbSet<PostRating> PostRatings { get; set; }
        public DbSet<CommentRating> CommentRatings { get; set; }
        public DbSet<FollowRequest> FollowRequests { get; set; }
    }
}
