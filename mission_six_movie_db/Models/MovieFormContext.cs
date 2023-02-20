using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

// context class to work with database
namespace mission_six_movie_db.Models
{
    public class MovieFormContext : DbContext
    {
        public MovieFormContext (DbContextOptions<MovieFormContext> options ) : base (options)
        {
            // leave for now
        }

        public DbSet<MovieFormResponse> responses { get; set; }
        public DbSet<Category> categories { get; set; }

        // seeding database
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CatId = 1, CategoryName = "Disney" },
                new Category { CatId = 2, CategoryName = "Comedy" },
                new Category { CatId = 3, CategoryName = "Fantasy" }
                );

            mb.Entity<MovieFormResponse>().HasData(

                new MovieFormResponse
                {
                    MovieFormId = 1,
                    CategoryId = 1,
                    Title = "Emperor's New Groove",
                    Year = 2000,
                    Director = "Mark Dindal",
                    Rating = "G",
                    Edited = false,
                    Notes = "World's best movie",
                },
                new MovieFormResponse
                {
                    MovieFormId = 2,
                    CategoryId = 2,
                    Title = "My Cousin Vinny",
                    Year = 1992,
                    Director = "Jonathan Lynn",
                    Rating = "R",
                    Edited = false,
                },
                new MovieFormResponse
                {
                    MovieFormId = 3,
                    CategoryId = 3,
                    Title = "My Neighbor Totoro",
                    Year = 1988,
                    Director = "Hayao Miyazaki",
                    Rating = "G",
                    Edited = false,
                }
            );
        }
    }
}
