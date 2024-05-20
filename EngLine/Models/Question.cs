namespace EngLine.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int TestId { get; set; }
        public int Point { get; set; }

        public Test Test { get; set; }
        public ICollection<AnswerOption> AnswerOptions { get; set; }
    }

}
