namespace SimulationV2.Database.Models;

public class Teacher : BaseEntity
{
    public string Name { get; set; }

    public string Surname { get; set; }

    public string Description { get; set; }

    public string? ImageUrl { get; set; }
}
