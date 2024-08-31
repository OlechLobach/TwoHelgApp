using System;

namespace MyApp.Models
{
    public class Job
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string JobTitle { get; set; }

        public string JobType { get; set; }

        public DateTime EffectiveDate { get; set; }
    }
}