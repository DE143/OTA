using Microsoft.EntityFrameworkCore;
using OTA_Portal_Service.DataBaseContext;
using OTA_Portal_Service.Models.DTOs;
using OTA_Portal_Service.Models.Entities;
using OTA_Portal_Service.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace OTA_Portal_Service.Services.Implimentations
{
    public class TraineeService: ITraineeService
    {
        private readonly HomeDbContext _homeDbContext;
        public TraineeService(HomeDbContext homeDbContext) 
        { 
        _homeDbContext = homeDbContext;
        }
        public async Task<ResponseDto> AddTrainee(PersonalProfilePostDTO personalProfilePostDTO)
        {
            try
            {
                if (personalProfilePostDTO == null)
                {
                    return new ResponseDto
                    {
                        isSuccess = false,
                        message = "The DTO is null"
                    };
                }
                var trainingCenter = await _homeDbContext.trainingCenterLists                    
      .Where(x => x.Id == personalProfilePostDTO.TrainingCenterCapacity.TrainingCenterId).ToListAsync();
                if (trainingCenter!= null) {
                    var trainingCatagory = await _homeDbContext.trainingCenterCapacities
                        .Include(x=>x.TrainingCategory)
                        .Include(y=>y.TrainingCenter)
                        .Where(x=>x.TrainingCategoryId==personalProfilePostDTO.TrainingCenterCapacity.TrainingCategoryId && x.TrainingCenterId==personalProfilePostDTO.TrainingCenterCapacity.TrainingCenterId).ToListAsync();
                    if (trainingCatagory.Any() && trainingCatagory[0].TrainingCategory.CapacityPerTraining<=0)
                    {
                        bool isPersonExists = await _homeDbContext.personalProfiles
                               .AnyAsync(x =>x.MotherFirstName == personalProfilePostDTO.MotherFirstName);

                        if (isPersonExists)
                        {
                            return new ResponseDto
                            {
                                isSuccess = false,
                                message = "The person already exists"
                            };
                        }

                        var newPerson = new PersonalProfile
                        {
                            Title = personalProfilePostDTO.Title,
                            FirstName = personalProfilePostDTO.FirstName,
                            MiddleName = personalProfilePostDTO.MiddleName,
                            LastName = personalProfilePostDTO.LastName,
                            AmharicName = personalProfilePostDTO.AmharicName,
                            AmharicMiddleName = personalProfilePostDTO.AmharicMiddleName,
                            AmharicLastName = personalProfilePostDTO.AmharicLastName,
                            MotherFirstName = personalProfilePostDTO.MotherFirstName,
                            MotherMiddleName = personalProfilePostDTO.MotherMiddleName,
                            MotherLastName = personalProfilePostDTO.MotherLastName,
                            AmharicMotherFirstName = personalProfilePostDTO.AmharicMotherFirstName,
                            AmharicMotherMiddleName = personalProfilePostDTO.AmharicMotherMiddleName,
                            AmharicMotherLastName = personalProfilePostDTO.AmharicMotherLastName,
                            Gender = personalProfilePostDTO.Gender,
                            DateOfBirth = personalProfilePostDTO.DateOfBirth,
                            IdNumber = personalProfilePostDTO.IdNumber,
                            EducationalLevelId = personalProfilePostDTO.EducationalLevelId,
                            BloodType = personalProfilePostDTO.BloodType,
                            Occupation = personalProfilePostDTO.Occupation,
                            ResponsiblePerson = personalProfilePostDTO.ResponsiblePerson,
                            ResponsiblePersonMobile = personalProfilePostDTO.ResponsiblePersonMobile,
                            NationalId = personalProfilePostDTO.NationalId,
                            RegistrationNo = "fdjgfjghfdjgfdgfdgfdh", // Consider replacing with actual logic
                            FingerPrintId = 101221221 // Consider replacing with actual logic
                        };

                        await _homeDbContext.personalProfiles.AddAsync(newPerson);
                        var personAdress = new Address
                        {
                            ParentId = newPerson.Id,
                            AddressType = DriverEnums.AddressType.Person,
                            CountryId = personalProfilePostDTO.Address.CountryId,
                            RegionId = personalProfilePostDTO.Address.RegionId,
                            ZoneId = personalProfilePostDTO.Address.ZoneId,
                            WoredaId = personalProfilePostDTO.Address.WoredaId,
                            Kebele = personalProfilePostDTO.Address.Kebele,
                            HouseNo = personalProfilePostDTO.Address.HouseNo,
                            MobilePhoneNumber = personalProfilePostDTO.Address.MobilePhoneNumber,
                            HomePhoneNumber = personalProfilePostDTO.Address.HomePhoneNumber,
                            OfficePhoneNumber = personalProfilePostDTO.Address.OfficePhoneNumber,
                            Fax = personalProfilePostDTO.Address.Fax,
                            PoBox = personalProfilePostDTO.Address.PoBox,
                            Email = personalProfilePostDTO.Address.Email,



                        };
                        await _homeDbContext.addresses.AddAsync(personAdress);
                        //await _homeDbContext.SaveChangesAsync();



                        var dataTrainee = new Trainee
                        {

                            //Id = Guid.NewGuid(),
                            PersonId = newPerson.Id,
                            BatchId = personalProfilePostDTO.Trainee.BatchId,
                            //VehicleId = personalProfilePostDTO.Trainee.VehicleId,
                            TraineeStatus = personalProfilePostDTO.Trainee.TraineeStatus,
                            Language = personalProfilePostDTO.Trainee.Language,
                            TrainingCategoryId = personalProfilePostDTO.Trainee.TrainingCategoryId,
                            CreatedBy = personalProfilePostDTO.Trainee.CreatedById,
                            //CreatedById = personalProfilePostDTO.Trainee.CreatedById,
                            IsActive = true



                        };
                        await _homeDbContext.trainees.AddAsync(dataTrainee);
                        return new ResponseDto
                        {
                            isSuccess = true,
                            message = "Successfully applied"
                        };
                    }
                    else
                    {
                        return new ResponseDto
                        {
                            isSuccess = false,
                            message = "the training capcity is full"
                        };
                    }
                }
                else
                {
                    return new ResponseDto { isSuccess = false, message = "the trianing center is not foubd" };
                }
                

            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    isSuccess = false,
                    message = ex.Message,
                };
            }
        }

        //public async Task<ResponseDto> AddTraineeAddress(PersonalAddressPostDTO personalAddressPostDTO)
        //{
           

        //    try
        //    {
        //        if (personalAddressPostDTO == null)
        //        {
        //            return new ResponseDto
        //            {
        //                isSuccess = false,
        //                message = "the Dto is null"
        //            };            
        //        }

        //        var addAdress = new Address
        //        {
        //            CountryId=personalAddressPostDTO.CountryId,
        //            RegionId=personalAddressPostDTO.RegionId,
        //            ZoneId=personalAddressPostDTO.ZoneId,
        //            WoredaId=personalAddressPostDTO.WoredaId,
        //            Kebele=personalAddressPostDTO.Kebele,
        //            HouseNo=personalAddressPostDTO.HouseNo,
        //            MobilePhoneNumber=personalAddressPostDTO.MobilePhoneNumber,
        //            HomePhoneNumber=personalAddressPostDTO.HomePhoneNumber,
        //            OfficePhoneNumber=personalAddressPostDTO.OfficePhoneNumber,
        //            Fax=personalAddressPostDTO.Fax,
        //            PoBox=personalAddressPostDTO.PoBox,
        //            Email=personalAddressPostDTO.Email
        //        };
        //        await _homeDbContext.addresses.AddAsync(addAdress);
        //        await _homeDbContext.SaveChangesAsync();
        //        return new ResponseDto
        //        {
        //            isSuccess = true,
        //            message = "succesfully add the adress"
        //        };

        //    }catch(Exception ex)
        //    {
        //        return new ResponseDto
        //        {
        //            isSuccess = false,
        //            message = ex.Message
        //        };
        //    }



        //}

    }
}
