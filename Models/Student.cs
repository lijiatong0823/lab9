using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Lab9.Models;

public class Student
{
    public int ID { get; set; }
    [Required(ErrorMessage = "Enter the student's name.")]
    [StringLength(100, ErrorMessage = "Use 100 characters or fewer for the name.")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "Enter the student's address.")]
    [StringLength(200, ErrorMessage = "Use 200 characters or fewer for the address.")]
    public string Address { get; set; } = string.Empty;
    [Range(1, int.MaxValue, ErrorMessage = "Choose a campus."), Display(Name = "Campus")]
    public int CampusID { get; set; }
    [ValidateNever]
    public UniversityCampus Campus { get; set; } = null!;
}
