using static OTA_Portal_Service.Models.DTOs.DriverEnums;
using System.ComponentModel.DataAnnotations;
using OTA_Portal_Service.Models.Entities;

namespace OTA_Portal_Service.Models.DTOs
{
    public class TraineePostDTO
    {
        [Required]
        public Guid PersonId { get; set; }
        [Required]
        public TraineeStatus TraineeStatus { get; set; }
        [Required]
        public int TrainingCategoryId { get; set; }
        [Required]
        public Guid BatchId { get; set; }
        //[Required]
        //public Guid VehicleId { get; set; }
        [Required]
        public QuestionLanguage Language { get; set; }

        [StringLength(450)]
        public string CreatedById { get; set; } = null!;
        public int ServiceZoneId { get; set; }
        public bool IsActive { get; set; }
    }
    public class TraineeGetDTO : TraineePostDTO
    {
        [Required]
        public Guid Id { get; set; }
        public DateTime? CreatedDate { get; set; }
      
        public string? AprovedById { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public virtual PersonalProfile Person { get; set; } = null!;
        public virtual TrainingCategory TrainingCategory { get; set; } = null!;
        public virtual Batch Batch { get; set; } = null!;
    }
}
