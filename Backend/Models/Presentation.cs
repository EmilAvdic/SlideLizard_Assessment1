using System;

namespace slidelizardAssigment.Models
{
    public class Presentation
    {
        public string Name { get; set; } = string.Empty;
        public DateOnly FromDate { get; set; }
        public DateOnly ToDate { get; set; }
        public string Location { get; set; } = string.Empty;
    }
}
