using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPI_Petshop.Controllers;
using WebAPI_Petshop.Models;
using Xunit;

namespace WebAPI_PetshopTests
{

    [TestClass]
    public class TestPetController
    {



        [TestMethod]
        public void GetAllPets_ShouldReturnAllPets()
        {
            var testPets = GetTest();
            var controller = new PetController((WebAPI_Petshop.Data.IRepository)testPets);

            var result = controller.Get();
            Assert.AreEqual(testPets, result);
        }
        private List<Pet> GetTest()
        {
            var testPets = new List<Pet>();
            testPets.Add(new Pet { PetId = 1, PetName = "Pet1", PetOwnerName = "Owner", PetOwnerAddress = "Rua das Flores", PetOwnerPhone = "123456789", PetCause = "cause", PetHeaulthState = 0, AccommodationId = 1 });
            testPets.Add(new Pet { PetId = 2, PetName = "Pet2", PetOwnerName = "Owner", PetOwnerAddress = "Rua das Flores", PetOwnerPhone = "123456789", PetCause = "cause", PetHeaulthState = 0, AccommodationId = 2 });
            testPets.Add(new Pet { PetId = 3, PetName = "Pet3", PetOwnerName = "Owner", PetOwnerAddress = "Rua das Flores", PetOwnerPhone = "123456789", PetCause = "cause", PetHeaulthState = 0, AccommodationId = 3 });
            testPets.Add(new Pet { PetId = 4, PetName = "Pet4", PetOwnerName = "Owner", PetOwnerAddress = "Rua das Flores", PetOwnerPhone = "123456789", PetCause = "cause", PetHeaulthState = 0, AccommodationId = 4 });

            return testPets;
        }
    }
}
