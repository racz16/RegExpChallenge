namespace RegExpChallenge.Server.Dtos
{
    public class ChallengeDetailsDto
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required IEnumerable<ChallengeExampleDto> Examples { get; set; }
    }
}
