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
    }
}
