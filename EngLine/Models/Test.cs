namespace EngLine.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime TimeLimit { get; set; }

        public ICollection<Question> Questions { get; set; }
        public ICollection<StudentResponse> StudentResponses { get; set; }
    }

}
