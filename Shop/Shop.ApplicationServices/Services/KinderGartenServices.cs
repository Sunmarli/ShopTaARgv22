﻿using Microsoft.EntityFrameworkCore;
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

            Kindergarten spaceship = new Kindergarten();
            spaceship.Id = Guid.NewGuid();
            spaceship.Name = dto.Name;
            spaceship.Type = dto.Type;
            spaceship.Passengers = dto.Passengers;
            spaceship.EnginePower = dto.EnginePower;
            spaceship.Crew = dto.Crew;
            spaceship.Company = dto.Company;
            spaceship.CargoWeight = dto.CargoWeight;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;
            _fileServices.FilesToApi(dto, spaceship);

            await _context.Spaceships.AddAsync( spaceship );
            await _context.SaveChangesAsync();

            return spaceship;
        }

        public async Task<Kindergarten> Update(KindergartenDto dto)
        {
            var domain = new Spaceship();

            domain.Id = dto.Id;
            domain.Name = dto.Name;
            domain.Type = dto.Type;
            domain.Passengers = dto.Passengers;
            domain.EnginePower = dto.EnginePower;
            domain.Crew = dto.Crew;
            domain.Company = dto.Company;
            domain.CargoWeight = dto.CargoWeight;
            domain.CreatedAt = dto.CreatedAt;
            domain.ModifiedAt = DateTime.Now;
            _fileServices.FilesToApi(dto, domain);

            _context.Spaceships.Update(domain);
            await _context.SaveChangesAsync();
            return domain;
        }

        public async Task<Kindergarten> Delete(Guid id)
        {
            var spaceshipId = await _context.Spaceships
                .FirstOrDefaultAsync( x => x.Id == id);

            var images = await _context.FileToApis
                .Where(x => x.SpaceshipId == id)
                .Select(y => new FileToApiDto
                 {
                     Id = y.Id,
                     SpaceshipId = y.SpaceshipId,
                     ExistingFilePath = y.ExistingFilePath,
                 }).ToArrayAsync();

            await _fileServices.RemoveImagesFromApi(images);
                

            _context.Spaceships.Remove( spaceshipId );
            await _context.SaveChangesAsync();

            return spaceshipId;
        }


        public async Task<Spaceship> GetAsync(Guid id)
        {
            var result = await _context.Spaceships
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }


    }
}
