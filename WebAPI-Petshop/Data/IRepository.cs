using System.Threading.Tasks;
using WebAPI_Petshop.Models;

namespace WebAPI_Petshop.Data
{
    public interface IRepository
    {
        //GERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //ACCOMMODATION
        Task<Accommodation[]> GetAllAccommodationsAsync();        
        Task<Accommodation> GetAccommodationAsyncById(int accommodationId);
        Task<Accommodation[]> GetAccommodationAsyncByStatus(int accommodationId);
        //PET
        Task<Pet[]> GetAllPetsAsync();          
        Task<Pet> GetPetAsyncById(int petId);
        
    }
}