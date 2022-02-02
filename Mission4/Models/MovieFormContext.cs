using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Models
{
    public class MovieFormContext : DbContext
    {
        public MovieFormContext (DbContextOptions<MovieFormContext> options) : base (options)
        {
            //leave blank for now 
        }

        public DbSet <FormResponse> Responses { get; set; } // most critical part!! 

        public DbSet<MovieCategory> Categories { get; set; } // for majors model 

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieCategory>().HasData(
                new MovieCategory { CategoryId = 1, CategoryName = "Action/Adventure" },
                new MovieCategory { CategoryId = 2, CategoryName = "Comedy" },
                new MovieCategory { CategoryId = 3, CategoryName = "Drama" },
                new MovieCategory { CategoryId = 4, CategoryName = "Family" },
                new MovieCategory { CategoryId = 5, CategoryName = "Miscellaneous" },
                new MovieCategory { CategoryId = 6, CategoryName = "Television" },
                new MovieCategory { CategoryId = 7, CategoryName = "VHS" }
            );

            mb.Entity<FormResponse>().HasData(    // Seeded data 

                new FormResponse
                {
                    EntryId = 1,                  // Seeded movie 1 
                    CategoryId = 3, 
                    Title = "Charade", 
                    Year = 1963, 
                    Director = "Stanley Donen", 
                    Rating = "PG", 
                    Edited = false,
                    Lent = "", 
                    Notes = ""
                },

                new FormResponse
                {
                    EntryId = 2,                 // Seeded movie 2
                    CategoryId = 1,
                    Title = "Interstellar",
                    Year = 2014,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    Lent = "",
                    Notes = ""
                },

                new FormResponse
                {
                    EntryId = 3,                  // Seeded movie 3
                    CategoryId = 1,
                    Title = "Scooby Doo",
                    Year = 2002,
                    Director = "Raja Gosnell",
                    Rating = "PG",
                    Edited = false,
                    Lent = "",
                    Notes = ""
                }

            );
        }
    }
}
