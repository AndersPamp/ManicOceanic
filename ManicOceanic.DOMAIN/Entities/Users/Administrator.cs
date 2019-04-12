using System;

namespace ManicOceanic.DOMAIN.Entities
{
    public class Administrator : User
    {
        public int Id { get; set; }
        public string AdminName { get; set; }
    }
}
