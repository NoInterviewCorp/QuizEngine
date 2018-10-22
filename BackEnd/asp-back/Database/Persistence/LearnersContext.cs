using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Learners.Models;
namespace Learners.Persistence
{
    public class LearnersContext : DbContext
    {
        public DbSet<Technology> Technologies{get;set;}
        public DbSet<Topic> Topics{get;set;}
        public DbSet<Question> Questions{get;set;}
        public DbSet<Option> Options{get;set;}
        public DbSet<Threshold> Thresholds{get;set;}
        public DbSet<UserData> UserDatas{get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Technology>().HasMany(tech => tech.Topics).WithOne().HasForeignKey(topic => topic.TechnologyId);
            modelBuilder.Entity<Topic>().HasMany(topic => topic.Questions).WithOne().HasForeignKey(question => question.TopicId);
            modelBuilder.Entity<Question>().HasMany(question => question.Options).WithOne().HasForeignKey(option => option.QuestionId);
        }
    }
}