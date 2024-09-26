using ContactManagerClassLibrary.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerClassLibrary.Infrastructure.Data
{
    public class Context : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Group> Groups { get; set; }

        //private readonly string _connectionString;

        //public Context() : base()
        //{
        //    _connectionString = LoadConnectionString();
        //}

        //private string LoadConnectionString()
        //{
        //    var builder = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("AppSettings.json", optional: false, reloadOnChange: true);

        //    IConfiguration configuration = builder.Build();

        //    return configuration.GetConnectionString("DefaultConnection");
        //}

        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer(_connectionString)
            //                  .UseLazyLoadingProxies();
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .HasMany(c => c.Groups)
                .WithMany(g => g.Contacts)
                .UsingEntity(j => j.ToTable("ContactGroup"));
        }
    }
}
