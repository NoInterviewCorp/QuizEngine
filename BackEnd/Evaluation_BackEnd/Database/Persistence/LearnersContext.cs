// using System;
// using System.Collections.Generic;
// using System.ComponentModel.DataAnnotations;
// using Learners.Models;
// using Microsoft.EntityFrameworkCore;
// namespace Learners.Persistence {
//     public class LearnersContext : DbContext {
//         public DbSet<Technology> Technologies { get; set; }
//         public DbSet<Topic> Topics { get; set; }
//         public DbSet<Question> Questions { get; set; }
//         public DbSet<Option> Options { get; set; }
//         public DbSet<Resource> Resources { get; set; }
//         public DbSet<Concept> Concepts { get; set; }
//         public DbSet<LearningPlan> LearningPlan { get; set; }
//         public DbSet<QuizData> QuizDatas {get; set;}
//         public DbSet<TemporaryData> Temporaries {get; set;} 
//         public DbSet<UserData> UserDatas {get; set;}
//         // Database tables for every join M-M relations
//         public DbSet<ResourceConcept> ResourceConcepts { get; set; }
//         public DbSet<ResourceTechnology> ResourceTechnologies { get; set; }
//         public DbSet<ResourceTopic> ResourceTopics { get; set; }
//         public DbSet<ConceptQuestion> ConceptQuestions { get; set; }
//         public DbSet<ConceptTechnology> ConceptTechnologies { get; set; }

        // protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
        //     optionsBuilder.UseSqlServer (@"Server=loaclhost;Database=master;Trusted_Connection=False;MultipleActiveResultSets=true;User Id=SA;Password=AlquidA@9826;");
        // }
//         protected override void OnModelCreating (ModelBuilder modelBuilder) {
//             // Composite keys for join tables
//             modelBuilder.Entity<ConceptQuestion> ()
//                 .HasKey (cq => new { cq.ConceptId, cq.QuestionId });

//             modelBuilder.Entity<ConceptTechnology> ()
//                 .HasKey (ct => new { ct.ConceptId, ct.TechnologyId });

//             modelBuilder.Entity<ResourceConcept> ()
//                 .HasKey (rc => new { rc.ConceptId, rc.ResourceId });

//             modelBuilder.Entity<ResourceTechnology> ()
//                 .HasKey (rt => new { rt.ResourceId, rt.TechnologyId });

//             modelBuilder.Entity<ResourceTopic> ()
//                 .HasKey (rt => new { rt.ResourceId, rt.TopicId });

//             // 1-M Question -> Options
//             modelBuilder.Entity<Question> ().HasMany (question => question.Options)
//                 .WithOne ().HasForeignKey (option => option.QuestionId);

//             // 1-M Question -> Resource
//             modelBuilder.Entity<Question> ().HasOne (q => q.Resource)
//                 .WithMany (r => r.Questions).HasForeignKey (q => q.ResourceId);

//             // 1-M Topic -> Learning Plan
//             modelBuilder.Entity<Topic> ().HasOne (t => t.LearningPlan)
//                 .WithMany (lp => lp.Topics).HasForeignKey (t => t.LearningPlanId);

//             // 1-M Learning plan -> Technology
//             modelBuilder.Entity<LearningPlan> ().HasOne (lp => lp.Technology)
//                 .WithMany (t => t.LearningPlans).HasForeignKey (lp => lp.TechnologyId);

//             // 1-M Technology -> Question
//             modelBuilder.Entity<Question> ().HasOne (q => q.Technology)
//                 .WithMany (t => t.Questions).HasForeignKey (q => q.TechnologyId);

//             // M-M Concept -> Question
//             modelBuilder.Entity<ConceptQuestion> ().HasOne (cq => cq.Concept)
//                 .WithMany (c => c.ConceptQuestions).HasForeignKey (cq => cq.ConceptId);

//             modelBuilder.Entity<ConceptQuestion> ().HasOne (cq => cq.Question)
//                 .WithMany (q => q.ConceptQuestions).HasForeignKey (cq => cq.QuestionId);

//             // M-M Concept -> Technology
//             modelBuilder.Entity<ConceptTechnology> ().HasOne (ct => ct.Concept)
//                 .WithMany (c => c.ConceptTechnologies).HasForeignKey (ct => ct.ConceptId);

//             modelBuilder.Entity<ConceptTechnology> ().HasOne (ct => ct.Technology)
//                 .WithMany (t => t.ConceptTechnologies).HasForeignKey (ct => ct.TechnologyId);

//             // M-M Resource -> Concept
//             modelBuilder.Entity<ResourceConcept> ().HasOne (rc => rc.Resource)
//                 .WithMany (r => r.ResourceConcepts).HasForeignKey (rc => rc.ResourceId);

//             modelBuilder.Entity<ResourceConcept> ().HasOne (rc => rc.Concept)
//                 .WithMany (c => c.ResourceConcepts).HasForeignKey (rc => rc.ConceptId);

//             // M-M Resource -> Technology
//             modelBuilder.Entity<ResourceTechnology> ().HasOne (rt => rt.Resource)
//                 .WithMany (r => r.ResourceTechnologies).HasForeignKey (rt => rt.ResourceId);

//             modelBuilder.Entity<ResourceTechnology> ().HasOne (rt => rt.Technology)
//                 .WithMany (t => t.ResourceTechnologies).HasForeignKey (rt => rt.TechnologyId);

//             // M-M Resource -> Topic
//             modelBuilder.Entity<ResourceTopic> ().HasOne (rt => rt.Resource)
//                 .WithMany (r => r.ResourceTopics).HasForeignKey (rt => rt.ResourceId);

//             modelBuilder.Entity<ResourceTopic> ().HasOne (rt => rt.Topic)
//                 .WithMany (t => t.ResourceTopics).HasForeignKey (rt => rt.TopicId);

//         }
//     }
// }