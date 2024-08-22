using static OTA_Portal_Service.Models.DTOs.DriverEnums;
using System.ComponentModel.DataAnnotations;

namespace OTA_Portal_Service.Models.Entities
{
    public class Trainee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid PersonId { get; set; }
        public virtual PersonalProfile Person { get; set; } = null!;
        [Required]
        public TraineeStatus TraineeStatus { get; set; }
        //[StringLength(ValidationClasses.UserId)]
        public string? CreatedBy { get; set; }
        //public virtual ApplicationUser ApprovedBy { get; set; } = null!;
        public DateTime? ApprovedDate { get; set; }
        [Required]
        public int TrainingCategoryId { get; set; }
        public virtual TrainingCategory TrainingCategory { get; set; } = null!;
        [Required]
        public Guid BatchId { get; set; }
        public virtual Batch Batch { get; set; } = null!;
        //[Required]
        //public Guid VehicleId { get; set; }
        //public virtual VehicleList Vehicle { get; set; } = null!;
        public bool IsActive { get; set; }
        [Required]
        public QuestionLanguage Language { get; set; }
    }
}
