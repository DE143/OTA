using System.ComponentModel.DataAnnotations;

namespace OTA_Portal_Service.Models.Entities
{
    public class TrainingCenterCapacity
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int TrainingCenterId { get; set; }
        public virtual TrainingCenterList TrainingCenter { get; set; } = null!;
        [Required]
        public int TrainingCategoryId { get; set; }
        public virtual TrainingCategory TrainingCategory { get; set; } = null!;
    }
}
