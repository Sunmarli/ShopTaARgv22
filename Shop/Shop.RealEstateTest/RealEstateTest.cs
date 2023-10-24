
using Shop.RealEstateTest;
using ShopCore.Domain;
using ShopCore.Dto;
using ShopCore.ServiceInterface;

namespace Shop.RealEstateTest
{
    public class RealEstateTest : RealTestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptyRealEstate_WhenReturnresult()
        {
            RealEstateDto dto= new RealEstateDto(); 

            dto.Address = "Address";
            dto.SizeSqrM = 223;
            dto.RoomCount = 123;
            dto.Floor = 123;
            dto.BuildingType = "hjh";
            dto.BuiltInYear = DateTime.Now.AddYears(1);
   

            dto.CreatedAt= DateTime.Now.AddYears(1); ;
            dto.UpdatedAt = DateTime.Now.AddYears(1); ;

            var result = await Svc<IRealEstateServices>().Create(dto);

            Assert.NotNull(result);

        }

        [Fact] 
        //chack a path for elements
        public async Task ShouldNot_GetByIdRealEstate_WhenReturnNotEqual()

        {
            Guid guid = Guid.Parse("67457d6e-854d-4112-b467-776ef280574c");
            //kuidas teha automaatselt teeb guidi ???
            Guid wrongGuid =Guid.Parse(Guid.NewGuid().ToString());

            //Guid Wronggugid = Guid.NewGuid();
            //Random random = new Random();
            //int i = random.Next();

            //act
            await Svc<IRealEstateServices>().GetAsync(guid);
            //assert
            Assert.NotEqual(guid, wrongGuid);
        }

        [Fact]
        public async Task Should_GetByidRealEstate_WhenReturnsEqual()
        {

            Guid databaseguid = Guid.Parse("afd172f9-06ea-41df-834b-1b4a0caca842");
            Guid getGuid = Guid.Parse("afd172f9-06ea-41df-834b-1b4a0caca842");

            //act
            await Svc<IRealEstateServices>().GetAsync(getGuid);
            //assert
            Assert.Equal(databaseguid, getGuid);
        }

        [Fact]
        public async Task Should_DeleteByIdRealEstate_WhenDeleteRealestate()
        {
            RealEstateDto realEstate = MockrealEstateData();

            var addrealEstate = await Svc<IRealEstateServices>().Create(realEstate);
            var result = await Svc<IRealEstateServices>().Delete((Guid)addrealEstate.Id);

            Assert.Equal(result, addrealEstate);
        }

        [Fact]
        public async Task SouldNot_DeleteByIdrealEstate_WhenDidNotDeleterealEstate()
        {
            RealEstateDto realEstate=MockrealEstateData();
            var addrealEstate = await Svc<IRealEstateServices>().Create(realEstate);
            var addrealEstate2 = await Svc<IRealEstateServices>().Create(realEstate);

            var result= await Svc<IRealEstateServices>().Delete((Guid)addrealEstate2.Id);

            Assert.NotEqual(result, addrealEstate);

        }


        [Fact]
        public async Task Should_UpdaterealEstate_WhenUpdateData()
        {
            var guid = new Guid("67457d6e-854d-4112-b467-776ef280574c");
            //old data
            RealEstate realEstate = new RealEstate();

            //new data
            RealEstateDto dto = MockrealEstateData();

            realEstate.Id = Guid.Parse("67457d6e-854d-4112-b467-776ef280574c");
            realEstate.Address= "Address";
            realEstate.SizeSqrM = 333;
            realEstate.RoomCount = 1234;
            realEstate.Floor = 10000;
            realEstate.BuildingType = "gggh";
            realEstate.BuiltInYear = DateTime.Now.AddYears(1);
            
            realEstate.CreatedAt = DateTime.Now.AddYears(1);
            realEstate.UpdatedAt = DateTime.Now.AddYears(1);

            await Svc<IRealEstateServices>().Update(dto);

            Assert.Equal(realEstate.Id, guid);
            Assert.NotEqual(realEstate.Floor, dto.Floor);
            Assert.Equal(realEstate.BuildingType, dto.BuildingType);
            Assert.DoesNotMatch(realEstate.RoomCount.ToString(), dto.RoomCount.ToString());    
        }


        [Fact]
        public async Task Should_UpdaterealEstate_WhenUpdateDataVersion2()
        {
            RealEstateDto dto= MockrealEstateData();
            var createrealEstate= await Svc<IRealEstateServices>().Create(dto);


            RealEstateDto update = MockUpdaterealEstateData();
            var updaterealEstate = await Svc<IRealEstateServices>().Update(update);

            Assert.DoesNotMatch(updaterealEstate.Address, createrealEstate.Address);

            Assert.NotEqual(updaterealEstate.Floor, createrealEstate.Floor);
            Assert.Equal(updaterealEstate.BuildingType, createrealEstate.BuildingType);
            Assert.DoesNotMatch(updaterealEstate.RoomCount.ToString(), createrealEstate.RoomCount.ToString());


        }
        [Fact]
        public async Task ShouldNot_UpdaterealEstate_WhenNotUdateData()
        {
            RealEstateDto dto = MockrealEstateData();
            await Svc<IRealEstateServices>().Create(dto);


            RealEstateDto nullUpdate = MockNullrealEstate();
            await Svc<IRealEstateServices>().Update(nullUpdate);

            var nullId= nullUpdate.Id;

            Assert.True(dto.Id== nullId);

        }

        private RealEstateDto MockNullrealEstate()
        {
            RealEstateDto nullDto = new()
            {
                Id=null,
                Address = "Address123",
                SizeSqrM = 777,
                RoomCount = 123,
                Floor = 123,
                BuildingType = "kkk",
                BuiltInYear = DateTime.Now.AddYears(1),
               

                CreatedAt = DateTime.Now.AddYears(1),
                UpdatedAt = DateTime.Now.AddYears(1),
            };
            return nullDto;
        }
        private RealEstateDto MockrealEstateData()
        {
            RealEstateDto realEstate = new()
            {
            Address = "Address",
            SizeSqrM = 666,
            RoomCount = 123,
            Floor = 123,
            BuildingType = "gggh",
            BuiltInYear = DateTime.Now.AddYears(1),
         

            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            };
            return realEstate;

        }

        private RealEstateDto MockUpdaterealEstateData()
        {
            RealEstateDto update = new()
            {
                Address = "AA",
                SizeSqrM = 668,
                RoomCount = 500,
                Floor = 500,
                BuildingType = "gggh",
                BuiltInYear = DateTime.Now.AddYears(1),
                

                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            return update;
        }

    }
}
