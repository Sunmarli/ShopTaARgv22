using ShopCore.Dto;
using ShopCore.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Guid getGuid = Guid.Parse("afd172f9-06ea-41df-834b-1b4a0caca");

            //act
            await Svc<ISpaceshipServices>().GetAsync(getGuid);
            //assert
            Assert.Equal(databaseguid, getGuid);
        }


    }
}
