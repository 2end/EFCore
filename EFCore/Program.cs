﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EFCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                var blog = new Blog { Name = "Rowan's Blog " };

                blog.SetUrl("http://romiller.com");

                db.Blogs.Add(blog);
                db.SaveChanges();
            }

            using (var db = new BloggingContext())
            {
                var blog = db.Blogs.Single();

                Console.WriteLine($"{blog.Name}: {db.Entry(blog).Property("Url").CurrentValue}");

                Console.ReadLine();
            }
        }
    }

    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        public BloggingContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=efcore;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                            .Property<string>("Url")
                            .HasField("_url");
        }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }

        private string _url;

        public void SetUrl(string url)
        {
            _url = url;
        }

    }
}
