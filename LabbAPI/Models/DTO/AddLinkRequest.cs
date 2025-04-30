using System.ComponentModel.DataAnnotations;

namespace LabbAPI.Models.DTO
{
    public class AddLinkRequest
    {
        public int PersonInterestId { get; set; }
        public PersonInterest PersonInterest { get; set; }

        [Url]
        public string Url { get; set; }
    }
}
