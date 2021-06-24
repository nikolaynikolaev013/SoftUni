using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        List<Student> students;

        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.students = new List<Student>();
        }

        public int Capacity { get; set; }
        public int Count => students.Count;

        public string RegisterStudent(Student student)
        {
            if (Count < Capacity)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }

            return "No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            if (students.Any(x=>x.FirstName == firstName && x.LastName == lastName))
            {
                students.RemoveAll(x => x.FirstName == firstName && x.LastName == lastName);
                return $"Dismissed student {firstName} {lastName}";
            }

            return "Student not found";
        }

        public string GetSubjectInfo(string subject)
        {
            if (students.Any(x=>x.Subject == subject))
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine($"Students:");
                foreach (var student in students.Where(x=>x.Subject == subject))
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }
                return sb.ToString().TrimEnd();
            }

            return "No students enrolled for the subject";
        }

        public int GetStudentsCount()
        {
            return this.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        }
    }
}
