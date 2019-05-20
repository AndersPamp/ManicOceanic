using Microsoft.AspNetCore.Identity;
using System;

namespace ManicOceanic.DOMAIN.Entities
{
  public class Customer : IdentityUser
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string SocialSecurityNumber { get; set; }
    public string StreetAddress { get; set; }
    public string ZipCode { get; set; }
    public string City { get; set; }
    public long CustomerNumber { get; set; }
    public DateTime Created { get; set; }
    }
}
