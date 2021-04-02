using api_rest_test.Domain.Models.Enums;
using System;

namespace api_rest_test.Domain.Models
{
    public class Person
    {
        public int id { get; set; }
        public string id_number { get; set; }
        public string name { get; set; }
        public string firstLastName { get; set; }
        public string secondLastName { get; set; }
        public DateTime birthDate { get; set; }
        public float weight { get; set; }
        public float height { get; set; }
        public Gender gender { get; set; }
    }
}
