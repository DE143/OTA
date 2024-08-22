using System.ComponentModel.DataAnnotations;

namespace OTA_Portal_Service.Models.Entities
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [StringLength(10)]
        public string Name { get; set; } = null!;
        [StringLength(15)]
        public string LocalName { get; set; } = null!;
        [StringLength(5)]
        public string CountryCode { get; set; } = null!;
        [StringLength(10)]
        public string NationalityName { get; set; } = null!;
        [StringLength(15)]
        public string LocalNationalityName { get; set; } = null!;
    }
}
