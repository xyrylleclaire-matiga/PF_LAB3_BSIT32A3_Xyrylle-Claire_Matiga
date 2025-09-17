using GreedIsland.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace PF_LAB3_BSIT32A3_Xyrylle_Claire_Matiga.Data
{
    public class GreedDbContext : DbContext
    {
        public GreedDbContext(DbContextOptions<GreedDbContext> options)
            : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }
    }
}
