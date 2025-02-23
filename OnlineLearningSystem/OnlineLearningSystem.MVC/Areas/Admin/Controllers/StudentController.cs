using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineLearning.BL.Exceptions;
using OnlineLearning.BL.Services.Abstractions;

namespace OnlineLearningSystem.MVC.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class StudentController : Controller
{
    private readonly IStudentService _service;
    private readonly ICourseService _courseService;

    public StudentController(IStudentService service, ICourseService courseService)
    {
        _service = service;
        _courseService = courseService;
    }

    public async Task<IActionResult> Index()
    {
        var students = await _service.GetStudentListItemsAsync();
        return View(students);
    }

    public async Task<IActionResult> Create()
    {
        ViewData["Courses"] = new SelectList(await _courseService.GetCourseListItemsAsync(), "Id", "CourseName");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(StudentCreateDTO dto)
    {
        if (!ModelState.IsValid)
        {
            ViewData["Courses"] = new SelectList(await _courseService.GetCourseListItemsAsync(), "Id", "CourseName");
            return View(dto);
        }

        try
        {
            await _service.CreateAsync(dto); 
            await _service.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        catch (BaseException ex)
        {
            ViewData["Courses"] = new SelectList(await _courseService.GetCourseListItemsAsync(), "Id", "CourseName");
            ModelState.AddModelError("", ex.Message);
        }
        catch (Exception)
        {
            ViewData["Courses"] = new SelectList(await _courseService.GetCourseListItemsAsync(), "Id", "CourseName");
            ModelState.AddModelError("", "Gözlənilməz bir xəta baş verdi!");
        }


        return View(dto);
    }

    public async Task<IActionResult> Update(int id)
    {
        try
        {
            ViewData["Courses"] = new SelectList(await _courseService.GetCourseListItemsAsync(), "Id", "CourseName");

            return View(await _service.GetByIdForUpdateAsync(id));
        }
        catch (NotFoundException)
        {
            return NotFound("Tələbə tapılmadı.");
        }
        catch (Exception)
        {
            return BadRequest("Gözlənilməz bir xəta baş verdi!");
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(StudentUpdateDTO dto)
    {
        if (!ModelState.IsValid)
        {
            ViewData["Courses"] = new SelectList(await _courseService.GetCourseListItemsAsync(), "Id", "CourseName");
            return View(dto);
        }

        try
        {
            await _service.UpdateAsync(dto);
            await _service.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        catch (BaseException ex)
        {

            ViewData["Courses"] = new SelectList(await _courseService.GetCourseListItemsAsync(), "Id", "CourseName");
            ModelState.AddModelError("", ex.Message);
        }
        catch (Exception)
        {
            ViewData["Courses"] = new SelectList(await _courseService.GetCourseListItemsAsync(), "Id", "CourseName");
            ModelState.AddModelError("", "Gözlənilməz bir xəta baş verdi!");
        }

        return View(dto);
    }

    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _service.DeleteAsync(id);
            await _service.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        catch (NotFoundException)
        {
            return NotFound("Tələbə tapılmadı.");
        }
        catch (BaseException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return BadRequest("Gözlənilməz bir xəta baş verdi!");
        }
    }

    public async Task<IActionResult> Details(int id)
    {
        try
        {
            var student = await _service.GetByIdWithChildrenAsync(id);
            return View(student);
        }
        catch (NotFoundException)
        {
            return NotFound("Tələbə tapılmadı.");
        }
        catch (Exception)
        {
            return BadRequest("Gözlənilməz bir xəta baş verdi!");
        }
    }
}
