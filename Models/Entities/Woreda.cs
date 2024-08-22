using System.ComponentModel.DataAnnotations;

namespace OTA_Portal_Service.Models.Entities
{
    public class Woreda
    {
        [Key]
        public int Id { get; set; }
        public int ZoneId { get; set; }
        public virtual ZoneList Zone { get; set; } = null!;

        [StringLength(10)]
        public string Name { get; set; } = null!;
        [StringLength(15)]
        public string LocalName { get; set; } = null!;
        [StringLength(5)]
        public string Code { get; set; } = null!;
        [StringLength(5)]
        public string LocalCode { get; set; } = null!;
    }
}
