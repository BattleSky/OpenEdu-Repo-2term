using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ_Practice
{
    class CompoundCollections
    {
        // Класс определен так
        public class Classroom
        {
            public List<string> Students = new List<string>();
        }
        // Решение без использования LINQ

        //public static string[] GetAllStudents(Classroom[] classes)
        //{
        //    var allStudents = new List<string>();
        //    foreach (var classroom in classes)
        //    {
        //        foreach (var student in classroom.Students)
        //        {
        //            allStudents.Add(student);
        //        }
        //    }
        //    return allStudents.ToArray();
        //}

        public static string[] GetAllStudents(Classroom[] classes)
        {
            return classes
                .SelectMany(classroom => classroom.Students)
                .ToArray();
        }

        public static void MainX()
        {
            Classroom[] classes =
            {
                new Classroom {Students = {"Pavel", "Ivan", "Petr"},},
                new Classroom {Students = {"Anna", "Ilya", "Vladimir"},},
                new Classroom {Students = {"Bulat", "Alex", "Galina"},}
            };
            var allStudents = GetAllStudents(classes);
            Array.Sort(allStudents);
            Console.WriteLine(string.Join(" ", allStudents));
        }

    }
}
