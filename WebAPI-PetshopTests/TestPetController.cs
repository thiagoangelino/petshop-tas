using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPI_Petshop.Controllers;
using WebAPI_Petshop.Data;
using WebAPI_Petshop.Models;

namespace WebAPI_PetshopTests
{

    [TestClass]
    public class TestPetController
    {
        
        //
        private readonly IRepository _repoTests;

        public TestPetController(IRepository repo)
        {
            _repoTests = repo;
        }

        [TestMethod]
        public async Task GetPetByIdTest()
        {

            Pet model = new Pet();

            var a =await GetTest();
            Console.WriteLine(a);
            var controller = new PetController(_repoTests);
            Pet pet = new Pet { PetId = 99, PetName = "Pet99", PetOwnerName = "Owner", PetOwnerAddress = "Rua das Flores", PetOwnerPhone = "123456789", PetCause = "cause", PetHeaulthState = 0, AccommodationId = 1 };
            await controller.post(pet);
            var result = controller.GetByPetId(99);
            Assert.IsNotNull(result);
            Assert.AreEqual(result, pet);
        }

        [TestMethod]
        public async Task GetPetNotFownd()
        {
            var controller = new PetController(_repoTests);

            var result = await controller.GetByPetId(99999);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
        
        
        
        private Task<Pets[]> GetTest()
        {
            _repoTests.Add(new Pet { PetId = 1, PetName = "Pet1", PetOwnerName = "Owner", PetOwnerAddress = "Rua das Flores", PetOwnerPhone = "123456789", PetCause = "cause", PetHeaulthState = 0, AccommodationId = 1 });
            _repoTests.Add(new Pet { PetId = 2, PetName = "Pet2", PetOwnerName = "Owner", PetOwnerAddress = "Rua das Flores", PetOwnerPhone = "123456789", PetCause = "cause", PetHeaulthState = 0, AccommodationId = 2 });
            _repoTests.Add(new Pet { PetId = 3, PetName = "Pet3", PetOwnerName = "Owner", PetOwnerAddress = "Rua das Flores", PetOwnerPhone = "123456789", PetCause = "cause", PetHeaulthState = 0, AccommodationId = 3 });
            _repoTests.Add(new Pet { PetId = 4, PetName = "Pet4", PetOwnerName = "Owner", PetOwnerAddress = "Rua das Flores", PetOwnerPhone = "123456789", PetCause = "cause", PetHeaulthState = 0, AccommodationId = 4 });

            return (Task<Pets[]>)_repoTests;
        }
        //*/
    }
}
