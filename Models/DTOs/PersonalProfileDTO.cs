using System.ComponentModel.DataAnnotations;
using System.Reflection;
using OTA_Portal_Service.Models.DTOs;
using static OTA_Portal_Service.Models.DTOs.Enum;
using static OTA_Portal_Service.Models.DTOs.PersonalProfileDTO;
using static OTA_Portal_Service.Models.DTOs.DriverEnums;

namespace OTA_Portal_Service.Models.DTOs
{
    public class PersonalProfileDTO
    {

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
        [Required, StringLength(15)]
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

        [Required]
        public string ResponsiblePerson { get; set; } = null!;

        [Required]
        public string ResponsiblePersonMobile { get; set; } = null!;

        [Required]
        public string NationalId { get; set; } = null!;

        [StringLength(450)]
        public string CreatedById { get; set; } = null!;
        public bool IsActive { get; set; }
    }


    public class PersonalProfilePostDTO :PersonalProfileDTO
    {
        public PersonalAddressPostDTO Address { get; set; }
        public TrainingCenterCapacityGetDTO TrainingCenterCapacity { get; set; }
       public TraineePostDTO Trainee { get; set; }
    }
    public record PersonalProfileGetDTO 
    {
        public Title Title { get; set; }

  
        public string FirstName { get; set; } = null!;


        public string MiddleName { get; set; } = null!;

        public string LastName { get; set; } = null!;

   
        public string AmharicName { get; set; } = null!;

    
        public string AmharicMiddleName { get; set; } = null!;


        public string AmharicLastName { get; set; } = null!;
     
        public string MotherFirstName { get; set; } = null!;
 
        public string MotherMiddleName { get; set; } = null!;
    
        public string MotherLastName { get; set; } = null!;
     
        public string AmharicMotherFirstName { get; set; } = null!;
     
        public string AmharicMotherMiddleName { get; set; } = null!;
 
        public string AmharicMotherLastName { get; set; } = null!;

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }


        public string IdNumber { get; set; } = null!;


        public int EducationalLevelId { get; set; }


        public BloodType BloodType { get; set; }

        public string Occupation { get; set; } = null!;

        public string ResponsiblePerson { get; set; } = null!;

        public string ResponsiblePersonMobile { get; set; } = null!;


        public string NationalId { get; set; } = null!;

        [StringLength(450)]
        public string CreatedById { get; set; } = null!;
        public bool IsActive { get; set; }
        public List<PersonalAddressGetDTO> PersonalAddresses { get; set; }

    }

    public record PersonalAddressPostDTO
    {

        public int CountryId { get; set; }
        public int RegionId { get; set; }
        public int ZoneId { get; set; }
        public int WoredaId { get; set; }
        [Required]
        public string Kebele { get; set; } = null!;
        [Required, StringLength(10)]
        public string HouseNo { get; set; } = null!;
        [Required, StringLength(10)]
        public string MobilePhoneNumber { get; set; } = null!;

        [StringLength(10)]
        public string HomePhoneNumber { get; set; } = null!;

        [StringLength(10)]
        public string OfficePhoneNumber { get; set; } = null!;
        public string Fax { get; set; } = null!;
        public string PoBox { get; set; } = null!;
        public string Email { get; set; } = null!;
    }

    public record PersonalAddressGetDTO
    {


    }


}
