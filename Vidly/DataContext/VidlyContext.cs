using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.DataContext
{
    public class VidlyContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Customer>()
                //.Property(t => t.Name)
                //.IsRequired()
                //.HasMaxLength(255);

            modelBuilder.Entity<MembershipType>()
                .Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Movie>()
                .Property(t => t.Name)
                .HasMaxLength(255);
        }
    }
}