using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCore
{
    public class Program
    {
        private static Func<BloggingContext, Blog> singleBlog = EF.CompileQuery<BloggingContext, Blog>(db => db.Blogs.Single());

        public static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                if (!db.Blogs.Any())
                {
                    var blog = new Blog { Name = "Rowan's Blog " };

                    blog.SetUrl("http://romiller.com");

                    db.Blogs.Add(blog);
                    db.SaveChanges();
                }
            }

            using (var db = new BloggingContext())
            {
                var blog = singleBlog(db);

                Console.WriteLine($"{blog.Name}: {db.Entry(blog).Property("Url").CurrentValue}");

                Console.ReadLine();
            }
        }
    }

    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Customer> Customers { get; set; }
        
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

            modelBuilder.Entity<Customer>()
                            .OwnsOne(c => c.WorkAddress);
            modelBuilder.Entity<Customer>()
                            .OwnsOne(c => c.PhysicalAddress)
                            .ToTable("PhysicalAddresses");

            modelBuilder.Entity<Customer>().HasQueryFilter(c => c.Name.Length > 1);                            
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

    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }

        public Address WorkAddress { get; set; }
        public Address PhysicalAddress { get; set; }
    }

    public class Address
    {
        public string LineOne { get; set; }
        public string LineTwo { get; set; }
        public string PostalOrZipCode { get; set; }
        public string StateOrProvince { get; set; }
        public string CityOrTown { get; set; }
        public string CountryName { get; set; }
    }
        
}
