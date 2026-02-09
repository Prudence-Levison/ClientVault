using System.ComponentModel.DataAnnotations;
namespace adonetdatabase.Models;


public class User
{
    public int Id { get; set; }
    [Required (ErrorMessage = "Name is Required")]
    public string? Name { get; set; }
    public string? Gender { get; set; }
    [Required (ErrorMessage ="Age is Required")]
    [Range (1,120, ErrorMessage = "Age must be 1 and 120")]
    public int Age { get; set; }
    [Required (ErrorMessage = "Email is Required")]
    [EmailAddress (ErrorMessage = "Invalid Email Address")]
    public string? Email  { get; set; }
   
   
}
