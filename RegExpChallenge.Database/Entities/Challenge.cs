namespace RegExpChallenge.Database.Entities
{
    public class Challenge
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required IEnumerable<Example> Examples { get; set; }
    }
}
