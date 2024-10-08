﻿using System.ComponentModel.DataAnnotations;
using WebAppDatabase.Models;

namespace WebAppDatabase.NewFolder1
{
    public class Student
    {
        public int StudentId { get; set; } // primární klíč
        // public int Id { get; set; }
        /*
        [Key]
        public int Klic { get; set; } 
        */

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        public int? ShoeSize { get; set; }
        public required int ClasroomId { get; set; }
        public Classroom? Classroom { get; set; }
        
    }
}
