using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManicOceanic.DOMAIN.Entities;

namespace ManicOceanic.WEB.Models
{
    public class AssignRolesViewModel
    {
        public int Id { get; set; }
        public Customer customer { get; set; }
        //public List<string> IdentityRoles { get; set; }
        public List<RoleCheckBoxViewModel> IdentityRoles { get; set; }
    }
}
