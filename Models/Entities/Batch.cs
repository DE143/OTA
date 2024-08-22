using static OTA_Portal_Service.Models.DTOs.DriverEnums;
using System.ComponentModel.DataAnnotations;

namespace OTA_Portal_Service.Models.Entities
{
    public class Batch
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public int TrainingCenterId { get; set; }
        public virtual TrainingCenterList TrainingCenter { get; set; } = null!;
        [Required]
        public int TrainingCategoryId { get; set; }
        public virtual TrainingCategory TrainingCategory { get; set; } = null!;
        [Required]
        public int BatchNo { get; set; }
        public DateTime? LetterDate { get; set; }
  
        public string? LetterNumber { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? EndDateAdd { get; set; }
        public DateTime? EndDateUpgrade { get; set; }
        [Required]
        public BatchStatus BatchStatus { get; set; }

    }
}
