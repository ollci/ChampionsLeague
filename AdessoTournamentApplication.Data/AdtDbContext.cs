using AdessoTournamentApplication.Data.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AdessoTournamentApplication.Data
{
    public class AdtDbContext : DbContext
    {

        public AdtDbContext(DbContextOptions<AdtDbContext> options)
       : base(options)
        {
        }
        public DbSet<Country>? Countries { get; set; }
        public DbSet<Team>? Teams { get; set; }
        public DbSet<Group>? Groups { get; set; }
        public DbSet<GroupTeam>? GroupTeams { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>()
        .HasMany(g => g.GroupTeams)
        .WithOne(gt => gt.Group)
        .HasForeignKey(gt => gt.GroupId);
        }
    }
}
