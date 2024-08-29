using System.ComponentModel.DataAnnotations;

namespace TechTest_BCICentral.CustomValidation
{
    public class StagedValueRequirementAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            List<string> accOptions = ["Concept", "Design & Documentation", "Pre-Construction", "Construction"];
            return value != null && !string.IsNullOrEmpty(value.ToString()) && accOptions.Contains(value.ToString());
        }
    }
}
