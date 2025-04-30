using LabbAPI.Models;

namespace LabbAPI.Repositorys
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllPersonsAsync();
        Task<Person> GetPersonByIdAsync(int id);
        Task<IEnumerable<Interest>> GetInterestsOfPersonAsync(int id);
        Task<IEnumerable<Link>> GetLinksOfPersonAsync(int id);
        Task<bool> PersonExistsAsync(int id);
        Task<bool> SaveChangesAsync();
    }
}
