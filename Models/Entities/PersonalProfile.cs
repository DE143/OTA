using System.ComponentModel.DataAnnotations;
using System.Reflection;
using static OTA_Portal_Service.Models.DTOs.DriverEnums;
using static OTA_Portal_Service.Models.DTOs.Enum;

namespace OTA_Portal_Service.Models.Entities
{
    public class PersonalProfile
    {
        [Key]
        public Guid Id { get; set; }
        public Title Title { get; set; }

        [Required, StringLength(15)]
        public string FirstName { get; set; } = null!;

        [Required, StringLength(15)]
        public string MiddleName { get; set; } = null!;

        [Required, StringLength(15)]
        public string LastName { get; set; } = null!;

        [Required, StringLength(15)]
        public string AmharicName { get; set; } = null!;

        [Required, StringLength(15)]
        public string AmharicMiddleName { get; set; } = null!;

        [Required, StringLength(15)]
        public string AmharicLastName { get; set; } = null!;

        public string MotherFirstName { get; set; } = null!;
        [Required, StringLength(15)]
        public string MotherMiddleName { get; set; } = null!;
        [Required, StringLength(15)]
        public string MotherLastName { get; set; } = null!;
        [Required, StringLength(15)]
        public string AmharicMotherFirstName { get; set; } = null!;
        [Required, StringLength(15)]
        public string AmharicMotherMiddleName { get; set; } = null!;
        [Required, StringLength(15)]
        public string AmharicMotherLastName { get; set; } = null!;

        [Required]
        public string Gender { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string IdNumber { get; set; } = null!;

        [Required]
        public int EducationalLevelId { get; set; }

        [Required]
        public BloodType BloodType { get; set; }

        [Required]
        public string Occupation { get; set; } = null!;

        public string? ResponsiblePerson { get; set; } = null!;

        public string? ResponsiblePersonMobile { get; set; } = null!;

        public string? ResponsibleIdNo { get; set; } = null!;

        //[Required]
        public string NationalId { get; set; } = null!;

        //[Required]
        public int FingerPrintId { get; set; }

        //[Required]
        public string RegistrationNo { get; set; } = null!;

    }
}
