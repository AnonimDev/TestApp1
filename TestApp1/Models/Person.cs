using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApp1.Models
{
    public class Person
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string last_name { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string first_name { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string middle_name { get; set; }

        public int age { get; set; }
    }
}
