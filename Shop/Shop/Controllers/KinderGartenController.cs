using Microsoft.AspNetCore.Mvc;
using Shop.data;

using ShopCore.Dto;
using ShopCore.ServiceInterface;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models.KinderGarten;
using ShopCore.Domain;

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
            var result = _context.KinderGartens
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
            vm.GroupName = kindergarten.GroupName;
            vm.ChildrenCount = kindergarten.ChildrenCount;
            vm.KinderGartenName = kindergarten.KinderGartenName;
            vm.Teacher = kindergarten.Teacher;
        
            vm.CreatedAt = kindergarten.CreatedAt;
            vm.UpdatedAt = kindergarten.UpdatedAt;
            //vm.Image.AddRange(photos);

            return View(vm);
            
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var kindergarten = await _kindergartenServices.GetAsync(id);
            if (kindergarten == null)
            {
                return NotFound();
            }

            var vm = new KinderGartenCreateUpdateViewModel();

            vm.Id = kindergarten.Id;
            vm.GroupName = kindergarten.GroupName;
            vm.ChildrenCount = kindergarten.ChildrenCount;
            vm.KinderGartenName = kindergarten.KinderGartenName;
           
            vm.CreatedAt = kindergarten.CreatedAt;
            vm.UpdatedAt = kindergarten.UpdatedAt;

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(KinderGartenCreateUpdateViewModel vm)
        {
            var dto = new KindergartenDto()
            {
                Id = vm.Id,
                GroupName = vm.GroupName,
                ChildrenCount = vm.ChildrenCount,
                KinderGartenName = vm.KinderGartenName,
                Teacher = vm.Teacher,
                
                CreatedAt = vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt,
            };
            var result = await _kindergartenServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var kindergarten = await _kindergartenServices.GetAsync(id);

            if (kindergarten == null)
            {
                return NotFound();
            }

            var vm = new KinderGartenDeleteViewModel();

            vm.Id = kindergarten.Id;
            vm.GroupName = kindergarten.GroupName;
            vm.ChildrenCount = kindergarten.ChildrenCount;
            vm.KinderGartenName = kindergarten.KinderGartenName;
            vm.Teacher = kindergarten.Teacher;
          
            vm.CreatedAt = kindergarten.CreatedAt;
            vm.UpdatedAt = kindergarten.UpdatedAt;

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var kindergartenId = await _kindergartenServices.Delete(id);

            if (kindergartenId == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

