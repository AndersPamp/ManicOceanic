using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManicOceanic.DOMAIN.Entities;

namespace ManicOceanic.WEB.Models
{
    public class UserAndRolesViewModel
    {
        public Customer customer;
        public List<string> roles = new List<string>();
    }
}
