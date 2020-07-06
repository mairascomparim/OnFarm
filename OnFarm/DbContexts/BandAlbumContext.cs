using Microsoft.EntityFrameworkCore;
using OnFarm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnFarm.DbContexts
{
    public class BandAlbumContext : DbContext
    {
        //Construtor  
        public BandAlbumContext(DbContextOptions<BandAlbumContext> options) :
            base (options)
        {
        }

        public DbSet<Band> Bands { get; set; }      
        public DbSet<Album> Albums { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Band>().HasData(new Band()
            {
                Id = Guid.Parse("b5aa38bc-be50-11ea-b3de-0242ac130004"),
                Name = "Metallica",
                Founded = new DateTime(1980,1, 1),
                MainGenre = "Heavy Metal"
            },
            new Band
            {
                Id = Guid.Parse("b5aa3b96-be50-11ea-b3de-0242ac130004"),
                Name = "Guns N Roses",
                Founded = new DateTime(1985,2, 1),
                MainGenre = "Rock"
            },
            new Band
            {
                Id = Guid.Parse("b5aa3ccc-be50-11ea-b3de-0242ac130004"),
                Name = "ABBA",
                Founded = new DateTime(1965, 7, 1),
                MainGenre = "Disco"
            },
            new Band
            {
                Id = Guid.Parse("b5aa3ec0-be50-11ea-b3de-0242ac130004"),
                Name = "Oasis",
                Founded = new DateTime(1991, 12, 1),
                MainGenre = "Alternative"
            },
            new Band
            {
                Id = Guid.Parse("b5aa3fb0-be50-11ea-b3de-0242ac130004"),
                Name = "A-ha",
                Founded = new DateTime(1981, 6, 1),
                MainGenre = "Pop"
            });

            modelBuilder.Entity<Album>().HasData(
                new Album
                {
                    Id = Guid.Parse("8ad268e2-be52-11ea-b3de-0242ac130004"),
                    Title = "Master Of Puppets",
                    Description = "One of the best heavy metal albums ever",
                    BandId = Guid.Parse("b5aa38bc-be50-11ea-b3de-0242ac130004"),
                },

                new Album
                {
                    Id = Guid.Parse("cee0e2c4-be53-11ea-b3de-0242ac130004"),
                    Title = "Appetite for Destruction",
                    Description = "Amazing Rock album with raw sound",
                    BandId = Guid.Parse("b5aa3b96-be50-11ea-b3de-0242ac130004"),
                },

                new Album
                {
                    Id = Guid.Parse("cee0e576-be53-11ea-b3de-0242ac130004"),
                    Title = "Waterloo",
                    Description = "Very groovy album",
                    BandId = Guid.Parse("b5aa3ccc-be50-11ea-b3de-0242ac130004"),
                },

                new Album
                {
                    Id = Guid.Parse("cee0e698-be53-11ea-b3de-0242ac130004"),
                    Title = "Be Here Now",
                    Description = "Arguably one of the best albums by Oasis",
                    BandId = Guid.Parse("b5aa3ec0-be50-11ea-b3de-0242ac130004"),
                },

                new Album
                {
                    Id = Guid.Parse("cee0e77e-be53-11ea-b3de-0242ac130004"),
                    Title = "Hunting Hight and Low ",
                    Description = "Awesome Debut album by A-Ha",
                    BandId = Guid.Parse("b5aa3fb0-be50-11ea-b3de-0242ac130004"),
                });

            base.OnModelCreating(modelBuilder);


        }

    }

}
