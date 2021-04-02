using api_rest_test.Domain.Models.Enums;
using System;

namespace api_rest_test.Domain.Models
{
    public class Student{
        public int id { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public DateTime birthDate { get; set; }
        public Gender gender { get; set; }

        /*MIS CONSTRUCTORES*/
        public Student()
        {
            this.id = 0;
            this.name = "";
            this.lastName = "";
        }

        public Student(int id)
        {
            this.id = id;
            this.name = "";
            this.lastName = "";
        }

        public Student(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}