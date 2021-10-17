using System.Collections.Generic;
using Models;

namespace Repositories
{
    public static class StudentsRepo
    {
        public static List<Student> StudentsList = new List<Student>(){
            new Student(){ ID = "LO611462", Name = "Alex", Faculty = "AC", Year = 4},
            new Student(){ ID = "LO613003", Name = "Marius", Faculty = "AC", Year = 2},
            new Student(){ ID = "LO611451", Name = "George", Faculty = "AC", Year = 4},
            new Student(){ ID = "LO612113", Name = "Maria", Faculty = "AC", Year = 3},
            new Student(){ ID = "LO613434", Name = "Ana", Faculty = "AC", Year = 1},
            new Student(){ ID = "LO613364", Name = "Marcel", Faculty = "AC", Year = 1}
        };
    }
}