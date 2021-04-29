using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using WebAPI_Petshop.Controllers;

namespace WebAPI_PetshopTests
{
    [TestClass]
    public class TestPetControllerBase
    {
        /*/
        [TestMethod]
        public async Task<Task> GetPet()
        {
            var controller = new PetController(GetTest());

            var result = await controller.GetByPetId(99999);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }//*/
    }
}