﻿using ShopCore.Domain;
using ShopCore.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCore.ServiceInterface
{
    public interface ISpaceshipServices
    {
        Task<Spaceship> Create(SpaceshipDto dto);
        Task<Spaceship> GetAsync(Guid id);
        Task<Spaceship> Update(SpaceshipDto dto);
        Task<Spaceship> Delete(Guid id);
    }
}
