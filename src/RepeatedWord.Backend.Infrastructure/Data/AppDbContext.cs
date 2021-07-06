using Microsoft.EntityFrameworkCore;
using RepeatedWord.Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepeatedWord.Backend.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Sentence> Sentences { get; set; }

        public DbSet<Word> Words { get; set; }
    }
}
