using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace OTA_Portal_Service.Models.Entities
{
    public class TrainingCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int GroupId { get; set; }
        //public virtual Group Group { get; set; } = null!;
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string LocalName { get; set; } = null!;
        [Required]
        public string Code { get; set; } = null!;
        [Required]
        public string LocalCode { get; set; } = null!;
        [Required]
        public int MinimumAge { get; set; }
        [Required]
        public int EducationLevelId { get; set; }
        public virtual EducationalLevel EducationLevel { get; set; } = null!;
        [Required]
        public int CapacityPerTraining { get; set; }
        [Required]
        public int NoOfTrainingDays { get; set; }
        [Required]
        public int NoOfTrainingDaysAdd { get; set; }
        [Required]
        public int NoOfTrainingDaysUpgrade { get; set; }
        [Required]
        public int PreRequisitYear { get; set; }
        [Required]
        public int Sequence { get; set; }
    }
}
