using Lab9.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab9.ViewModels;

public class StudentIndexViewModel
{
    public string? Search { get; set; }
    public string? Address { get; set; }
    public int? CampusID { get; set; }
    public string? Sort { get; set; }
    public int Page { get; set; } = 1;
    [BindNever]
    public int TotalStudents { get; set; }
    [BindNever]
    public int TotalPages { get; set; }
    [BindNever]
    public IReadOnlyList<Student> Students { get; set; } = new List<Student>();
    [BindNever]
    public IReadOnlyList<CampusWithCount> CampusesWithCount { get; set; }
        = new List<CampusWithCount>();
    public IEnumerable<SelectListItem> CampusFilterItems =>
        CampusesWithCount.Select(campus => new SelectListItem
        {
            Value = campus.CampusID.ToString(),
            Text = $"{campus.CampusName} ({campus.StudentCount})"
        });
}

public class CampusWithCount
{
    public int CampusID { get; set; }
    public string CampusName { get; set; } = string.Empty;
    public int StudentCount { get; set; }
}
