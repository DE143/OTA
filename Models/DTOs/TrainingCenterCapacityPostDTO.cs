using System.ComponentModel.DataAnnotations;

namespace OTA_Portal_Service.Models.DTOs
{
    public class TrainingCenterCapacityPostDTO
    {
        public Guid Id { get; set; }
        public string TrainingCenterName { get; set; }
        public string TrainingCenterNumber { get; set; }
        public string TrainingCategory { get; set; }
        public DateTime? CreatedDate { get; set; }

        public bool IsActive { get; set; }
    }
    public class TrainingCenterCapacityGetDTO : TrainingCenterCapacityPostDTO
    {
        [Required]
        public int TrainingCenterId { get; set; }

        [Required]
        public int TrainingCategoryId { get; set; }

        [StringLength(10)]
        public string CreatedById { get; set; } = null!;
    }
}
