using Microsoft.AspNetCore.Mvc;
using SimulationV2.Database.Repositories;
using SimulationV2.Database.ViewModels;
using SimulationV2.Helpers.Extentions;

namespace SimulationV2.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminDashboardController : Controller
{
    private readonly TeacherRepository _teacherRepository;

    public AdminDashboardController(TeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var teachers = _teacherRepository.GetAll();
        return View(teachers);
    }

    #region Create
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(TeacherViewModel teacher)
    {
        if (!ModelState.IsValid) return View(teacher);
        _teacherRepository.Insert(teacher);
        return RedirectToAction(nameof(Index));
    }
    #endregion

    #region Update
    [HttpGet]
    public IActionResult Update(int? id)
    {
        var existTeacher = _teacherRepository.GetById(id);
        if (existTeacher is null) return BadRequest();

        var teamMember = new TeacherViewModel
        {
            Name = existTeacher.Name,
            Surname = existTeacher.Surname,
            Description = existTeacher.Description,
            ImageUrl = existTeacher.ImageUrl,
        };
        return View(teamMember);  
    }

    [HttpPost]
    public IActionResult Update(int? id, TeacherViewModel teacher)
    {
        if (!ModelState.IsValid) return View(teacher);
        _teacherRepository.Update(id, teacher);
        return RedirectToAction(nameof(Index));
    }
    #endregion

    #region Delete
    [HttpGet]
    public IActionResult Delete(int? id)
    {
        _teacherRepository.Delete(id);
        return RedirectToAction(nameof(Index));
    }
    #endregion
}
