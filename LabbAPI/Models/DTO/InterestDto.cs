namespace LabbAPI.Models.DTO
{
    public class InterestDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Url { get; set; } = new List<string>();
    }
}
