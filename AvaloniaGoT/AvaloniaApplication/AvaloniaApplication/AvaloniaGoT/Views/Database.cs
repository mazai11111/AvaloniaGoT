using System;
using Microsoft.EntityFrameworkCore;
using AvaloniaApplication.Models;


namespace AvaloniaApplication.Views
{
    public class Database : DbContext
    {
        public DbSet<House> House { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Character> Character { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Console.WriteLine("OnConfiguring");
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=db;Username=db;Password=db;");
        }
    }
}