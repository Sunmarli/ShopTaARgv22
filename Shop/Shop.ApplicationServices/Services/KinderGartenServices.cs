using Microsoft.EntityFrameworkCore;
using Shop.Data;
using ShopCore.Domain;
using ShopCore.Dto;
using ShopCore.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ApplicationServices.Services
{
    public class KinderGartenServices : IKindergartenServices
    {
        private readonly ShopContext _context;
        private readonly IFileServices _fileServices;

        public KinderGartenServices
            (
                ShopContext context,
             IFileServices fileServices
            )
        {
            _context = context;
            _fileServices = fileServices;
        }


        public async Task<Kindergarten> Create(KindergartenDto dto)
        {

            Kindergarten kindergarten = new Kindergarten();
            kindergarten.Id = Guid.NewGuid();
            kindergarten.GroupName = dto.GroupName;
            kindergarten.ChildrenCount = dto.ChildrenCount;
            kindergarten.KinderGartenName = dto.KinderGartenName;
            kindergarten.Teacher = dto.Teacher;

            kindergarten.CreatedAt = DateTime.Now;
            kindergarten.UpdatedAt = DateTime.Now;
            //_fileServices.FilesToApi(dto, kindergarten);

            await _context.KinderGartens.AddAsync(kindergarten);
            await _context.SaveChangesAsync();

            return kindergarten;
        }

        public async Task<Kindergarten> Update(KindergartenDto dto)
        {
            var domain = new Kindergarten();

            domain.Id = dto.Id;
            domain.GroupName = dto.GroupName;
            domain.ChildrenCount = dto.ChildrenCount;
            domain.KinderGartenName = dto.KinderGartenName;
            domain.Teacher = dto.Teacher;
            
            domain.CreatedAt = dto.CreatedAt;
            domain.UpdatedAt = DateTime.Now;
            //_fileServices.FilesToApi(dto, domain);

            _context.KinderGartens.Update(domain);
            await _context.SaveChangesAsync();
            return domain;
        }

        public async Task<Kindergarten> Delete(Guid id)
        {
            var kindergartenId = await _context.KinderGartens
                .FirstOrDefaultAsync( x => x.Id == id);

            ////var images = await _context.FileToApis
            //    .Where(x => x.SpaceshipId == id)
            //    .Select(y => new FileToApiDto
            //     {
            //         Id = y.Id,
            //         SpaceshipId = y.SpaceshipId,
            //         ExistingFilePath = y.ExistingFilePath,
            //     }).ToArrayAsync();

            //await _fileServices.RemoveImagesFromApi(images);
                

            _context.KinderGartens.Remove(kindergartenId);
            await _context.SaveChangesAsync();

            return kindergartenId;
        }


        public async Task<Kindergarten> GetAsync(Guid id)
        {
            var result = await _context.KinderGartens
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }


    }
}
