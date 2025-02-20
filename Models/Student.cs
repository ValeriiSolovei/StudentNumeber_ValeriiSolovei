using System.ComponentModel.DataAnnotations;

namespace YourProjectName.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [EmailAddress]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
    }
}
