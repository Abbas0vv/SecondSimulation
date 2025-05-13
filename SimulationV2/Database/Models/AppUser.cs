using Microsoft.AspNetCore.Identity;

namespace SimulationV2.Database.Models;

public class AppUser : IdentityUser
{
    public string Name { get; set; }

    public string Surname { get; set; }
}
