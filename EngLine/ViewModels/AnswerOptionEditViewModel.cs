namespace EngLine.ViewModels
{
    public class AnswerOptionEditViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
		public bool IsDeleted { get; set; }
		public bool IsCorrectOption { get; set; }
    }
}
