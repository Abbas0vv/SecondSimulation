using SimulationV2.Database.Interfaces;
using SimulationV2.Database.Models;
using SimulationV2.Database.ViewModels;
using SimulationV2.Helpers.Extentions;

namespace SimulationV2.Database.Repositories;

public class TeacherRepository : ITeacherRepository
{
    private readonly AppDbContext _context;
    private readonly IWebHostEnvironment _environment;
    const string FOLDER_NAME = "uploads/teacherImage";

    public TeacherRepository(AppDbContext context, IWebHostEnvironment environment)
    {
        _context = context;
        _environment = environment;
    }

    public List<Teacher> GetAll()
    {
        return _context.Teachers.ToList();
    }

    public Teacher GetById(int? teacherId)
    {
        return _context.Teachers.FirstOrDefault(t => t.Id == teacherId);
    }

    public void Insert(TeacherViewModel teacher)
    {
        if (teacher.File.IsValidFile()) return;

        Teacher newTeacher = new Teacher()
        {
            Name = teacher.Name,
            Surname = teacher.Surname,
            Description = teacher.Description,
            ImageUrl = teacher.File.CreateFile(_environment.WebRootPath, FOLDER_NAME)
        };

        _context.Teachers.Add(newTeacher);
        _context.SaveChanges();
    }

    public void Update(int? id, TeacherViewModel teacher)
    {
        if (!teacher.File.IsValidFile()) return;


        var existTeacher = GetById(id);
        existTeacher.Name = teacher.Name;
        existTeacher.Surname = teacher.Surname;
        existTeacher.Description = teacher.Description;
        existTeacher.ImageUrl = teacher.ImageUrl;
        existTeacher.ImageUrl = teacher.File.UpdateFile(_environment.WebRootPath, FOLDER_NAME, existTeacher.ImageUrl);
    }

    public void Delete(int? teacherId)
    {
        var teacher = GetById(teacherId);
        FileExtention.RemoveFile(_environment.WebRootPath, FOLDER_NAME, teacher.ImageUrl);
        _context.Teachers.Remove(teacher);
        _context.SaveChanges();

    }

}
