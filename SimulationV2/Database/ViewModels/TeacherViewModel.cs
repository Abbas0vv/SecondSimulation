using System.ComponentModel.DataAnnotations;

namespace SimulationV2.Database.ViewModels;

public class TeacherViewModel
{
    [MinLength(3)]
    public string Name { get; set; }

    [MinLength(3)]
    public string Surname { get; set; }

    [MinLength(5)]
    public string Description { get; set; }

    public string? ImageUrl { get; set; }

    public IFormFile? File { get; set; }
}
