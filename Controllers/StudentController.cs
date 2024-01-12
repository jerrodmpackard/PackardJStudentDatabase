using Microsoft.AspNetCore.Mvc;
using PackardJStudentDatabase.Models;
using PackardJStudentDatabase.Services.Students;

namespace PackardJStudentDatabase.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : Controller
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    [Route("GetStudents")]
    public List<Student> GetStudents()
    {
        return _studentService.GetStudents();
    }

    [HttpPost]
    [Route("AddStudent/{firstName}/{lastName}/{hobby}")]
    public List<Student> AddStudent(string firstName, string lastName, string hobby)
    {
        return _studentService.AddStudent(firstName, lastName, hobby);
    }

    [HttpDelete]
    [Route("DeleteStudent/{firstName}/{lastName}/{hobby}")]
    public List<Student> DeleteStudent(string firstName, string lastName, string hobby)
    {
        return _studentService.DeleteStudent(firstName, lastName, hobby);
    }
}
