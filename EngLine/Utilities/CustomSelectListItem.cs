using Microsoft.AspNetCore.Mvc.Rendering;

namespace EngLine.Utilities
{
	public class CustomSelectListItem : SelectListItem
	{
		public double DataScoreMin { get; set; }
		public double DataScoreMax { get; set; }
	}
}
