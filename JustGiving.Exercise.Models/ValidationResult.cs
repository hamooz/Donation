using System.Collections.Generic;

namespace JustGiving.Exercise.Models
{
    public class ValidationResult
    {
        public List<string> ErrorList { get; set; }
        public bool IsValid { get; set; }
    }
}