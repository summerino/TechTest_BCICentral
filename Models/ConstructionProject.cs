using System.ComponentModel.DataAnnotations;
using TechTest_BCICentral.CustomValidation;

namespace TechTest_BCICentral.Models
{
    public class ConstructionProject
    {
        [Key]
        [Required(ErrorMessage = "Project ID is required.")]
        [MaxLength(6)]
        public string ProjectId { get; set; }
        [Required(ErrorMessage = "Project Name is required.")]
        [MaxLength(200, ErrorMessage = "Project Name cannot exceed 200 characters.")]
        public string ProjectName { get; set; }
        [Required(ErrorMessage = "Project Location is required.")]
        [MaxLength(500, ErrorMessage = "Project Location cannot exceed 500 characters.")]
        public string ProjectLocation { get; set; }
        [Required(ErrorMessage = "Project Stage is required.")]
        [StagedValueRequirement]
        public string ProjectStage { get; set; }
        [Required(ErrorMessage = "Project Category is required.")]
        [CategoryValueRequirement]
        public string ProjectCategory { get; set; }
        [Required(ErrorMessage = "Construction Start Date is required.")]
        [DataType(DataType.Date)]
        [StartDateValueRequirement]
        public DateTime ProjectConstructionStartDate { get; set; }
        [Required(ErrorMessage = "Project Details are required.")]
        [MaxLength(2000, ErrorMessage = "Project Details cannot exceed 2000 characters.")]
        public string ProjectDetails { get; set; }
        [Required(ErrorMessage = "Project Creator ID is required.")]
        public string ProjectCreatorId { get; set; }
    }
}
