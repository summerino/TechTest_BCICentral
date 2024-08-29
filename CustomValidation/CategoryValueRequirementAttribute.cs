using System.ComponentModel.DataAnnotations;

namespace TechTest_BCICentral.CustomValidation
{
    public class CategoryValueRequirementAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            List<string> accOptions = ["Education", "Health", "Office", "Others"];
            return value != null && !string.IsNullOrEmpty(value.ToString()) && (accOptions.Contains(value.ToString()) || accOptions.Contains(value.ToString()[..6]));
        }
    }
}
