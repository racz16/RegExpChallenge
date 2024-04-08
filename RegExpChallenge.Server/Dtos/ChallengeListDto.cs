namespace RegExpChallenge.Server.Dtos
{
    public class ChallengeListDto
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
