using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAPI.Model
{
    public class Student
    {
        [Key]

        public int StudentId { get; set; }

        [Column(TypeName = "nvarchar(100)")]

        public string StudentName { get; set; }

        [Column(TypeName = "nvarchar(15)")]

        public string DateOfBirth { get; set; }

        [Column(TypeName = "nvarchar(7)")]

        public string Gender { get; set; }

    }
}
