using System;

namespace MyApp.Models
{
    public class Salary
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public decimal SalaryAmount { get; set; }

        public string SalaryType { get; set; } 

        public DateTime EffectiveDate { get; set; }
    }
}