using Microsoft.AspNetCore.Mvc;
using Shop.ApplicationServices.Services;
using Shop.Models.Coctails;
using ShopCore.Dto.CoctailDtos;
using ShopCore.ServiceInterface;

namespace Shop.Controllers
{
	public class CoctailsController : Controller
	{ 
			private readonly ICoctailServices _coctailServices;

			public CoctailsController(ICoctailServices coctailServices)
			{
				_coctailServices = coctailServices;
			}
			
			public IActionResult Index()
				{
					return View();
				}
			[HttpPost]
			public IActionResult SearchCoctail(CoctailSearchViewModel model)
			{
				if (ModelState.IsValid)
				{
					return RedirectToAction("Coctail", "Coctails", new { coctail = model.strDrink });

				}

				return View(model);
			}
		[HttpGet]
		public IActionResult Coctail(string coctail)
		{
			CoctailResultDto dto = new();
			dto.strDrink = coctail;
			_coctailServices.CoctailResult(dto);
			CoctailViewModel vm = new();

			//vm.City = vm.City;
			//vm.Lon = vm.Lon;
			vm.idDrink = dto.idDrink;
			vm.strDrink = dto.strDrink;
			vm.strDrinkAlternate = dto.strDrinkAlternate;
			vm.strTags = dto.strTags;
			vm.strIBA = dto.strIBA;
			vm.strAlcoholic = dto.strAlcoholic;
			vm.strGlass = dto.strGlass;

			vm.strInstructions = dto.strInstructions;
			vm.strInstructionsES = dto.strInstructionsES;
			vm.strInstructionsDE = dto.strInstructionsDE;
			vm.strInstructionsFR = dto.strInstructionsFR;
			vm.strInstructionsIT = dto.strInstructionsIT;
			vm.strInstructionsZHHANS = dto.strInstructionsZHHANS;

			vm.strInstructionsZHHANT = dto.strInstructionsZHHANT;
			vm.strDrinkThumb = dto.strDrinkThumb;

			vm.strIngredient1 = dto.strIngredient1;
			vm.strIngredient2 = dto.strIngredient2;
			vm.strIngredient3 = dto.strIngredient3;
			vm.strIngredient4 = dto.strIngredient4;
			vm.strIngredient5 = dto.strIngredient5;
			vm.strIngredient6 = dto.strIngredient6;
			vm.strIngredient7 = dto.strIngredient7;
			vm.strIngredient8 = dto.strIngredient8;
			vm.strIngredient9 = dto.strIngredient9;
			vm.strIngredient10 = dto.strIngredient10;
			vm.strIngredient11 = dto.strIngredient11;
			vm.strIngredient12 = dto.strIngredient12;
			vm.strIngredient13 = dto.strIngredient13;
			vm.strIngredient14 = dto.strIngredient14;
			vm.strIngredient15 = dto.strIngredient15;

			vm.strMeasure1 = dto.strMeasure1;
			vm.strMeasure2 = dto.strMeasure2;
			vm.strMeasure4 = dto.strMeasure4;
			vm.strMeasure5 = dto.strMeasure5;
			vm.strMeasure6 = dto.strMeasure6;

			vm.strMeasure7 = dto.strMeasure7;
			vm.strMeasure8 = dto.strMeasure8;
			vm.strMeasure9 = dto.strMeasure9;
			vm.strMeasure10 = dto.strMeasure10;
			vm.strMeasure11 = dto.strMeasure11;
			vm.strMeasure12 = dto.strMeasure12;
			vm.strMeasure13 = dto.strMeasure13;
			vm.strMeasure14 = dto.strMeasure14;
			vm.strMeasure15 = dto.strMeasure15;

			vm.strImageSource = dto.strImageSource;
			vm.strImageAttribution = dto.strImageAttribution;
			vm.strCreativeCommonsConfirmed = dto.strCreativeCommonsConfirmed;
			vm.dateModified = dto.dateModified;

			return View(vm);
		}

	}
}
