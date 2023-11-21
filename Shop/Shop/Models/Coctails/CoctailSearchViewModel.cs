using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Shop.Models.Coctails
{
	public class CoctailSearchViewModel
	{
		[Required(ErrorMessage = "You must enter coctail name")]
		//[RegularExpression("^[A-Za-z]+$", ErrorMessage = "Only text allowed")]
		[StringLength(20, MinimumLength = 2, ErrorMessage = "Enter a coctail name grather than 2 letters")]
		[Display(Name = "Coctail")]


		public string strDrink { get; set; }

	}
}

