using RegExpChallenge.Api.Dtos;

namespace RegExpChallenge.Server.Dtos
{
    public class ChallengeExampleDto
    {
        public required int Id { get; set; }
        public required string Example { get; set; }
        public required IEnumerable<ExampleMatchDto> Matches { get; set; }
    }
}
