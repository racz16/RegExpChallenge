namespace RegExpChallenge.Database.Entities
{
    public class Example
    {
        public int Id { get; set; }
        public required string Text { get; set; }
        public bool IsPublic { get; set; }
        public int ChallengeId { get; set; }
        public Challenge Challenge { get; set; }
        public IEnumerable<ExampleMatch> Matches { get; set; }
    }
}
