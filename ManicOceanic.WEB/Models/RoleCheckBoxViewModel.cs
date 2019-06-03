using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManicOceanic.DOMAIN.Entities;

namespace ManicOceanic.WEB.Models
{
    public class RoleCheckBoxViewModel
    {
        public int Id { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool Selected { get; set; }

        public Customer customer { get; set; }
    }
}
