using System.ComponentModel.DataAnnotations;

namespace MyApp.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Location { get; set; }

        public decimal? CurrentSalary { get; set; }

        public decimal? DesiredSalary { get; set; }

        public string CurrentJob { get; set; }

        public string DesiredJob { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}