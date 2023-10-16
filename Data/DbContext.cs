using System;
using ChessApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ChessApi.Data
{  
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<User> Users  { get; set; }

        public DbSet<Game> Games  { get; set; }
        public DbSet<Move> Moves  { get; set; } 
        
        public DbContext(DbContextOptions<DbContext> options): base(options){}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
            modelBuilder.Entity<Game>()
            .HasOne(g => g.WhiteUser)
            .WithMany(u => u.WhiteGames)
            .HasForeignKey(x => x.WhiteUserId)
            .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Game>()
            .HasOne(g => g.BlackUser)
            .WithMany(u => u.BlackGames)
            .HasForeignKey(x => x.BlackUserId)
            .OnDelete(DeleteBehavior.Cascade);
        
            base.OnModelCreating(modelBuilder);
        }
    }
}