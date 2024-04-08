using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegExpChallenge.Api.Dtos;
using RegExpChallenge.Database;
using RegExpChallenge.Server.Dtos;

namespace RegExpChallenge.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChallengesController : ControllerBase
    {
        private readonly ChallengesDbContext dbContext;

        public ChallengesController(ChallengesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<ChallengeListDto> GetChallenges()
        {
            return dbContext.Challenges.Select(challenge => new ChallengeListDto
            {
                Id = challenge.Id,
                Name = challenge.Name,
                Description = challenge.Description,
            })
            .ToArray();
        }

        [HttpGet("{id}")]
        public ChallengeDetailsDto GetChallenge(int id)
        {
            var challenge = dbContext.Challenges
                .Include(c => c.Examples)
                    .ThenInclude(e => e.Matches)
                .First(c => c.Id == id);
            return new ChallengeDetailsDto
            {
                Id = id,
                Name = challenge.Name,
                Description = challenge.Description,
                Examples = challenge.Examples.Select(example => new ChallengeExampleDto
                {
                    Id = example.Id,
                    Example = example.Text,
                    Matches = example.Matches.Select(match => new ExampleMatchDto
                    {
                        Id = match.Id,
                        Index = match.Index,
                        Length = match.Length,
                    })
                })
            };
        }
    }
}
