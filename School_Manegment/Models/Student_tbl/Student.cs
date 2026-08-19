using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations;

namespace School_Manegment.Models.Student_tbl
{
    public class Student : CommonField
    {
        [Key]
        public int Id { get; set; }
        public string? StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FatherName { get; set; }
        public string? PrentNumber{ get; set; }
        public string? Gender { get; set; }
        public string? Religion { get; set; }
        public int? EmergencyContact { get; set; }
        public string? BForm { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? WhatappNumber { get; set; }
        public string? Address { get; set; }
        public string? Picture { get; set; }
        public DateTime? AdmissionDate { get; set; }
        public bool IsWebLogin { get; set; }
    }
}
