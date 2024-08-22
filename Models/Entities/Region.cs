using System.ComponentModel.DataAnnotations;

namespace OTA_Portal_Service.Models.Entities
{
    public class Region
    {
        [Key]
        public int RegionId { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; } = null!;

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
