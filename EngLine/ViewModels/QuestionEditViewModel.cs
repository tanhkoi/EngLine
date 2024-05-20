namespace EngLine.ViewModels
{
    public class QuestionEditViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Point { get; set; }
		public bool IsDeleted { get; set; }
		public List<AnswerOptionEditViewModel> AnswerOptions { get; set; } = new List<AnswerOptionEditViewModel>();
    }
}
