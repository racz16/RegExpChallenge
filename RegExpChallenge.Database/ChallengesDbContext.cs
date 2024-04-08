using Microsoft.EntityFrameworkCore;
using RegExpChallenge.Database.Entities;
using System.Text.RegularExpressions;

namespace RegExpChallenge.Database
{
    public class ChallengesDbContext : DbContext
    {
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<Example> Examples { get; set; }
        public DbSet<ExampleMatch> ExampleMatches { get; set; }

        public string DbPath { get; }

        public ChallengesDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "challenges.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            string[] examples =
            [
                "THIS IS AN ALL UPPERCASE SENTENCE.",
                "This IS a SENTENCE with BOTH uppercase AND lowercase WORDS.",
                "this is a sentence with all lowercase.",
                "This sentence has only one uppercase letter.",
                "In This Sentence, Every Word Starts With Uppercase."
            ];
            var regex = "[A-Z]+";
            var challengeId = 0;
            var exampleId = 0;
            var matchId = 0;
            modelBuilder.Entity<Challenge>().HasData(
                new Challenge
                {
                    Id = ++challengeId,
                    Name = "Uppercase letters",
                    Description = "Match all uppercase letters. If there are multiple uppercase letters after each other, match character sequences together.",
                    Examples = []
                }
            );
            foreach (var example in examples)
            {
                modelBuilder.Entity<Example>().HasData(
                    new Example
                    {
                        Id = ++exampleId,
                        ChallengeId = challengeId,
                        Text = example,
                        IsPublic = true,
                        Matches = []
                    }
                );
                modelBuilder.Entity<ExampleMatch>().HasData(
                    Regex.Matches(example, regex).Select(match => new ExampleMatch
                    {
                        Id = ++matchId,
                        ExampleId = exampleId,
                        Index = match.Index,
                        Length = match.Length,
                    })
                );
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
