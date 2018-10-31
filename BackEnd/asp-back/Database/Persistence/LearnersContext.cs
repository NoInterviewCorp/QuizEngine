using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Learners.Models;
using Microsoft.EntityFrameworkCore;
namespace Learners.Persistence {
    public class LearnersContext : DbContext {
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Threshold> Thresholds { get; set; }
        public DbSet<UserData> UserDatas { get; set; }
        public DbSet<QuizData> QuizDatas { get; set; }
        public DbSet<TemporaryData> Temporaries { get; set; }
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer (@"Server=db;Database=master;User=SA;Password=Your_password123;");
        }
        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.Entity<Technology> ().HasMany (tech => tech.Topics).WithOne ().HasForeignKey (topic => topic.TechnologyId);
            modelBuilder.Entity<Topic> ().HasMany (topic => topic.Questions).WithOne ().HasForeignKey (question => question.TopicId);
            modelBuilder.Entity<Question> ().HasMany (question => question.Options).WithOne ().HasForeignKey (option => option.QuestionId);
            modelBuilder.Entity<UserData> ().HasMany (userdata => userdata.QuizDatas).WithOne ().HasForeignKey (quizdata => quizdata.UserName);
        }
    }
}