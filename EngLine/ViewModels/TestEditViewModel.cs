namespace EngLine.ViewModels
{
    public class TestEditViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime TimeLimit { get; set; }

        public List<QuestionEditViewModel> Questions { get; set; } = new List<QuestionEditViewModel>();
    }
}
