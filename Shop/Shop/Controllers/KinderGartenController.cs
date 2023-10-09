using Microsoft.AspNetCore.Mvc;
using Shop.data;
using Shop.Models.RealEstate;
using ShopCore.Dto;
using ShopCore.ServiceInterface;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models.KinderGarten;

namespace Shop.Controllers
{

    public class KinderGartenController : Controller
    {
        private readonly ShopContext _context;
        private readonly IKindergartenServices _kindergartenServices;

        public KinderGartenController
            (
            ShopContext context,
            IKindergartenServices kindergartenServices
            )
        {
            _context = context;
            _kindergartenServices = kindergartenServices;
        }

        public IActionResult Index()
        {
            var result = _context.Kindergarten
                .Select(x => new KinderGartenIndexViewModel
                {
                    Id = x.Id,
                    GroupName = x.GroupName,
                    ChildrenCount = x.ChildrenCount,
                    KinderGartenName = x.KinderGartenName,
                    Teacher = x.Teacher,
                    
                });
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            KinderGartenCreateUpdateViewModel kindergarten = new KinderGartenCreateUpdateViewModel();

            return View("CreateUpdate", kindergarten);
        }

        [HttpPost]
        public async Task<IActionResult> Create(KinderGartenCreateUpdateViewModel vm)
        {
            var dto = new KindergartenDto()
            {
                Id = vm.Id,
                GroupName = vm.GroupName,
                ChildrenCount = vm.ChildrenCount,
                KinderGartenName = vm.KinderGartenName,
                Teacher = vm.Teacher,
                
                

            };
            var result = await _kindergartenServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var kindergarten = await _kindergartenServices.GetAsync(id);

            if (kindergarten == null)
            {
                return NotFound();
            }


       

            var vm = new KinderGartenDetailsViewModel();

            vm.Id = kindergarten.Id;
            vm.GroupName = kindergarten.Address;
            vm.ChildrenCount = kindergarten.SizeSqrM;
            vm.RoomCount = kindergarten.RoomCount;
            vm.Floor = kindergarten.Floor;
        
            vm.CreatedAt = kindergarten.CreatedAt;
            vm.UpdatedAt = kindergarten.UpdatedAt;
            //vm.Image.AddRange(photos);


            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var realestate = await _realestateServices.GetAsync(id);
            if (realestate == null)
            {
                return NotFound();
            }

            var vm = new RealEstateCreateUpdateViewModel();

            vm.Id = realestate.Id;
            vm.Address = realestate.Address;
            vm.SizeSqrM = realestate.SizeSqrM;
            vm.RoomCount = realestate.RoomCount;
            vm.Floor = realestate.Floor;
            vm.BuildingType = realestate.BuildingType;
            vm.BuiltInYear = realestate.BuiltInYear;
            vm.CreatedAt = realestate.CreatedAt;
            vm.UpdatedAt = realestate.UpdatedAt;

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(RealEstateCreateUpdateViewModel vm)
        {
            var dto = new RealEstateDto()
            {
                Id = vm.Id,
                Address = vm.Address,
                SizeSqrM = vm.SizeSqrM,
                RoomCount = vm.RoomCount,
                Floor = vm.Floor,
                BuildingType = vm.BuildingType,
                BuiltInYear = vm.BuiltInYear,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt,
            };
            var result = await _realestateServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var realestate = await _realestateServices.GetAsync(id);

            if (realestate == null)
            {
                return NotFound();
            }

            var vm = new RealEstateDeleteViewModel();

            vm.Id = realestate.Id;
            vm.Address = realestate.Address;
            vm.SizeSqrM = realestate.SizeSqrM;
            vm.RoomCount = realestate.RoomCount;
            vm.Floor = realestate.Floor;
            vm.BuildingType = realestate.BuildingType;
            vm.BuiltInYear = realestate.BuiltInYear;
            vm.CreatedAt = realestate.CreatedAt;
            vm.UpdatedAt = realestate.UpdatedAt;

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var realestateId = await _realestateServices.Delete(id);

            if (realestateId == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

