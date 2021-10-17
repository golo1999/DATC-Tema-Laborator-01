using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;

namespace DATC_Tema_Laborator_01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        public StudentsController() { }

        [HttpGet]
        public IEnumerable<Student> GetAllStudents()
        {
            List<Student> StudentsList = StudentsRepo.StudentsList;

            return StudentsList;
        }

        [HttpGet("{givenID}")]
        public Student GetStudentByID(string givenID)
        {
            List<Student> StudentsList = StudentsRepo.StudentsList;

            return StudentsList.Where(student => student.ID == givenID).First();
        }

        [HttpPost]
        public void AddStudent([FromBody] Student givenStudent)
        {
            List<Student> StudentsList = StudentsRepo.StudentsList;

            StudentsList.Add(givenStudent);
        }

        // not working in Postman
        [HttpPut]
        public void UpdateStudent([FromBody] Student updatedStudent)
        {
            List<Student> StudentsList = StudentsRepo.StudentsList;

            Student studentFromList = StudentsList.Where(student => student.ID == updatedStudent.ID).First();

            if (studentFromList != null)
            {
                studentFromList = updatedStudent;
            }
        }

        [HttpDelete("{givenID}")]
        public void RemoveStudent(string givenID)
        {
            List<Student> StudentsList = StudentsRepo.StudentsList;

            StudentsList.Remove(StudentsList.Where(student => student.ID == givenID).First());
        }
    }
}