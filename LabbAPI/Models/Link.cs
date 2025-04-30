using System.ComponentModel.DataAnnotations;

namespace LabbAPI.Models
{
    public class Link
    {
        public int Id { get; set; }

        public int PersonInterestId { get; set; }
        public PersonInterest PersonInterest { get; set; }

        [Url]
        public string Url { get; set; }
    }
}
