using System.ComponentModel.DataAnnotations;
namespace SimulationV2.Database.ViewModels;

public class AppUserViewModel
{
    [MinLength(3)]
    public string Name { get; set; }
    [MinLength(3)]
    public string Surname { get; set; }
    public byte Age { get; set; }
    [MinLength(3)]
    public string Username { get; set; }
    [MinLength(5), DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [MinLength(8), DataType(DataType.Password)]
    public string Password { get; set; }
    [MinLength(8), DataType(DataType.Password), Compare(nameof(Password))]
    public string ConfirmPassword { get; set; }
}
