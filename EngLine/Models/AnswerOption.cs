namespace EngLine.Models
{
    public class AnswerOption
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int QuestionId { get; set; }
        public bool IsCorrectOption { get; set; }

        public Question Question { get; set; }
    }

}
