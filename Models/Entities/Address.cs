using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using static OTA_Portal_Service.Models.DTOs.DriverEnums;

namespace OTA_Portal_Service.Models.Entities
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid ParentId { get; set; }
        [Required]
        public AddressType AddressType { get; set; }


        public int? CountryId { get; set; }
        public virtual Country Country { get; set; }


        public int? RegionId { get; set; }
        public virtual Region Region { get; set; }


        public int? ZoneId { get; set; }
        public virtual ZoneList Zone { get; set; }


        public int? WoredaId { get; set; }
        public virtual Woreda Woreda { get; set; }


        public string? Kebele { get; set; }
        public string? Town { get; set; }
        public string? SpecificLocation { get; set; }

        [Required, StringLength(30)]
        public string HouseNo { get; set; } = null!;


        [Required, StringLength(30)]
        public string MobilePhoneNumber { get; set; } = null!;

        [StringLength(30)]
        public string? HomePhoneNumber { get; set; }

        [StringLength(30)]
        public string? OfficePhoneNumber { get; set; } = null!;
        [StringLength(30)]
        public string? Fax { get; set; }
        [StringLength(30)]
        public string? PoBox { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        [StringLength(30)]
        public string? Email { get; set; }
    }
}
