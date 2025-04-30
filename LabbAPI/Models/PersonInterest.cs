﻿namespace LabbAPI.Models
{
    public class PersonInterest
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int InterestId { get; set; }
        public Interest Interest { get; set; }

        public ICollection<Link>? Link { get; set; }
    }
}
