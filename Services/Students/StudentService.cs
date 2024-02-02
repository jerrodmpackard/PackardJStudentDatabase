using PackardJStudentDatabase.Data;
using PackardJStudentDatabase.Models;

namespace PackardJStudentDatabase.Services.Students;

public class StudentService : IStudentService
{
    private readonly DataContext _db;

    public StudentService(DataContext db)
    {
        _db = db;
    }

    public List<Student> AddStudent(string firstName, string lastName, string hobby)
    {
        Student newStudent = new();
        newStudent.FirstName = firstName;
        newStudent.LastName = lastName;
        newStudent.Hobby = hobby;

        _db.Students.Add(newStudent);
        _db.SaveChanges();

        return _db.Students.ToList();
    }

    public List<Student> DeleteStudent(string firstName)
    {
        var student = _db.Students.FirstOrDefault(foundStudent => foundStudent.FirstName == firstName);

        if (student != null)
        {
            _db.Students.Remove(student);
            _db.SaveChanges();
        }

        return _db.Students.ToList();
    }

    public List<Student> GetStudents()
    {
        return _db.Students.ToList();
    }
}
