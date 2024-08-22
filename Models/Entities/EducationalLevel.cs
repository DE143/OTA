using System.ComponentModel.DataAnnotations;

namespace OTA_Portal_Service.Models.Entities
{
    public class EducationalLevel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;

     
        public string LocalName { get; set; } = null!;
        [Required]
        public int Order { get; set; }
    }
}
