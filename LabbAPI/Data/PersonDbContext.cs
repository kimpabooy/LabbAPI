using Microsoft.EntityFrameworkCore;
using LabbAPI.Models;

namespace LabbAPI.Data
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options) { }

        public DbSet<Person> Person { get; set; }
        public DbSet<Interest> Interest { get; set; }
        public DbSet<PersonInterest> PersonInterest { get; set; }
        public DbSet<Link> Link { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, FirstName = "Kim", LastName = "Andersson", Telefonnummer = "0701234560", Email = "kim@example.com" },
                new Person { Id = 2, FirstName = "Sara", LastName = "Nilsson", Telefonnummer = "0701234561", Email = "sara@example.com" },
                new Person { Id = 3, FirstName = "Kalle", LastName = "Johansson", Telefonnummer = "0701234562", Email = "kalle@example.com" },
                new Person { Id = 4, FirstName = "Josefine", LastName = "Svärd", Telefonnummer = "0701234563", Email = "josefine@example.com" },
                new Person { Id = 5, FirstName = "Max", LastName = "Bengtsson", Telefonnummer = "0701234564", Email = "max@example.com" }
            );

            // Seed for Interest
            modelBuilder.Entity<Interest>().HasData(
                new Interest { Id = 1, Title = "Coding", Description = "Loves to code in C# and JavaScript." },
                new Interest { Id = 2, Title = "Gaming", Description = "Enjoys both competitive and casual gaming." },
                new Interest { Id = 3, Title = "Music", Description = "Plays the guitar and enjoys rock music." },
                new Interest { Id = 4, Title = "Video", Description = "Records videos for fun." },
                new Interest { Id = 5, Title = "Exercise", Description = "Loves to exercise aims to becomes the next Arnold." }
            );

            // Seed for PersonInterest
            modelBuilder.Entity<PersonInterest>().HasData(
                new PersonInterest { Id = 1, PersonId = 1, InterestId = 1 },
                new PersonInterest { Id = 2, PersonId = 1, InterestId = 2 },
                new PersonInterest { Id = 3, PersonId = 2, InterestId = 3 },
                new PersonInterest { Id = 4, PersonId = 2, InterestId = 4 },
                new PersonInterest { Id = 5, PersonId = 3, InterestId = 3 },
                new PersonInterest { Id = 6, PersonId = 4, InterestId = 5 },
                new PersonInterest { Id = 7, PersonId = 5, InterestId = 2 },
                new PersonInterest { Id = 8, PersonId = 5, InterestId = 1 }
            );

            // Seed for Link
            modelBuilder.Entity<Link>().HasData(
                new Link { Id = 1, PersonInterestId = 1, Url = "https://leetcode.com/problemset/" },
                new Link { Id = 2, PersonInterestId = 2, Url = "https://store.epicgames.com/en-US/" },
                new Link { Id = 3, PersonInterestId = 3, Url = "https://open.spotify.com/" },
                new Link { Id = 4, PersonInterestId = 4, Url = "https://www.youtube.com/" },
                new Link { Id = 5, PersonInterestId = 5, Url = "https://open.spotify.com/" },
                new Link { Id = 6, PersonInterestId = 6, Url = "https://nordicwellness.se/trana/" },
                new Link { Id = 7, PersonInterestId = 7, Url = "https://store.epicgames.com/en-US/" },
                new Link { Id = 8, PersonInterestId = 8, Url = "https://leetcode.com/problemset/" }
            );

        }
    }
}
