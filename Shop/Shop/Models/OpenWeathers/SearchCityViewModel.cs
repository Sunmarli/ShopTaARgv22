using System.ComponentModel.DataAnnotations;

namespace Shop.Models.OpenWeathers
{
    public class SearchCityViewModel
    {
        [Required(ErrorMessage ="You must enter city name")]
        [RegularExpression("^[A-Za-z]+$",ErrorMessage ="Only text allowed")]
        [StringLength(20,MinimumLength =2,ErrorMessage ="Enter a city name grather than 2 letters")]
        [Display(Name ="City Name")]


        public string CityName { get; set; }
        
    }
}
