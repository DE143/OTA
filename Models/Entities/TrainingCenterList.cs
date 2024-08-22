using System.ComponentModel.DataAnnotations;

namespace OTA_Portal_Service.Models.Entities
{
    public class TrainingCenterList
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TrainingCenterNumber { get; set; } = null!;

        [Required, ]
        public string Name { get; set; } = null!;
        [Required, ]
        public string LocalName { get; set; } = null!;
        [Required]
        public int ServiceZoneId { get; set; }
        public virtual ZoneList ServiceZone { get; set; } = null!;
        [Required, ]
        public string TinNumber { get; set; } = null!;     
        public string? LogoPath { get; set; }

        public string? Longtuide { get; set; }


        public string? Remark { get; set; }

        public string? Latitiude { get; set; }
    }
}
