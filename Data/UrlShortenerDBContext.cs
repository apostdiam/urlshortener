using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text.Json;
using URL_Shortener.Models;

namespace URL_Shortener.Data
{
    public class UrlShortenerDBContext : DbContext
    {
        public UrlShortenerDBContext(DbContextOptions<UrlShortenerDBContext> options) : base(options)
        {
        }

        public DbSet<URLLinks> UrlLinks { get; set; }
        //public DbSet<Visitor> Visitors { get; set; }
         
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-HMI2D7LM\\SQLEXPRESS;Initial Catalog=urlshortenerdb;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    base.OnModelCreating(modelBuilder);

        //    //modelBuilder.Entity<URLLinks>().OwnsMany(urllinks => urllinks.Visitors).ToJson();


        //    modelBuilder.Entity<URLLinks>().
        //        Property(u => u.Visitors).
        //        HasConversion(
        //            v => JsonSerializer.Serialize(v, (new JsonSerializerOptions())),
        //            v => JsonSerializer.Deserialize<List<Visitor>>(v, (new JsonSerializerOptions()))
        //        ).HasColumnType("NVARCHAR(MAX)");


        //    //modelBuilder.Entity<URLLinks>().
        //    //    Property(p => p.Visitors).HasColumnType("nvarchar(max)");

        //}
    }
}
