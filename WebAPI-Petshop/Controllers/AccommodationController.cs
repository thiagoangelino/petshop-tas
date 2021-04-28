using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Petshop.Data;
using WebAPI_Petshop.Models;

namespace WebAPI_Petshop.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class AccommodationController : ControllerBase
    {
        private readonly IRepository _repo;

        public AccommodationController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get(){
            try
            {
                var result = await _repo.GetAllAccommodationsAsync();

                return Ok(result);
            }
            catch (System.Exception ex)
            {                
                return BadRequest($"Erro: {ex.Message}");
            }            
        }

        [HttpGet("{acoommodationId}")]
        public async Task<IActionResult> GetByAcoommodationId(int acoommodationId){
            try
            {
                var result = await _repo.GetAccommodationAsyncById(acoommodationId);
                if(result == null) return NotFound("Acomodação não encontrada.");

                return Ok(result);
            }
            catch (System.Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }   
        }

        [HttpGet("state/{accommodationStatus}")]
        public async Task<IActionResult> GetByAcoommodationStatus(int accommodationStatus){
            try
            {
                var result = await _repo.GetAccommodationAsyncByStatus(accommodationStatus);
                if(result == null) return NotFound("Acomodação não encontrada.");

                return Ok(result);
            }
            catch (System.Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }   
        }

        [HttpPost]
        public async Task<IActionResult> post(Accommodation model){
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

        [HttpPut("{accommodationId}")]
        public async Task<IActionResult> put(int accommodationId, Accommodation model){
            try
            {
                var pet = await _repo.GetAccommodationAsyncById(accommodationId);
                if(pet == null) return NotFound("Acomodação não encontrada.");
            
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

        [HttpDelete("{accommodationId}")]
        public async Task<IActionResult> delete(int accommodationId){
            try
            {
                var accommodation = await _repo.GetAccommodationAsyncById(accommodationId);
                if(accommodation == null) return NotFound();
            
                _repo.Delete(accommodation);

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