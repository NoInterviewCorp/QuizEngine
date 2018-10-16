using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace EFCoreDatabase
{
    public class EFCoreDatabaseContext: DbContext
    {
        //public DbSet<Book> Books{get;set;}
        //public DbSet<Author> Authors{get;set;}
        public DbSet<Note> Notes{get;set;}
        public DbSet<Label> Labels{get;set;}
        public DbSet<CheckList> checkLists{get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;");
        }     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>().HasMany(n => n.checkList).WithOne().HasForeignKey(c => c.NoteId);
            modelBuilder.Entity<Note>().HasMany(n => n.label).WithOne().HasForeignKey(c => c.NoteId);
            modelBuilder.Entity<Label>().HasIndex(e=>e.labelname).IsUnique();
        }    

    }
}