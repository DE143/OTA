using System.ComponentModel.DataAnnotations;

namespace OTA_Portal_Service.Models.Entities
{
    public class ZoneList
    {
        [Key]
        public int ZoneId { get; set; }
        public int RegionId { get; set; }
        public virtual Region Region { get; set; } = null!;
        [StringLength(10)]
        public string Name { get; set; } = null!;
        [StringLength(15)]
        public string LocalName { get; set; } = null!;
        [StringLength(5)]
        public string Code { get; set; } = null!;
        [StringLength(5)]
        public string LocalCode { get; set; } = null!;
        [StringLength(10)]
        public string Seffix { get; set; } = null!;
        [StringLength(10)]
        public string LocalSuffix { get; set; } = null!;
        public bool IsCity { get; set; }
    }
}
