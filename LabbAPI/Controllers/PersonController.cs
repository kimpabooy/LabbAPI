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

        //------------- Get All Persons ----------------//
        [HttpGet(Name = "GetAllPersons")]
        public async Task<ActionResult<GetPersonDto>> GetPersons()
        {
            return Ok(await _context.Person
                .Select(p => new GetPersonDto
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Telefonnummer = p.Telefonnummer,
                    Email = p.Email
                })
                .ToListAsync());
        }

        //------------- Get Person's Interest By Id ----------------//
        [HttpGet("{personId}/Interest", Name = "GetPersonInterestById")]
        public async Task<ActionResult<GetPersonInterestDto>> GetIntrestOfPerson(int personId)
        {
            var person = await _context.Person
                .Where(p => p.Id == personId)
                .Select(p => new GetPersonInterestDto
                {
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Interests = new List<InterestDto>()
                })
                .FirstOrDefaultAsync();

            if (person == null)
            {
                return NotFound(new { errorMessage = $"Person med id {personId} hittades inte." });
            }

            var interests = await _context.PersonInterest
                .Where(pi => pi.PersonId == personId)
                .Select(pi => new InterestDto
                {
                    Title = pi.Interest.Title
                })
                .ToListAsync();

            person.Interests = interests;

            return Ok(person);
        }

        //------------- Get All URL From Person By Id ----------------//
        [HttpGet("{personId}/Link", Name = "GetInterestAndLinks")]
        public async Task<ActionResult<GetLinkDto>> GetLinks(int personId)
        {
            // check if person excists
            var person = await _context.Person.FindAsync(personId);
            if (person == null)
            {
                return NotFound(new { errorMessage = "Person med id " + personId + " hittades inte." });
            }

            var personLinks = await _context.PersonInterest
                .Where(pi => pi.PersonId == personId)
                .SelectMany(pi => pi.Link)
                .Select(l => new GetLinkDto
                {
                    Url = l.Url
                })
                .Distinct()
                .ToListAsync();


            //var personLinks = await _context.Link
            //    .Where(pl => pl.PersonInterest.PersonId == personId)
            //    .Select(pl => new GetLinkDto
            //    {
            //        Url = pl.Url
            //    })
            //    .ToListAsync();

            return Ok(personLinks);
        }
        
        //------------- Add New Interest To A Person ----------------//
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

            if (existingPersonInterest != null)
            {
                return BadRequest($"Personen är redan kopplad till intresset >{interest.Title}<.");
            }
            // kolla upp detta!!!!!!
            var newPersonInterest = new PersonInterest
            {
                PersonId = personId,
                InterestId = interest.Id
            };

            _context.PersonInterest.Add(newPersonInterest);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetIntrestOfPerson), new { id = personId }, newPersonInterest);
        }
        
        //------------- Add New URL To An Interest And Person ----------------//
        [HttpPost("{personId}/interests/{InterestId}/add-link")]
        public async Task<IActionResult> AddLinkToPersonInterest(int personId, int InterestId, [FromBody] GetLinkDto responseDto)
        {
            var person = await _context.Person.FindAsync(personId);

            if (person == null)
            {
                return NotFound($"Person med id {personId} hittades inte.");
            }
            
            var personInterest = await _context.PersonInterest
                .FirstOrDefaultAsync(pi => pi.PersonId == personId && pi.InterestId == InterestId);

            if (personInterest == null)
            {
                return NotFound($"No interest found for person with id {personId} and interest id {InterestId}.");
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
