using LabbAPI.Data;
using LabbAPI.Models;

namespace LabbAPI.Repositorys
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonDbContext _context;
        public PersonRepository(PersonDbContext context)
        {
            _context = context;
        }
        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
        public Task<bool> PersonExistsAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Person>> GetAllPersonsAsync()
        {
            throw new NotImplementedException();
        }
        public Task<Person> GetPersonByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Interest>> GetInterestsOfPersonAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Link>> GetLinksOfPersonAsync(int id)
        {
            throw new NotImplementedException();
        }
 
    
        
    }
}
