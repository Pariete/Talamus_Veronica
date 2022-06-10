using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talamus_Veronica.Models;

namespace Talamus_Veronica.Data
{
    public class TalamusContext : DbContext
    {
        public TalamusContext(DbContextOptions<TalamusContext> options)
           : base(options)
        {
        }

        public DbSet<PartOfStory> PartOfStories { get; set; }
    }
}
