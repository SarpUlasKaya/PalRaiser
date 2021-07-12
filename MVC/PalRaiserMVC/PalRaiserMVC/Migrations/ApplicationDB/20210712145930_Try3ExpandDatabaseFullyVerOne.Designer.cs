﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PalRaiserMVC.Models;

namespace PalRaiserMVC.Migrations.ApplicationDB
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20210712145930_Try3ExpandDatabaseFullyVerOne")]
    partial class Try3ExpandDatabaseFullyVerOne
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PalRaiserMVC.Models.AppUser", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CardExpDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CardNumber")
                        .HasColumnType("int");

                    b.Property<int>("CardSecNo")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("LastLogin")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("PalRaiserMVC.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .HasColumnType("int");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CommentorId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("DislikeCount")
                        .HasColumnType("int");

                    b.Property<int>("LikeCount")
                        .HasColumnType("int");

                    b.HasKey("CommentId", "PostId");

                    b.HasIndex("CommentorId");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("PalRaiserMVC.Models.CommentRating", b =>
                {
                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("CommentId")
                        .HasColumnType("int");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("CommentId1")
                        .HasColumnType("int");

                    b.Property<int>("CommentPostId")
                        .HasColumnType("int");

                    b.Property<bool>("IsLike")
                        .HasColumnType("bit");

                    b.HasKey("UserId", "CommentId", "PostId");

                    b.HasIndex("CommentId1", "CommentPostId");

                    b.ToTable("CommentRatings");
                });

            modelBuilder.Entity("PalRaiserMVC.Models.FollowRequest", b =>
                {
                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.Property<int>("ReceiverId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("bit");

                    b.HasKey("SenderId", "ReceiverId");

                    b.HasIndex("ReceiverId");

                    b.ToTable("FollowRequests");
                });

            modelBuilder.Entity("PalRaiserMVC.Models.Goal", b =>
                {
                    b.Property<int>("GoalId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsReached")
                        .HasColumnType("bit");

                    b.HasKey("GoalId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Goals");
                });

            modelBuilder.Entity("PalRaiserMVC.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CommentCount")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("DislikeCount")
                        .HasColumnType("int");

                    b.Property<int>("LikeCount")
                        .HasColumnType("int");

                    b.Property<int?>("PublisherId")
                        .HasColumnType("int");

                    b.HasKey("PostId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("PalRaiserMVC.Models.PostRating", b =>
                {
                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<bool>("IsLike")
                        .HasColumnType("bit");

                    b.HasKey("UserId", "PostId");

                    b.HasIndex("PostId");

                    b.ToTable("PostRatings");
                });

            modelBuilder.Entity("PalRaiserMVC.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("About")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AmountRaised")
                        .HasColumnType("int");

                    b.Property<int>("DislikeCount")
                        .HasColumnType("int");

                    b.Property<int>("LikeCount")
                        .HasColumnType("int");

                    b.Property<string>("ProjName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PublisherId")
                        .HasColumnType("int");

                    b.Property<int>("ReportCount")
                        .HasColumnType("int");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("PalRaiserMVC.Models.ProjectRating", b =>
                {
                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<bool>("IsLike")
                        .HasColumnType("bit");

                    b.HasKey("UserId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectRatings");
                });

            modelBuilder.Entity("PalRaiserMVC.Models.Report", b =>
                {
                    b.Property<int>("ReportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ReportId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("PalRaiserMVC.Models.Topic", b =>
                {
                    b.Property<int>("TopicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("NoOfReplies")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("TopicBody")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TopicTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TopicId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("PalRaiserMVC.Models.TopicRating", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("TopicId")
                        .HasColumnType("int");

                    b.Property<bool>("IsLike")
                        .HasColumnType("bit");

                    b.HasKey("UserId", "TopicId");

                    b.HasIndex("TopicId");

                    b.ToTable("TopicRatings");
                });

            modelBuilder.Entity("PalRaiserMVC.Models.TopicReply", b =>
                {
                    b.Property<int>("TopicReplyId")
                        .HasColumnType("int");

                    b.Property<int>("TopicId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ReplyBody")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TopicReplyId", "TopicId");

                    b.HasIndex("TopicId");

                    b.HasIndex("UserId");

                    b.ToTable("TopicReplies");
                });

            modelBuilder.Entity("PalRaiserMVC.Models.TopicReplyRating", b =>
                {
                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("TopicReplyId")
                        .HasColumnType("int");

                    b.Property<int>("TopicId")
                        .HasColumnType("int");

                    b.Property<bool>("IsLike")
                        .HasColumnType("bit");

                    b.Property<int>("TopicReplyId1")
                        .HasColumnType("int");

                    b.Property<int>("TopicReplyTopicId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "TopicReplyId", "TopicId");

                    b.HasIndex("TopicReplyId1", "TopicReplyTopicId");

                    b.ToTable("TopicReplyRatings");
                });

            modelBuilder.Entity("PalRaiserMVC.Models.Update", b =>
                {
                    b.Property<int>("UpdateId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Title")
                        .HasColumnType("int");

                    b.HasKey("UpdateId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Updates");
                });

            modelBuilder.Entity("PalRaiserMVC.Models.Comment", b =>
                {
                    b.HasOne("PalRaiserMVC.Models.AppUser", "Commentor")
                        .WithMany("Comments")
                        .HasForeignKey("CommentorId");

                    b.HasOne("PalRaiserMVC.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Commentor");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("PalRaiserMVC.Models.CommentRating", b =>
                {
                    b.HasOne("PalRaiserMVC.Models.AppUser", "User")
                        .WithMany("CommentRatings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PalRaiserMVC.Models.Comment", "Comment")
                        .WithMany("Ratings")
                        .HasForeignKey("CommentId1", "CommentPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PalRaiserMVC.Models.FollowRequest", b =>
                {
                    b.HasOne("PalRaiserMVC.Models.AppUser", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PalRaiserMVC.Models.AppUser", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("PalRaiserMVC.Models.Goal", b =>
                {
                    b.HasOne("PalRaiserMVC.Models.Project", "Project")
                        .WithMany("Goals")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("PalRaiserMVC.Models.Post", b =>
                {
                    b.HasOne("PalRaiserMVC.Models.AppUser", "Publisher")
                        .WithMany("Posts")
                        .HasForeignKey("PublisherId");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("PalRaiserMVC.Models.PostRating", b =>
                {
                    b.HasOne("PalRaiserMVC.Models.Post", "Post")
                        .WithMany("Ratings")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PalRaiserMVC.Models.AppUser", "User")
                        .WithMany("PostRatings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PalRaiserMVC.Models.Project", b =>
                {
                    b.HasOne("PalRaiserMVC.Models.AppUser", "Publisher")
                        .WithMany("PublishedProjects")
                        .HasForeignKey("PublisherId");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("PalRaiserMVC.Models.ProjectRating", b =>
                {
                    b.HasOne("PalRaiserMVC.Models.Project", "Project")
                        .WithMany("Ratings")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PalRaiserMVC.Models.AppUser", "User")
                        .WithMany("ProjectRatings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PalRaiserMVC.Models.Report", b =>
                {
                    b.HasOne("PalRaiserMVC.Models.Project", "Project")
                        .WithMany("Reports")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PalRaiserMVC.Models.AppUser", "User")
                        .WithMany("Reports")
                        .HasForeignKey("UserId");

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PalRaiserMVC.Models.Topic", b =>
                {
                    b.HasOne("PalRaiserMVC.Models.AppUser", "Creator")
                        .WithMany("TopicsCreated")
                        .HasForeignKey("CreatorId");

                    b.HasOne("PalRaiserMVC.Models.Project", "Project")
                        .WithMany("Topics")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("PalRaiserMVC.Models.TopicRating", b =>
                {
                    b.HasOne("PalRaiserMVC.Models.Topic", "Topic")
                        .WithMany("Ratings")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PalRaiserMVC.Models.AppUser", "User")
                        .WithMany("TopicRatings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Topic");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PalRaiserMVC.Models.TopicReply", b =>
                {
                    b.HasOne("PalRaiserMVC.Models.Topic", "Topic")
                        .WithMany("Replies")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PalRaiserMVC.Models.AppUser", "User")
                        .WithMany("TopicReplies")
                        .HasForeignKey("UserId");

                    b.Navigation("Topic");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PalRaiserMVC.Models.TopicReplyRating", b =>
                {
                    b.HasOne("PalRaiserMVC.Models.AppUser", "User")
                        .WithMany("TopicReplyRatings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PalRaiserMVC.Models.TopicReply", "TopicReply")
                        .WithMany("Ratings")
                        .HasForeignKey("TopicReplyId1", "TopicReplyTopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TopicReply");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PalRaiserMVC.Models.Update", b =>
                {
                    b.HasOne("PalRaiserMVC.Models.Project", "Project")
                        .WithMany("Updates")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("PalRaiserMVC.Models.AppUser", b =>
                {
                    b.Navigation("CommentRatings");

                    b.Navigation("Comments");

                    b.Navigation("PostRatings");

                    b.Navigation("Posts");

                    b.Navigation("ProjectRatings");

                    b.Navigation("PublishedProjects");

                    b.Navigation("Reports");

                    b.Navigation("TopicRatings");

                    b.Navigation("TopicReplies");

                    b.Navigation("TopicReplyRatings");

                    b.Navigation("TopicsCreated");
                });

            modelBuilder.Entity("PalRaiserMVC.Models.Comment", b =>
                {
                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("PalRaiserMVC.Models.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("PalRaiserMVC.Models.Project", b =>
                {
                    b.Navigation("Goals");

                    b.Navigation("Ratings");

                    b.Navigation("Reports");

                    b.Navigation("Topics");

                    b.Navigation("Updates");
                });

            modelBuilder.Entity("PalRaiserMVC.Models.Topic", b =>
                {
                    b.Navigation("Ratings");

                    b.Navigation("Replies");
                });

            modelBuilder.Entity("PalRaiserMVC.Models.TopicReply", b =>
                {
                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}
