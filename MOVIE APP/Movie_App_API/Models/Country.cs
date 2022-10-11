﻿
namespace Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Producer> Producers { get; set; }//one to many relationship
    }
}
