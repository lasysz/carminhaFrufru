using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebMiauMiau.Models;

namespace WebMiauMiau.Data
{
    public class WebMiauMiauContext : DbContext
    {
        public WebMiauMiauContext (DbContextOptions<WebMiauMiauContext> options)
            : base(options)
        {
        }

        public DbSet<WebMiauMiau.Models.Miau> Miau { get; set; } = default!;
    }
}
