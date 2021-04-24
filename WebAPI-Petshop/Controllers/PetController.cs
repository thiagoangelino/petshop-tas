using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Petshop.Data;
using WebAPI_Petshop.Models;

namespace WebAPI_Petshop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetController : ControllerBase
    {
        private readonly IRepository _repo;
        public PetController(IRepository repo)
        {
            _repo = repo;
        }

         [HttpGet]
        public async Task<IActionResult> Get(){
            try
            {
                var result = await _repo.GetAllPetsAsync();

                return Ok(result);
            }
            catch (System.Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }            
        }

        [HttpGet("{PetId}")]
        public async Task<IActionResult> GetByPetId(int petId){
            try
            {
                var result = await _repo.GetPetAsyncById(petId);
                if(result == null) return NotFound("Pet não encontrado.");

                return Ok(result);
            }
            catch (System.Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }   
        }

        [HttpPost]
        public async Task<IActionResult> post(Pet model){
            try
            {
            _repo.Add(model);

            if(await _repo.SaveChangesAsync()){
                return Ok(model);
            }
            }
            catch (System.Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }   
            return BadRequest("Erro não esperado!");
        }

        [HttpPut("{petId}")]
        public async Task<IActionResult> put(int petId, Pet model){
            try
        {
            var pet = await _repo.GetPetAsyncById(petId);
            if(pet == null) return NotFound("Pet não encontrado.");
           
           _repo.Update(model);

           if(await _repo.SaveChangesAsync()){
               return Ok(model);
           }
        }
        catch (System.Exception ex)
        {
            
            return BadRequest($"Erro: {ex.Message}");
        }   
        return BadRequest("Erro não esperado!");
        }

        [HttpDelete("{petId}")]
        public async Task<IActionResult> delete(int petId){
            try
        {
            var pet = await _repo.GetPetAsyncById(petId);
            if(pet == null) return NotFound();
           
           _repo.Delete(pet);

           if(await _repo.SaveChangesAsync()){
               return Ok(new { message = "Delete ok"});
           }
        }
        catch (System.Exception ex)
        {
            
            return BadRequest($"Erro: {ex.Message}");
        }   
        return BadRequest("Erro não esperado!");
        }

    }
}