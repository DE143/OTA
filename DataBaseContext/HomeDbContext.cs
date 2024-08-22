using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using OTA_Portal_Service.Models.Entities;

namespace OTA_Portal_Service.DataBaseContext
{
    public class HomeDbContext:DbContext
    {
        public HomeDbContext(DbContextOptions<HomeDbContext> options) : base(options) { }
       
        
        
        
        public DbSet <Slide> Slides  { get; set; }
        public DbSet <Service> services {  get; set; }
        public DbSet<BlogsAndNews> BlogsAndNews { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<contactUs> contactUs { get; set; }
        public DbSet<goal> goal { get; set; }
        public DbSet<mission> mission { get; set; }
        public DbSet<Rule> rule { get; set; }
        public DbSet<TeamMember> teamMember { get; set; }
        public DbSet<testimonies> testimonies { get; set; }
        public DbSet<Vision> vision { get; set; }
        public DbSet<PersonalProfile> personalProfiles { get; set; }
        public DbSet<Address> addresses { get; set; }
        public DbSet<Batch> batches { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<EducationalLevel> educationalLevels { get; set; }
        public DbSet<Region> regions { get; set; }
        //public DbSet<TrainingCategory> trainingCategories { get; set; }
        public DbSet<TrainingCenterList> trainingCenterLists { get; set; }
        public DbSet<Woreda> woredas { get; set; }
        public DbSet<ZoneList> zoneLists { get; set; }
        public DbSet<TrainingCenterCapacity> trainingCenterCapacities { get; set; }
        public DbSet<Trainee> trainees { get; set; }
        public DbSet<TrainingCategory> trainingCategories { get; set; }


    }
}
