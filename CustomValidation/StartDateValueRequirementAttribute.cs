using System.ComponentModel.DataAnnotations;
using TechTest_BCICentral.Models;

namespace TechTest_BCICentral.CustomValidation
{
    public class StartDateValueRequirementAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var project = (ConstructionProject)validationContext.ObjectInstance;

            if (project.ProjectStage == "Concept" ||
                project.ProjectStage == "Design & Documentation" ||
                project.ProjectStage == "Pre-Construction")
            {
                if (value is DateTime date && date <= DateTime.Now)
                {
                    return new ValidationResult("Construction Start Date must be a future date for the selected stage.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
