using SimulationV2.Database.Models;
using SimulationV2.Database.ViewModels;
namespace SimulationV2.Database.Interfaces;

public interface ITeacherRepository
{
    List<Teacher> GetAll();
    Teacher GetById(int? teacherId);
    void Insert(TeacherViewModel teacher);
    void Update(int? id, TeacherViewModel teacher);
    void Delete(int? teacherId);
}
