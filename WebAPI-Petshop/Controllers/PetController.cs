using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
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
        public async Task<IActionResult> Get()
        {
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
        public async Task<IActionResult> GetByPetId(int petId)
        {
            try
            {
                var result = await _repo.GetPetAsyncById(petId);
                if (result == null) return NotFound("Pet não encontrado.");

                return Ok(result);
            }
            catch (System.Exception ex)
            {

                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(Pet model)
        {
            try
            {
                _repo.Add(model);
                //set state accommodation
                await SetAccommodationValuesAsync(model.AccommodationId, 1, model.PetId);

                if (await _repo.SaveChangesAsync())
                {
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
        public async Task<IActionResult> put(int petId, Pet petUpdate)
        {
            try
            {
                var pet = await _repo.GetPetAsyncById(petId);
                if (pet == null) return NotFound("Pet não encontrado.");

                Pet petOld = await _repo.GetPetAsyncById(petUpdate.PetId);

                int acmIdOld = petOld.AccommodationId;
                int acmIdNew = petUpdate.AccommodationId;

                //ACCOMODATION CHECK
                //check if accommodation has changed
                if (acmIdNew != acmIdOld && acmIdNew * acmIdOld != 0)
                {
                    int newStateAcm;

                    if (petUpdate.PetHeaulthState == 2)
                    {
                        newStateAcm = 2;
                    }
                    else
                    {
                        newStateAcm = 1;
                    }

                    //set state accommodation
                    await SetAccommodationValuesAsync(acmIdNew, newStateAcm, petId);

                    //reset state to old accommodation ( free - value 0)
                    await SetAccommodationValuesAsync(acmIdOld, 0, 0);
                }
                else
                {
                    //check if health condition is "recovered" (value 2)
                    if (petUpdate.PetHeaulthState == 2)
                    {
                        //set accommodation state to "waiting owner" ( value 2)
                        await SetAccommodationValuesAsync(acmIdNew, 2, petId);
                    }
                    else
                    {
                        await SetAccommodationValuesAsync(acmIdNew, 1, petId);
                    }
                }


                //update pet
                _repo.Update(petUpdate);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok(petUpdate);
                }
            }
            catch (System.Exception ex)
            {

                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest("Erro não esperado!");
        }

        public async Task SetAccommodationValuesAsync(int id, int newState, int newPetId)
        {
            Accommodation accommodationUpdate = await _repo.GetAccommodationAsyncById(id);
            accommodationUpdate.AccommodationState = newState;
            accommodationUpdate.PetId = newPetId;

            _repo.Update(accommodationUpdate);
        }
        public async Task SetPetIdToAccommodationAsync(int id, int newPetId)
        {
            Accommodation accommodationUpdate = await _repo.GetAccommodationAsyncById(id);
            accommodationUpdate.AccommodationState = newPetId;
            _repo.Update(accommodationUpdate);
        }

        [HttpDelete("{petId}")]
        public async Task<IActionResult> Delete(int petId)
        {
            try
            {
                var pet = await _repo.GetPetAsyncById(petId);
                if (pet == null) return NotFound();

                //SETUSED USED ACCOMMODATION TO STATE FREE
                await SetAccommodationValuesAsync(pet.AccommodationId, 0, 0);

                _repo.Delete(pet);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok(new { message = "Delete ok" });
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
