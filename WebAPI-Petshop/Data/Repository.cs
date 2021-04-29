using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI_Petshop.Models;

namespace WebAPI_Petshop.Data
{

    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Accommodation> GetAccommodationAsyncById(int accommodationId)
        {
            IQueryable<Accommodation> query = _context.Accommodations;

            query = query.AsNoTracking()
                         .OrderBy(acm => acm.Id)
                         .Where(acm => acm.Id == accommodationId);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Accommodation[]> GetAccommodationAsyncByStatus(int accommodationStatus)
        {
            IQueryable<Accommodation> query = _context.Accommodations;


            query = query.AsNoTracking()
                         .Where(acm => acm.AccommodationState == accommodationStatus);

            return await query.ToArrayAsync();
        }

        public async Task<Pet> GetPetAsyncById(int petId)
        {
            IQueryable<Pet> query = _context.Pets;

            query = query.AsNoTracking()
                         .OrderBy(pet => pet.PetId)
                         .Where(pet => pet.PetId == petId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Accommodation[]> GetAllAccommodationsAsync()
        {
            IQueryable<Accommodation> query = _context.Accommodations;

            query = query.AsNoTracking().OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Pet[]> GetAllPetsAsync()
        {
            IQueryable<Pet> query = _context.Pets;

            query = query.AsNoTracking().OrderBy(c => c.PetId);

            return await query.ToArrayAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public int GetCount()
        {
            return _context.Pets.Count();
        }

    }
}