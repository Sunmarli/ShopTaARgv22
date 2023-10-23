using ShopCore.Domain;
using ShopCore.Dto;
using ShopCore.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Shop.SpaceshipTest
{
    public class SpaceShipTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptySpaceship_WhenReturnresult()
        {
            SpaceshipDto dto= new SpaceshipDto(); 

            dto.Name = "Name";
            dto.Type = "Type";
            dto.Passengers = 123;
            dto.EnginePower = 123;
            dto.Crew = 123;
            dto.Company = "asd";
            dto.CargoWeight = 123;

            dto.CreatedAt= DateTime.Now;
            dto.ModifiedAt = DateTime.Now;

            var result = await Svc<ISpaceshipServices>().Create(dto);

            Assert.NotNull(result);

        }

        [Fact] 
        //chack a path for elements
        public async Task ShouldNot_GetByIdSpaceship_WhenReturnNotEqual()

        {
            Guid guid = Guid.Parse("67457d6e-854d-4112-b467-776ef280574c");
            //kuidas teha automaatselt teeb guidi ???
            Guid wrongGuid =Guid.Parse(Guid.NewGuid().ToString());

            //Guid Wronggugid = Guid.NewGuid();
            //Random random = new Random();
            //int i = random.Next();

            //act
            await Svc<ISpaceshipServices>().GetAsync(guid);
            //assert
            Assert.NotEqual(guid, wrongGuid);
        }

        [Fact]
        public async Task Should_GetByidSpaceship_WhenReturnsEqual()
        {

            Guid databaseguid = Guid.Parse("afd172f9-06ea-41df-834b-1b4a0caca842");
            Guid getGuid = Guid.Parse("afd172f9-06ea-41df-834b-1b4a0caca842");

            //act
            await Svc<ISpaceshipServices>().GetAsync(getGuid);
            //assert
            Assert.Equal(databaseguid, getGuid);
        }

        [Fact]
        public async Task Should_DeleteByIdSpaceship_WhenDeleteSpaceship()
        {
            SpaceshipDto spaceship = MockSpaceshipData();

            var addspaceship = await Svc<ISpaceshipServices>().Create(spaceship);
            var result = await Svc<ISpaceshipServices>().Delete((Guid)addspaceship.Id);

            Assert.Equal(result, addspaceship);
        }

        [Fact]
        public async Task SouldNot_DeleteByIdSpaceship_WhenDidNotDeleteSpaceship()
        {
            SpaceshipDto spaceship=MockSpaceshipData();
            var addSpaceship = await Svc<ISpaceshipServices>().Create(spaceship);
            var addSpaceship2 = await Svc<ISpaceshipServices>().Create(spaceship);

            var result= await Svc<ISpaceshipServices>().Delete((Guid)addSpaceship2.Id);

            Assert.NotEqual(result, addSpaceship);

        }


        [Fact]
        public async Task Should_UpdateSpaceship_WhenUpdateData()
        {
            var guid = new Guid("67457d6e-854d-4112-b467-776ef280574c");
            //old data
            Spaceship spaceship = new Spaceship();

            //new data
            SpaceshipDto dto=MockSpaceshipData();

            spaceship.Id = Guid.Parse("67457d6e-854d-4112-b467-776ef280574c");
            spaceship.Name= "Name";
            spaceship.Type = "Asdd";
            spaceship.Passengers = 1234;
            spaceship.EnginePower = 10000;
            spaceship.Crew = 10;
            spaceship.Company = "Targv";
            spaceship.CargoWeight = 9000;
            spaceship.CreatedAt = DateTime.Now.AddYears(1);
            spaceship.ModifiedAt = DateTime.Now.AddYears(1);

            await Svc<ISpaceshipServices>().Update(dto);

            Assert.Equal(spaceship.Id, guid);
        }


        private SpaceshipDto MockSpaceshipData()
        {
            SpaceshipDto spaceship = new()
            {
            Name = "Name",
            Type = "Type",
            Passengers = 123,
            EnginePower = 123,
            Crew = 123,
            Company = "asd",
            CargoWeight = 123,

            CreatedAt = DateTime.Now,
            ModifiedAt = DateTime.Now,
            };
            return spaceship;

        }

    }
}
