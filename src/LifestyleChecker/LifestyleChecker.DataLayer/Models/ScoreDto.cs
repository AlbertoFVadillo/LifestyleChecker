namespace LifestyleChecker.DataLayer.Models
{
    public record ScoreDto
    {
        public int From { get; set; }
        public int? To { get; set; }
        public int Q1 { get; set; }
        public int Q2 { get; set; }
        public int Q3 { get; set; }
    }
}
