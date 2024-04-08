namespace RegExpChallenge.Database.Entities
{
    public class ExampleMatch
    {
        public int Id { get; set; }
        public int Index { get; set; }
        public int Length { get; set; }
        public int ExampleId { get; set; }
        public Example Example { get; set; }
    }
}
