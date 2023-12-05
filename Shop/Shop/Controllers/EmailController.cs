using Microsoft.AspNetCore.Mvc;
using Shop.Models.Emails;
using ShopCore.Dto;
using ShopCore.ServiceInterface;

namespace Shop.Controllers
{
	public class EmailsController : Controller
	{
		private readonly IEmailServices _emailServices;

		public EmailsController
			(IEmailServices emailServices)
		{
			_emailServices = emailServices;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SendEmail(EmailViewModel vm)
		{
			var dto = new EmailDto()
			{
				
				To = vm.To,
				Subject = vm.Subject,
				Body = vm.Body,
			};

			_emailServices.SendEmail(dto);
			return RedirectToAction(nameof(Index));


		}

	}
}
