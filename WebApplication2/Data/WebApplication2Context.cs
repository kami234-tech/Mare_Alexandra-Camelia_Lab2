using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Moddels;

namespace WebApplication2.Data
{
    public class WebApplication2Context : DbContext
    {
        public WebApplication2Context (DbContextOptions<WebApplication2Context> options)
            : base(options)
        {
        }

        public DbSet<WebApplication2.Moddels.Book> Book { get; set; } = default!;
        public DbSet<WebApplication2.Moddels.Publisher> Publisher { get; set; } = default!;
        public DbSet<WebApplication2.Moddels.Author> Author { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurare relație Book-Borrowing
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Borrowings)  // presupunând că Book are mai multe Borrowings
                .WithOne(b => b.Book)         // presupunând că Borrowing are o proprietate Book
                .HasForeignKey(b => b.BookID); // adaptează cheia conform structurii tale
        }
        public DbSet<WebApplication2.Moddels.Category> Category { get; set; } = default!;
        public DbSet<WebApplication2.Moddels.Member> Member { get; set; } = default!;
        public DbSet<WebApplication2.Moddels.Borrowing> Borrowing { get; set; } = default!;
    }
}
