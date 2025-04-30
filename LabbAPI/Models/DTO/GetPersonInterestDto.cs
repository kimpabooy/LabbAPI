namespace LabbAPI.Models.DTO
{
    public class GetPersonInterestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<InterestDto> Interests { get; set; }
    }
}
