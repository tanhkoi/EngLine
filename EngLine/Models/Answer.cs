namespace EngLine.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Content { get; set; }
        public int SelectedAnswerId { get; set; }
        public int StudentResponseId { get; set; }

        public StudentResponse StudentResponse { get; set; }
    }

}
