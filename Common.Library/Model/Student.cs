using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Library.Model
{
    public class Student
    {

        public Guid GuidStudent { get; set; }
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Birthday { get; set; }

        public Student()
        {
            GuidStudent = Guid.NewGuid();
        }
        public Student(Guid GuidStudent, int StudentId, string Name, string Surname, string Birthday)
        {
            this.GuidStudent = GuidStudent;
            this.StudentId = StudentId;
            this.Name = Name;
            this.Surname = Surname;
            this.Birthday = Birthday;
        }

        public Student(int StudentId, string Name, string Surname, string Birthday)
        {
            GuidStudent = Guid.NewGuid();
            this.StudentId = StudentId;
            this.Name = Name;
            this.Surname = Surname;
            this.Birthday = Birthday;
        }

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   StudentId == student.StudentId &&
                   Name == student.Name &&
                   Surname == student.Surname &&
                   Birthday == student.Birthday;
        }

        public override int GetHashCode()
        {
            var hashCode = -387832195;
            hashCode = hashCode * -1521134295 + StudentId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Surname);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Birthday);
            return hashCode;
        }

        public override string ToString()
        {
            return string.Concat(GuidStudent.ToString(), ", ", StudentId, ", ", Name, ", ", Surname, ", ", Birthday);
        }
    }
}
