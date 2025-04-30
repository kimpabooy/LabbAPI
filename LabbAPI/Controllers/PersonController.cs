using LabbAPI.Data;
using LabbAPI.Models;
using LabbAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LabbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly PersonDbContext _context;

        public PersonController(PersonDbContext context)
        {
            _context = context;
        }

        // OK
        // Get all persons.
        [HttpGet(Name = "GetAllPersons")]
        public async Task<ActionResult<Person>> GetPersons()
        {
            return Ok(await _context.Person.Select(p => new
            {
                p.FirstName,
                p.LastName,
                p.Telefonnummer,
                p.Email
            }
            ).ToListAsync());
        }

       
        
        // Get person by ID.
        [HttpGet("{id}", Name = "GetPersonById")]
        public async Task<ActionResult<Interest>> GetIntrestOfPerson(int id)
        {
            var person = await _context.Person
                .Where(p => p.Id == id)
                .Select(p => new
                {
                    p.FirstName,
                    p.LastName,
                })
                .Distinct()
                .FirstOrDefaultAsync();
            
            if (person == null)
            {
                return NotFound(new { errorMessage = "Person med id " + id + " hittades inte." });
            }

            var personInterest = await _context.PersonInterest
                .Where(pi => pi.PersonId == id)
                .Select(pi => new
                {
                    pi.Interest.Title,
                })
                //.Distinct()
                .ToListAsync();

            if (personInterest == null)
            {
                return NotFound(new { errorMessage = "Inget intresse hittades." });
            }

            /*
                var interest = await _context.PersonInterest
                    .Where(a => person.a.PersonId == id)
                    .Select(a => a.Intrest)
                    .ToListAsync();
             */

            // return person and personInterest
            return Ok(new
            {
                person,
                personInterest
            });
        }

       
        
        // OK
        // Get all links of a persons interest by ID.
        [HttpGet("{id}/Link", Name = "GetInterestAndLinks")]
        public async Task<ActionResult<List<Link>>> GetLinks(int id)
        {
            // check if person excists
            var person = await _context.Person.FindAsync(id);
            if (person == null)
            {
                return NotFound(new { errorMessage = "Person med id " + id + " hittades inte." });
            }

            var personLinks = await _context.Link
                .Where(pl => pl.PersonInterest.PersonId == id)
                .Select(pl => new
                {
                    pl.Url
                })
                .Distinct()
                .ToListAsync();

                return Ok(personLinks);
        }

       
        // OK
        // Lägg till ett nytt intresse och koppla det till en person.
        [HttpPost("{personId}/add-interest")]
        public async Task<IActionResult> AddOrCreateInterestToPerson(int personId, AddInterestRequest request)
        {
            // Check if the person exists
            var person = await _context.Person.FindAsync(personId);
            if (person == null)
            {
                return NotFound($"Person med id {personId} hittades inte.");
            }

            if (string.IsNullOrWhiteSpace(request.Title))
            {
                return BadRequest("Titel på intresset kan inte vara tom.");
            }

            // Check if the interest already exists
            var interest = await _context.Interest
                .FirstOrDefaultAsync(i => i.Title.ToLower() == request.Title.ToLower());
            
            if (interest == null)
            {
                interest = new Interest
                {
                    Title = request.Title,
                    Description = request.Description
                };

                _context.Interest.Add(interest);
                await _context.SaveChangesAsync();
            }

            // Check if the person is already linked to the interest
            var existingPersonInterest = await _context.PersonInterest
                .FirstOrDefaultAsync(pi => pi.PersonId == personId && pi.InterestId == interest.Id);

            if (existingPersonInterest == null)
            {
                return NotFound($"Personen är redan kopplad till intresset >{interest.Title}<.");
            }

            var newPersonInterest = new PersonInterest
            {
                PersonId = personId,
                InterestId = interest.Id
            };

            _context.PersonInterest.Add(newPersonInterest);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetIntrestOfPerson), new { id = personId }, newPersonInterest);
        }

       
        
        // OK
        // Lägg till en ny länk till ett existerande intresse.
        [HttpPost("{PersonId}/interests/{InterestId}/add-link")]
        public async Task<IActionResult> AddLinkToPersonInterest(int PersonId, int InterestId, [FromBody] LinkDto responseDto)
        {
            var personInterest = await _context.PersonInterest
                .FirstOrDefaultAsync(pi => pi.PersonId == PersonId && pi.InterestId == InterestId);

            if (personInterest == null)
            {
                return NotFound($"No interest found for person with id {PersonId} and interest id {InterestId}.");
            }

            if (string.IsNullOrWhiteSpace(responseDto.Url))
            {
                return BadRequest("Url cannot be empty.");
            }

            // Skapa ny länk
            var link = new Link
            {
                Url = responseDto.Url,
                PersonInterestId = personInterest.Id
            };

            _context.Link.Add(link);
            await _context.SaveChangesAsync();

            return Ok(link);
        }

    }
}
