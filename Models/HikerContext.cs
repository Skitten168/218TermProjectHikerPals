using Microsoft.EntityFrameworkCore;
using HikerPals.Models;


namespace HikerPals.Models
{
    public class HikerContext : DbContext
    {
        public HikerContext (DbContextOptions<HikerContext> options) : base(options) { }
        public DbSet<Hiker> Hikers { get; set; }
        public DbSet<Trail> Trails { get; set; }
        public DbSet<pack> pack { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Hiker>().HasData(
                    new Hiker
                    {
                        Id = 1,
                        TrailName = "Low Branch",
                        Age = 45,
                        AverageDailyMiles = 15,
                        YearsExperience = 15,
                        TrailId = 1,
                        PackId = 1,
                        email = "littleJimmy@aol.com"
                    },

                      new Hiker
                      {
                          Id = 2,
                          TrailName = "Ten Steps",
                          Age = 65,
                          AverageDailyMiles = 7,
                          YearsExperience = 30,
                          TrailId = 2,
                          PackId = 1,
                          email = "ten@aol.com"
                      },

                      new Hiker
                      {
                          Id = 3,
                          TrailName = "Coach",
                          Age = 33,
                          AverageDailyMiles = 4,
                          YearsExperience = 2,
                          TrailId = 3,
                          PackId = 2,
                          email = "coach@aol.com"
                      },
                      new Hiker
                      {
                          Id = 4,
                          TrailName = "The Captain",
                          Age = 35,
                          AverageDailyMiles = 4,
                          YearsExperience = 2,
                          TrailId = 4,
                          PackId = 3,
                          email = "Cap@aol.com"
                      }
                );


                    modelBuilder.Entity<Trail>().HasData(
                        new Trail
                        {
                            TrailId = 1,
                            TName ="Appalacian Trail",
                            Distance = 2190.0,
                    
                        },
                        new Trail
                        {
                            TrailId = 2,
                            TName = "Pacific Crest Trail",
                            Distance = 2650.0,

                        },
                        new Trail
                        {
                            TrailId = 3,
                            TName = "Arizona Trail",
                            Distance = 789.0,

                        },
                        new Trail
                        {
                            TrailId = 4,
                            TName = "Continental Divide Trail",
                            Distance = 3100.0,

                        }
                        );

                    modelBuilder.Entity<pack>().HasData(
                        new pack
                        {
                            PackId = 1,
                            PackName = "Osprey Atmos",
                            PackVolume = 65,
                        },
                        new pack
                        {
                            PackId = 2,
                            PackName = "Gregory Paragon",
                            PackVolume = 58,
                        },
                        new pack
                        {
                            PackId = 3,
                            PackName = "REI Traverse",
                            PackVolume = 65,
                        }
                        );


    }


        /*public DbSet<HikerPals.Models.pack> pack { get; set; }*/
    }
}
