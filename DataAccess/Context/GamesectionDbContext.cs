using System;
using System.Linq;
using DataAccess.Mappings;
using Entity.POCO;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class GamesectionDbContext : IdentityDbContext<AppUser,AppRole,int>
    {
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=GamesectionDb;User Id=sa;Password=*;MultipleActiveResultSets=true;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var item in builder.Model.GetEntityTypes().SelectMany(x=>x.GetForeignKeys()))
            {
                item.DeleteBehavior = DeleteBehavior.Restrict;
            }
            builder.Entity<GameCategory>().HasKey(x => new { x.CategoryID, x.GameID });
            builder.Entity<SecondhandGameCategory>().HasKey(x => new { x.CategoryID, x.SecondhandGameID });
            builder.ApplyConfiguration(new CategoryMap());
            builder.ApplyConfiguration(new GameMap());
            builder.ApplyConfiguration(new GameImageMap());
            builder.ApplyConfiguration(new SecondhandGameMap());
            builder.Entity<AppRole>().HasData
                (
                    new AppRole { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
                    new AppRole { Id = 2, Name = "UserApp", NormalizedName = "USERAPP" }
                );

            base.OnModelCreating(builder);
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<GameCategory> GameCategory { get; set; }
        public DbSet<GameImage> GameImage { get; set; }
        public DbSet<SecondhandGame> SecondhandGame { get; set; }
        public DbSet<SecondhandGameCategory> SecondhandGameCategory { get; set; }
        public DbSet<SecondhandGameImage> SecondhandGameImage { get; set; }


    }
}
