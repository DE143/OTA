using AutoMapper;
using IWPPage.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OTA_Portal_Service.DataBaseContext;
using OTA_Portal_Service.Models.DTOs;
using OTA_Portal_Service.Models.Entities;
using OTA_Portal_Service.Services.Interfaces;
namespace OTA_Portal_Service.Services.Implimentations
{
    public class RepositoryService : IRepositoryService
    {
        private readonly HomeDbContext _homeDbContext;
        private readonly IMapper _autoMapper;
        private readonly IHelperSrevice _helperSrevice;
        public RepositoryService(HomeDbContext homeDbContext, IMapper autoMapper, IHelperSrevice helperSrevice)
        {
            _homeDbContext = homeDbContext;
            _autoMapper = autoMapper;
            _helperSrevice = helperSrevice;

        }

        // About Slides
        public async Task<ResponseDto> AddSlide(SlidePostDtos slidePostDtos)
        {
            try
            {
                var Image = "";
                if (slidePostDtos != null)
                {
                    if (slidePostDtos.image != null)
                    {
                        var imagePathe = Guid.NewGuid().ToString();
                        Image = await _helperSrevice.UploadFiles(slidePostDtos.image, imagePathe, "Slides");
                    }


                    var addSlide = new Slide
                    {
                        title = slidePostDtos.title,
                        localTitle = slidePostDtos.localTitle,
                        Description = slidePostDtos.Description,
                        localDescription = slidePostDtos.localDescription,
                        status = "Not Approved",
                        imagePath = Image

                    };
                    await _homeDbContext.Slides.AddAsync(addSlide);
                    await _homeDbContext.SaveChangesAsync();

                }
                return new ResponseDto { isSuccess = true, message = "success" };
            }
            catch (Exception ex)
            {
                return new ResponseDto { isSuccess = false, message = ex.Message };

            }
        }
        public async Task<List<SlideGetDtos>> GetAllSlides()
        {
            var getAllSlides = await _homeDbContext.Slides.Select(x => new SlideGetDtos
            {
                Id = x.Id,
                title = x.title,
                localTitle = x.localTitle,
                Description = x.Description,
                localDescription = x.localDescription,
                imagePath = x.imagePath,
                status = x.status,

            }).ToListAsync();
            //var mapSlides = _autoMapper.Map<List<SlideGetDtos>>(geAlltSlides);
            return getAllSlides;
        }
        public async Task<List<SlideGetDtos>> GetSlidesById(int id)
        {
            var getSlideById = await _homeDbContext.Slides.Where(x => x.Id == id).Select(x => new SlideGetDtos
            {
                Id = x.Id,
                title = x.title,
                localTitle = x.localTitle,
                Description = x.Description,
                localDescription = x.localDescription,
                imagePath = x.imagePath,
                status = x.status,
            }).ToListAsync();
            return getSlideById;

        }
        public async Task<ResponseDto> ApproveSlidesById(int id)
        {
            try
            {
                var findSlideById = await _homeDbContext.Slides.FindAsync(id);
                if (findSlideById == null)
                {
                    return new ResponseDto { isSuccess = false, message = "the slide is not found" };
                }
                if (findSlideById.status == "Approved")
                {
                    findSlideById.status = "Not Approved";
                    await _homeDbContext.SaveChangesAsync();
                    return new ResponseDto { isSuccess = true, message = "the slide is not approved" };
                }
                else
                {
                    findSlideById.status = "Approved";
                    await _homeDbContext.SaveChangesAsync();
                    return new ResponseDto { isSuccess = true, message = "the slide is approved" };
                }

            } catch (Exception ex)
            {
                return new ResponseDto { isSuccess = false, message = ex.Message };
            }
        }
        public async Task<List<SlideGetDtos>> GetApprovedSlides()
            {
            var getApprovedSlides = await _homeDbContext.Slides.Where(x => x.status == "Approved").Select(y => new SlideGetDtos
            {
                Id = y.Id,
                title = y.title,
                localTitle = y.localTitle,
                Description = y.Description,
                localDescription = y.localDescription,
                status = y.status,
                imagePath = y.imagePath
            }).ToListAsync();
            return getApprovedSlides;
             }
        public async Task<List<SlideGetDtos>> GetApprovedSlidesById(int id)
        {
            var getApprovedSlideById = await _homeDbContext.Slides.Where(x => x.Id == id && x.status == "Approved").Select(y => new SlideGetDtos
            {
                Id=y.Id,
                title=y.title,
                localTitle=y.localTitle,
                Description=y.Description,
                localDescription=y.localDescription,
                status=y.status,
                imagePath=y.imagePath

            }).ToListAsync();
            return getApprovedSlideById;
        }
        public async Task<ResponseDto> UpdateSlides(SlideGetDtos slideGetDtos)
        {
            try
            {
                var updatedImage = "";
                if (slideGetDtos != null)
                {
                    var getSlide = await _homeDbContext.Slides.FindAsync(slideGetDtos.Id);
                    if (slideGetDtos.image != null)
                    {
                        string[] imageUrl = getSlide.imagePath.Split('\\');
                        var imageName = imageUrl.LastOrDefault().Split('.')[0];
                        updatedImage = await _helperSrevice.UploadFiles(slideGetDtos.image, imageName, "Slides");
                    }
                    getSlide.title = slideGetDtos.title;
                    getSlide.localDescription = slideGetDtos.localDescription;
                    getSlide.Description = slideGetDtos.Description;
                    getSlide.localTitle = slideGetDtos.localTitle;
                    getSlide.status = "Not Approved";
                    getSlide.imagePath = updatedImage;
                    getSlide.Id = slideGetDtos.Id;
                    await _homeDbContext.SaveChangesAsync();
                    return new ResponseDto
                    {
                        isSuccess = true,
                        message = "The Slide Successfully Updated"
                    };
                }
                else
                {
                    return new ResponseDto
                    {
                        isSuccess = false,
                        message = "there is no data tha you are insert to change the previous slide data"
                    };
                }
            }catch (Exception ex)
            {
                return new ResponseDto { isSuccess = false, message = ex.Message };
            }
        }
        public async Task<ResponseDto> DeleteSlideById(int id)
        {
            try
            {
                var deleteSlide = await _homeDbContext.Slides.FindAsync(id);
                if (deleteSlide != null)
                {
                     _homeDbContext.Slides.Remove(deleteSlide);
                    await _homeDbContext.SaveChangesAsync();
                    return new ResponseDto { isSuccess = true, message = "The Slide Is Successfuly Deleted" };
                }
                else
                {
                    return new ResponseDto { isSuccess = true, message = "The Slide Is Not Found" };
                }

            }catch (Exception ex)
            {
                return new ResponseDto
                {
                    isSuccess = false,
                    message = ex.Message
                };
            }
        }
       
        // About Blogs
        public async Task<ResponseDto> AddBlogsAndNews(BlogsAndNewsPostDto blogsAndNewsPostDto)
        {
            try
            {
                var Image = "";
                
                if (blogsAndNewsPostDto != null)
                {
                    if (blogsAndNewsPostDto.image != null)
                    {
                        var imagepath = Guid.NewGuid().ToString();
                        Image = await _helperSrevice.UploadFiles(blogsAndNewsPostDto.image, imagepath, "BlogsAndNews");
                    }


                    var addBlogs = new BlogsAndNews
                    {
                        title = blogsAndNewsPostDto.title,
                        localTitle = blogsAndNewsPostDto.localTitle,
                        userRole=blogsAndNewsPostDto.userRole,
                        Description = blogsAndNewsPostDto.Description,
                        localDescription = blogsAndNewsPostDto.
                        localTitle = blogsAndNewsPostDto.localTitle,
                        status = "Not Approved",
                        imageUrl = Image

                    };
                    await _homeDbContext.BlogsAndNews.AddAsync(addBlogs);
                    await _homeDbContext.SaveChangesAsync();

                }
                return new ResponseDto { isSuccess = true, message = "success" };
            }
            catch (Exception ex)
            {
                return new ResponseDto { isSuccess = false, message = ex.Message };

            }
        }
        public async Task<List<BlogsAndNewsGetDto>> GetAllBlogsAndNews()
        {
            var getAllBlogs = await _homeDbContext.BlogsAndNews.Select( x => new BlogsAndNewsGetDto
            {
                Id = x.Id,
                userRole = x.userRole,
                title = x.title,
                localTitle = x.localTitle,
                imageUrl = x.imageUrl,
                Description = x.Description,
                localDescription = x.localDescription,
                dates = x.dates,
                status = x.status,
                comments =  _homeDbContext.Comments.Where(y => y.blogId == x.Id).Select(z => new CommentsGetDto
                {
                        Id =z.Id,
                        fullName=z.fullName,
                        localFullName=z.localFullName,
                        email=z.email,
                        subject=z.subject,
                        localSubject=z.localSubject,
                        body=z.body,
                        localBody=z.localBody,
                        imageUrl=z.imageUrl,
                        blogId=z.blogId,
                        status=z.status}).ToList(),

            }).ToListAsync();
            //var mapSlides = _autoMapper.Map<List<SlideGetDtos>>(geAlltSlides);
            return getAllBlogs;
        }
        public async Task<List<BlogsAndNewsGetDto>> GetBlogsAndNewsById(int id)
        {
            var getBlogsById = await _homeDbContext.BlogsAndNews.Where(x => x.Id == id).Select(x => new BlogsAndNewsGetDto
            {
                Id = x.Id,
                userRole=x.userRole,
                title = x.title,
                localTitle = x.localTitle,
                Description = x.Description,
                localDescription = x.localDescription,
                imageUrl = x.imageUrl,
                status = x.status,
                comments = _homeDbContext.Comments.Where(y => y.blogId == x.Id).Select(z => new CommentsGetDto
                {
                    Id = z.Id,
                    fullName = z.fullName,
                    localFullName = z.localFullName,
                    email = z.email,
                    subject = z.subject,
                    localSubject = z.localSubject,
                    body = z.body,
                    localBody = z.localBody,
                    imageUrl = z.imageUrl,
                    blogId = z.blogId,
                    status = z.status
                }).ToList(),
            }).ToListAsync();
            return getBlogsById;

        }
        public async Task<ResponseDto> ApproveBlogsAndNewsById(int id)
        {
            try
            {
                var findBlogsById = await _homeDbContext.BlogsAndNews.FindAsync(id);
                if (findBlogsById == null)
                {
                    return new ResponseDto { isSuccess = false, message = "the Blog is not found" };
                }
                if (findBlogsById.status == "Approved")
                {
                    findBlogsById.status = "Not Approved";
                    await _homeDbContext.SaveChangesAsync();
                    return new ResponseDto { isSuccess = true, message = "the Blog is not approved" };
                }
                else
                {
                    findBlogsById.status = "Approved";
                    await _homeDbContext.SaveChangesAsync();
                    return new ResponseDto { isSuccess = true, message = "the Blog is approved" };
                }

            }
            catch (Exception ex)
            {
                return new ResponseDto { isSuccess = false, message = ex.Message };
            }
        }
        public async Task<List<BlogsAndNewsGetDto>> GetApprovedBlogsAndNews()
        {
            var getApprovedBlogs = await _homeDbContext.BlogsAndNews.Where(x => x.status == "Approved").Select(y => new BlogsAndNewsGetDto
            {
                Id = y.Id,
                userRole=y.userRole,
                title = y.title,
                localTitle = y.localTitle,
                Description = y.Description,
                localDescription = y.localDescription,
                status = y.status,
                imageUrl = y.imageUrl,
                comments = _homeDbContext.Comments.Where(a => a.blogId == y.Id).Select(z => new CommentsGetDto
                {
                    Id = z.Id,
                    fullName = z.fullName,
                    localFullName = z.localFullName,
                    email = z.email,
                    subject = z.subject,
                    localSubject = z.localSubject,
                    body = z.body,
                    localBody = z.localBody,
                    imageUrl = z.imageUrl,
                    blogId = z.blogId,
                    status = z.status
                }).ToList(),
            }).ToListAsync();
            return getApprovedBlogs;
        }
        public async Task<List<BlogsAndNewsGetDto>> GetApprovedBlogsAndNewsById(int id)
        {
            var getApprovedBlogById = await _homeDbContext.BlogsAndNews.Where(x => x.Id == id && x.status == "Approved").Select(y => new BlogsAndNewsGetDto
            {
                Id = y.Id,
                userRole=y.userRole,
                title = y.title,
                localTitle = y.localTitle,
                Description = y.Description,
                localDescription = y.localDescription,
                status = y.status,
                imageUrl = y.imageUrl,
                comments = _homeDbContext.Comments.Where(a => a.blogId == y.Id).Select(z => new CommentsGetDto
                {
                    Id = z.Id,
                    fullName = z.fullName,
                    localFullName = z.localFullName,
                    email = z.email,
                    subject = z.subject,
                    localSubject = z.localSubject,
                    body = z.body,
                    localBody = z.localBody,
                    imageUrl = z.imageUrl,
                    blogId = z.blogId,
                    status = z.status
                }).ToList(),

            }).ToListAsync();
            return getApprovedBlogById;
        }
        public async Task<ResponseDto> UpdateBlogsAndNews(UpdateBlogsAndNews blogsAndNewsGetDto)
        {
            try
            {
                var updatedImage = "";
                if (blogsAndNewsGetDto != null)
                {
                    var getBlog = await _homeDbContext.BlogsAndNews.FindAsync(blogsAndNewsGetDto.Id);
                    if(getBlog == null)
                    {
                        return new ResponseDto { isSuccess = false, message = "the blog is not found" };
                    }
                    if (blogsAndNewsGetDto.image != null)
                    {
                        string[] imagePath = getBlog.imageUrl.Split('\\');
                        var imageName = imagePath.LastOrDefault().Split('.')[0];
                        updatedImage = await _helperSrevice.UploadFiles(blogsAndNewsGetDto.image, imageName, "BlogsAndNews");
                    }
                    getBlog.title = blogsAndNewsGetDto.title;
                    getBlog.userRole = blogsAndNewsGetDto.userRole;
                    getBlog.localDescription = blogsAndNewsGetDto.localDescription;
                    getBlog.Description = blogsAndNewsGetDto.Description;
                    getBlog.localTitle = blogsAndNewsGetDto.localDescription;
                    getBlog.status = "Not Approved";
                    getBlog.imageUrl = updatedImage;
                    getBlog.Id = blogsAndNewsGetDto.Id;
                    await _homeDbContext.SaveChangesAsync();
                    return new ResponseDto
                    {
                        isSuccess = true,
                        message = "The Blog Successfully Updated"
                    };
                }
                else
                {
                    return new ResponseDto
                    {
                        isSuccess = false,
                        message = "there is no data tha you are insert to change the previous Blog data"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseDto { isSuccess = false, message = ex.Message };
            }
        }
        public async Task<ResponseDto> DeleteBlogsAndNewsById(int id)
        {
            try
            {
                var deleteBlog = await _homeDbContext.BlogsAndNews.FindAsync(id);
                if (deleteBlog != null)
                {
                    _homeDbContext.BlogsAndNews.Remove(deleteBlog);
                    await _homeDbContext.SaveChangesAsync();
                    return new ResponseDto { isSuccess = true, message = "The Blog Is Successfuly Deleted" };
                }
                else
                {
                    return new ResponseDto { isSuccess = true, message = "The Blog Is Not Found" };
                }

            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    isSuccess = false,
                    message = ex.Message
                };
            }
        }




        // About Comments
        public async Task<ResponseDto> AddComments(CommentsPostDto commentsPostDto)
        {
            try
            {
                var Image = "";
                if (commentsPostDto != null)
                {
                    if(commentsPostDto.image != null)
                    {
                        var imagePath= Guid.NewGuid().ToString();
                        Image = await _helperSrevice.UploadFiles(commentsPostDto.image, imagePath, "Comments");
                    }
                    var blogsAndNewsExit = await _homeDbContext.BlogsAndNews.AnyAsync(x => x.Id == commentsPostDto.blogId);
                    if (!blogsAndNewsExit)
                    {
                        return new ResponseDto { isSuccess = false, message = "Blog Id doesn't exit" };
                    }
                    var addComments = new Comments
                    {
                        fullName = commentsPostDto.fullName,
                        localFullName = commentsPostDto.localFullName,
                        email = commentsPostDto.email,
                        subject = commentsPostDto.subject,
                        localSubject = commentsPostDto.localSubject,
                        body = commentsPostDto.body,
                        localBody = commentsPostDto.body,
                        imageUrl=Image,
                       blogId=commentsPostDto.blogId,
                        status = "Not Approved",
                     

                    };
                    await _homeDbContext.Comments.AddAsync(addComments);
                    await _homeDbContext.SaveChangesAsync();

                }
                return new ResponseDto { isSuccess = true, message = "success" };
            }
            catch (Exception ex)
            {
                return new ResponseDto { isSuccess = false, message = ex.Message };

            }
        }
     public async Task<List<CommentsGetDto>> GetAllComments()
        {
            var getComments = await _homeDbContext.Comments.Select(x=>new CommentsGetDto
            {
                Id=x.Id,
                fullName=x.fullName,
                localFullName=x.localFullName,
                email=x.email,
                subject=x.subject,
                localSubject=x.localSubject,
                blogId=x.blogId,
                body=x.body,
                localBody=x.localBody,
                imageUrl=x.imageUrl
            }).ToListAsync();
            return getComments;

        }
        public async Task<ResponseDto> DeleteCommentsById(int id)
        {
            try
            {
                var deleteComment = await _homeDbContext.Comments.FindAsync(id);
                if (deleteComment != null)
                {
                    _homeDbContext.Comments.Remove(deleteComment);
                    await _homeDbContext.SaveChangesAsync();
                    return new ResponseDto { isSuccess = true, message = "The Comment Is Successfuly Deleted" };
                }
                else
                {
                    return new ResponseDto { isSuccess = true, message = "The Comment Is Not Found" };
                }

            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    isSuccess = false,
                    message = ex.Message
                };
            }
        }


        // About ContactUs
        public async Task<ResponseDto> AddContactUs(contactUsPostDto contactUsPostDto)
        {
            try
            {
           
                if (contactUsPostDto != null)
                {
                    var addSlide = new contactUs
                    {
                     fullName= contactUsPostDto.fullName,
                     localFullName = contactUsPostDto.localFullName,
                     Email=contactUsPostDto.Email,
                     subject = contactUsPostDto.subject,
                     localSubject = contactUsPostDto.localSubject, 
                        body = contactUsPostDto.body,
                        localBody = contactUsPostDto.body,
                        status = "Not Approved",
                

                    };
                    await _homeDbContext.contactUs.AddAsync(addSlide);
                    await _homeDbContext.SaveChangesAsync();

                }
                return new ResponseDto { isSuccess = true, message = "success" };
            }
            catch (Exception ex)
            {
                return new ResponseDto { isSuccess = false, message = ex.Message };

            }
        }
        public async Task<List<contactUsGetDto>> GetAllContactUs()
        {
            var getContact = await _homeDbContext.contactUs.Select(x => new contactUsGetDto
            {
                Id=x.Id,
                fullName = x.fullName,
                localFullName = x.localFullName,
                Email = x.Email,
                subject = x.subject,
                localSubject = x.localSubject,
                body = x.body,
                localBody = x.body,
                status = x.status,
            }).ToListAsync();
            return getContact;
        }
        public async Task<List<contactUsGetDto>> GetContactById(int id)
        {
            var getContactById = await _homeDbContext.contactUs.Where(y => y.Id == id).Select(x => new contactUsGetDto
            {
                Id = x.Id,
                fullName = x.fullName,
                localFullName = x.localFullName,
                Email = x.Email,
                subject = x.subject,
                localSubject = x.localSubject,
                body = x.body,
                localBody = x.body,
                status = x.status,
            }).ToListAsync();
            return getContactById;
        }
        public async Task<ResponseDto> DeleteContactById(int id)
        {
            try
            {
                var getcontact = await _homeDbContext.contactUs.FindAsync(id);
                if (getcontact != null)
                {
                    _homeDbContext.contactUs.Remove(getcontact);
                    await _homeDbContext.SaveChangesAsync();
                    return new ResponseDto
                    {
                        isSuccess = true,
                        message = "the feedback is successfully delete"
                    };
                }
                else
                {
                    return new ResponseDto
                    {
                        isSuccess = false,
                        message = "the feedback is not found"
                    };
                }

            }catch(Exception ex)
            {
                return new ResponseDto
                {
                    isSuccess = false,
                    message = ex.Message
                };
            }
        }
       
        
        
        // About Goals
        public async Task<ResponseDto> AddGoals(goalPostDto goalPost)
        {
            try
            {

                if (goalPost != null)
                {
                    var addGoal = new goal
                    {
                        date=goalPost.date,
                        Description=goalPost.Description,
                        localDescription = goalPost.localDescription,                    
                        status = "Not Approved",
                      

                    };
                    await _homeDbContext.goal.AddAsync(addGoal);
                    await _homeDbContext.SaveChangesAsync();

                }
                return new ResponseDto { isSuccess = true, message = "success" };
            }
            catch (Exception ex)
            {
                return new ResponseDto { isSuccess = false, message = ex.Message };

            }
        }
        public async Task<List<goalGetDto>> GetAllGoals()
        {
            var getAllGoal = await _homeDbContext.goal.Select(x => new goalGetDto
            {
                Id = x.Id,
                date=x.date,
                Description=x.Description,
                localDescription=x.localDescription,
                status = x.status,

            }).ToListAsync();
            //var mapSlides = _autoMapper.Map<List<SlideGetDtos>>(geAlltSlides);
            return getAllGoal;
        }
        public async Task<List<goalGetDto>> GetGoalsById(int id)
        {
            var getGoalById = await _homeDbContext.goal.Where(x => x.Id == id).Select(x => new goalGetDto
            {
                Id = x.Id,
             date=x.date,
             Description=x.Description,
             localDescription=x.localDescription,
                status = x.status,
            }).ToListAsync();
            return getGoalById;

        }
        public async Task<ResponseDto> ApproveGoalsById(int id)
        {
            try
            {
                var findGoalById = await _homeDbContext.goal.FindAsync(id);
                if (findGoalById == null)
                {
                    return new ResponseDto { isSuccess = false, message = "the goal is not found" };
                }
                if (findGoalById.status == "Approved")
                {
                    findGoalById.status = "Not Approved";
                    await _homeDbContext.SaveChangesAsync();
                    return new ResponseDto { isSuccess = true, message = "the goal is not approved" };
                }
                else
                {
                    findGoalById.status = "Approved";
                    await _homeDbContext.SaveChangesAsync();
                    return new ResponseDto { isSuccess = true, message = "the goal is approved" };
                }

            }
            catch (Exception ex)
            {
                return new ResponseDto { isSuccess = false, message = ex.Message };
            }
        }
        public async Task<List<goalGetDto>> GetApprovedGoals()
        {
            var getApprovedGoal = await _homeDbContext.goal.Where(x => x.status == "Approved").Select(y => new goalGetDto
            {
                Id = y.Id,
                date=y.date,
                Description = y.Description,
                localDescription = y.localDescription,
                status = y.status,
             
            }).ToListAsync();
            return getApprovedGoal;
        }
        public async Task<List<goalGetDto>> GetApprovedGoalsById(int id)
        {
            var getApprovedGoalById = await _homeDbContext.goal.Where(x => x.Id == id && x.status == "Approved").Select(y => new goalGetDto
            {
                Id = y.Id,
               date=y.date,
                Description = y.Description,
                localDescription = y.localDescription,
                status = y.status,
          

            }).ToListAsync();
            return getApprovedGoalById;
        }
        public async Task<ResponseDto> UpdateGoals(goalGetDto goalGet)
        {
            try
            {
           
                if (goalGet != null)
                {
                    var get = await _homeDbContext.goal.FindAsync(goalGet.Id);

                    get.localDescription = goalGet.localDescription;
                    get.Description = goalGet.Description;
                    get.date = goalGet.date;
                    get.status = "Not Approved";
                    get.Id = goalGet.Id;
                    await _homeDbContext.SaveChangesAsync();
                    return new ResponseDto
                    {
                        isSuccess = true,
                        message = "The Goal Successfully Updated"
                    };
                }
                else
                {
                    return new ResponseDto
                    {
                        isSuccess = false,
                        message = "there is no data tha you are insert to change the previous Goal data"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseDto { isSuccess = false, message = ex.Message };
            }
        }
        public async Task<ResponseDto> DeleteGoalsById(int id)
        {
            try
            {
                var deleteGoal = await _homeDbContext.goal.FindAsync(id);
                if (deleteGoal != null)
                {
                    _homeDbContext.goal.Remove(deleteGoal);
                    await _homeDbContext.SaveChangesAsync();
                    return new ResponseDto { isSuccess = true, message = "The Goal Is Successfuly Deleted" };
                }
                else
                {
                    return new ResponseDto { isSuccess = true, message = "The Goal Is Not Found" };
                }

            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    isSuccess = false,
                    message = ex.Message
                };
            }
        }


        // About Mission
        public async Task<ResponseDto> AddMission(missionPostDto missionPost)
        {
            try
            {
          
                if (missionPost != null)
                {
                    var addMission = new mission
                    {
                        date = missionPost.date,
                   Description = missionPost.Description,
                   localDescription=missionPost.localDescription,
                        status = "Not Approved",
                     

                    };
                    await _homeDbContext.mission.AddAsync(addMission);
                    await _homeDbContext.SaveChangesAsync();

                }
                return new ResponseDto { isSuccess = true, message = "success" };
            }
            catch (Exception ex)
            {
                return new ResponseDto { isSuccess = false, message = ex.Message };

            }
        }
        public async Task<List<missionGetDto>> GetAllMission()
        {
            var getAllMissions = await _homeDbContext.mission.Select(x => new missionGetDto
            {
                Id = x.Id,
               date=x.date,
                Description = x.Description,
                localDescription = x.localDescription,
           
                status = x.status,

            }).ToListAsync();
            //var mapSlides = _autoMapper.Map<List<SlideGetDtos>>(geAlltSlides);
            return getAllMissions;
        }
        public async Task<List<missionGetDto>> GetMissionById(int id)
        {
            var getMissionById = await _homeDbContext.mission.Where(x => x.Id == id).Select(x => new missionGetDto
            {
                Id = x.Id,
             date= x.date,
                Description = x.Description,
                localDescription = x.localDescription,
              
                status = x.status,
            }).ToListAsync();
            return getMissionById;

        }
        public async Task<ResponseDto> ApproveMissionById(int id)
        {
            try
            {
                var findMissinById = await _homeDbContext.mission.FindAsync(id);
                if (findMissinById == null)
                {
                    return new ResponseDto { isSuccess = false, message = "the Mission is not found" };
                }
                if (findMissinById.status == "Approved")
                {
                    findMissinById.status = "Not Approved";
                    await _homeDbContext.SaveChangesAsync();
                    return new ResponseDto { isSuccess = true, message = "the Mission is not approved" };
                }
                else
                {
                    findMissinById.status = "Approved";
                    await _homeDbContext.SaveChangesAsync();
                    return new ResponseDto { isSuccess = true, message = "the Mission is approved" };
                }

            }
            catch (Exception ex)
            {
                return new ResponseDto { isSuccess = false, message = ex.Message };
            }
        }
        public async Task<List<missionGetDto>> GetApprovedMission()
        {
            var getApproved = await _homeDbContext.mission.Where(x => x.status == "Approved").Select(y => new missionGetDto
            {
                Id = y.Id,
               date=y.date,
                Description = y.Description,
                localDescription = y.localDescription,
                status = y.status,
          
            }).ToListAsync();
            return getApproved;
        }
        public async Task<List<missionGetDto>> GetApprovedMissionById(int id)
        {
            var getApprovedMissionById = await _homeDbContext.mission.Where(x => x.Id == id && x.status == "Approved").Select(y => new missionGetDto
            {
                Id = y.Id,
               date=y.date,
                Description = y.Description,
                localDescription = y.localDescription,
                status = y.status,
             

            }).ToListAsync();
            return getApprovedMissionById;
        }
        public async Task<ResponseDto> UpdateMission(missionGetDto missionGetDto)
        {
            try
            {
               
                if (missionGetDto != null)
                {
                    var get = await _homeDbContext.mission.FindAsync(missionGetDto.Id);
                  
                
                    get.Description = missionGetDto.Description;
                    get.localDescription = missionGetDto.localDescription;
                    get.status = "Not Approved";
                    await _homeDbContext.SaveChangesAsync();
                    return new ResponseDto
                    {
                        isSuccess = true,
                        message = "The Mission Successfully Updated"
                    };
                }
                else
                {
                    return new ResponseDto
                    {
                        isSuccess = false,
                        message = "there is no data tha you are insert to change the previous Mission data"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseDto { isSuccess = false, message = ex.Message };
            }
        }
        public async Task<ResponseDto> DeleteMissionById(int id)
        {
            try
            {
                var deleteMission = await _homeDbContext.mission.FindAsync(id);
                if (deleteMission != null)
                {
                    _homeDbContext.mission.Remove(deleteMission);
                    await _homeDbContext.SaveChangesAsync();
                    return new ResponseDto { isSuccess = true, message = "The Mission Is Successfuly Deleted" };
                }
                else
                {
                    return new ResponseDto { isSuccess = true, message = "The Mission Is Not Found" };
                }

            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    isSuccess = false,
                    message = ex.Message
                };
            }
        }



        // About Rule
        public async Task<ResponseDto> AddRule(RulePostDto rulePostDto)
        {
            try
            {
         
                if (rulePostDto != null)
                {
                    var addRule = new Rule
                    {
                        title=rulePostDto.title,
                        localTitle=rulePostDto.localTitle,
                        Description = rulePostDto.Description,
                        localDescription = rulePostDto.localDescription,
                        status = "Not Approved",
                    

                    };
                    await _homeDbContext.rule.AddAsync(addRule);
                    await _homeDbContext.SaveChangesAsync();

                }
                return new ResponseDto { isSuccess = true, message = "success" };
            }
            catch (Exception ex)
            {
                return new ResponseDto { isSuccess = false, message = ex.Message };

            }
        }
        public async Task<List<RuleGetDto>> GetAllRule()
        {
            var getAllRule = await _homeDbContext.rule.Select(x => new RuleGetDto
            {
                Id = x.Id,
                title = x.title,
                localTitle = x.localTitle,
                Description = x.Description,
                localDescription = x.localDescription,
              
                status = x.status,

            }).ToListAsync();
            //var mapSlides = _autoMapper.Map<List<SlideGetDtos>>(geAlltSlides);
            return getAllRule;
        }
        public async Task<List<RuleGetDto>> GetRuleById(int id)
        {
            var getRuleById = await _homeDbContext.rule.Where(x => x.Id == id).Select(x => new RuleGetDto
            {
                Id = x.Id,
                title = x.title,
                localTitle = x.localTitle,
                Description = x.Description,
                localDescription = x.localDescription,
                status = x.status,
            }).ToListAsync();
            return getRuleById;

        }
        public async Task<ResponseDto> ApproveRuleById(int id)
        {
            try
            {
                var findRuleById = await _homeDbContext.rule.FindAsync(id);
                if (findRuleById == null)
                {
                    return new ResponseDto { isSuccess = false, message = "the Rule is not found" };
                }
                if (findRuleById.status == "Approved")
                {
                    findRuleById.status = "Not Approved";
                    await _homeDbContext.SaveChangesAsync();
                    return new ResponseDto { isSuccess = true, message = "the Rule is not approved" };
                }
                else
                {
                    findRuleById.status = "Approved";
                    await _homeDbContext.SaveChangesAsync();
                    return new ResponseDto { isSuccess = true, message = "the Rule is approved" };
                }

            }
            catch (Exception ex)
            {
                return new ResponseDto { isSuccess = false, message = ex.Message };
            }
        }
        public async Task<List<RuleGetDto>> GetApprovedRule()
        {
            var getApprovedRule = await _homeDbContext.rule.Where(x => x.status == "Approved").Select(y => new RuleGetDto
            {
                Id = y.Id,
                title = y.title,
                localTitle = y.localTitle,
                Description = y.Description,
                localDescription = y.localDescription,
                status = y.status,
              
            }).ToListAsync();
            return getApprovedRule;
        }
        public async Task<List<RuleGetDto>> GetApprovedRuleById(int id)
        {
            var getApprovedRuleById = await _homeDbContext.Slides.Where(x => x.Id == id && x.status == "Approved").Select(y => new RuleGetDto
            {
                Id = y.Id,
                title = y.title,
                localTitle = y.localTitle,
                Description = y.Description,
                localDescription = y.localDescription,
                status = y.status,
            

            }).ToListAsync();
            return getApprovedRuleById;
        }
        public async Task<ResponseDto> UpdateRule(RuleGetDto ruleGetDto)
        {
            try
            {
           
                if (ruleGetDto != null)
                {
                    var get = await _homeDbContext.rule.FindAsync(ruleGetDto.Id);
                    
                    get.title = ruleGetDto.title;
                    get.localDescription = ruleGetDto.localDescription;
                    get.Description = ruleGetDto.Description;
                    get.localTitle = ruleGetDto.localDescription;
                    get.status = "Not Approved";
                   
                    await _homeDbContext.SaveChangesAsync();
                    return new ResponseDto
                    {
                        isSuccess = true,
                        message = "The Rule Successfully Updated"
                    };
                }
                else
                {
                    return new ResponseDto
                    {
                        isSuccess = false,
                        message = "there is no data tha you are insert to change the previous Rule data"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseDto { isSuccess = false, message = ex.Message };
            }
        }
        public async Task<ResponseDto> DeleteRuleById(int id)
        {
            try
            {
                var deleteRule = await _homeDbContext.rule.FindAsync(id);
                if (deleteRule != null)
                {
                    _homeDbContext.rule.Remove(deleteRule);
                    await _homeDbContext.SaveChangesAsync();
                    return new ResponseDto { isSuccess = true, message = "The Rule Is Successfuly Deleted" };
                }
                else
                {
                    return new ResponseDto { isSuccess = true, message = "The Rule Is Not Found" };
                }

            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    isSuccess = false,
                    message = ex.Message
                };
            }
        }



        // About Service
        public async Task<ResponseDto> AddService(ServicesPostDTOs servicesPostDTOs)
        {
            try
            {
                var image = "";
                if (servicesPostDTOs != null)
                {
                    if(servicesPostDTOs.logo != null)
                    {
                        var logoPath= Guid.NewGuid().ToString();
                        image=await _helperSrevice.UploadFiles(servicesPostDTOs.logo, logoPath, "Services");
                    }

                    var addService = new Service
                    {
                        title = servicesPostDTOs.title,
                        localTitle = servicesPostDTOs.localTitle,
                        Description = servicesPostDTOs.Description,
                        localDescription = servicesPostDTOs.localDescription,
                        status = "Not Approved",
                        logopath = image

                    };
                    await _homeDbContext.services.AddAsync(addService);
                    await _homeDbContext.SaveChangesAsync();

                }
                return new ResponseDto { isSuccess = true, message = "success" };
            }
            catch (Exception ex)
            {
                return new ResponseDto { isSuccess = false, message = ex.Message };

            }
        }
        public async Task<List<ServiceGetDTOs>> GetAllService()
        {
            var getAllServices = await _homeDbContext.services.Select(x => new ServiceGetDTOs
            {
                Id = x.Id,
                title = x.title,
                localTitle = x.localTitle,
                Description = x.Description,
                localDescription = x.localDescription,
                logopath = x.logopath,
                status = x.status,

            }).ToListAsync();
            //var mapSlides = _autoMapper.Map<List<SlideGetDtos>>(geAlltSlides);
            return getAllServices;
        }
        public async Task<List<ServiceGetDTOs>> GetServiceById(int id)
        {
            var getServiceById = await _homeDbContext.services.Where(x => x.Id == id).Select(x => new ServiceGetDTOs
            {
                Id = x.Id,
                title = x.title,
                localTitle = x.localTitle,
                Description = x.Description,
                localDescription = x.localDescription,
                logopath = x.logopath,
                status = x.status,
            }).ToListAsync();
            return getServiceById;

        }
        public async Task<ResponseDto> ApproveServiceById(int id)
        {
            try
            {
                var findServiceById = await _homeDbContext.services.FindAsync(id);
                if (findServiceById == null)
                {
                    return new ResponseDto { isSuccess = false, message = "the service is not found" };
                }
                if (findServiceById.status == "Approved")
                {
                    findServiceById.status = "Not Approved";
                    await _homeDbContext.SaveChangesAsync();
                    return new ResponseDto { isSuccess = true, message = "the service is not approved" };
                }
                else
                {
                    findServiceById.status = "Approved";
                    await _homeDbContext.SaveChangesAsync();
                    return new ResponseDto { isSuccess = true, message = "the service is approved" };
                }

            }
            catch (Exception ex)
            {
                return new ResponseDto { isSuccess = false, message = ex.Message };
            }
        }
        public async Task<List<ServiceGetDTOs>> GetApprovedService()
        {
            var getApprovedService = await _homeDbContext.services.Where(x => x.status == "Approved").Select(y => new ServiceGetDTOs
            {
                Id = y.Id,
                title = y.title,
                localTitle = y.localTitle,
                Description = y.Description,
                localDescription = y.localDescription,
                status = y.status,
                logopath = y.logopath
            }).ToListAsync();
            return getApprovedService;
        }
        public async Task<List<ServiceGetDTOs>> GetApprovedServiceById(int id)
        {
            var getApprovedServiceById = await _homeDbContext.services.Where(x => x.Id == id && x.status == "Approved").Select(y => new ServiceGetDTOs
            {
                Id = y.Id,
                title = y.title,
                localTitle = y.localTitle,
                Description = y.Description,
                localDescription = y.localDescription,
                status = y.status,
                logopath = y.logopath

            }).ToListAsync();
            return getApprovedServiceById;
        }
        public async Task<ResponseDto> UpdateService(ServiceGetDTOs serviceGetDTOs)
        {
            try
            {
                var updatedImage = "";
                if (serviceGetDTOs != null)
                {
                    var getService = await _homeDbContext.services.FindAsync(serviceGetDTOs.Id);
                    if (serviceGetDTOs.logo != null)
                    {
                        string[] imageUrl = getService.logopath.Split('\\');
                        var imageName = imageUrl.LastOrDefault().Split('.')[0];
                        updatedImage = await _helperSrevice.UploadFiles(serviceGetDTOs.logo, imageName, "Services");
                    }
                    getService.title = serviceGetDTOs.title;
                    getService.localDescription = serviceGetDTOs.localDescription;
                    getService.Description = serviceGetDTOs.Description;
                    getService.localTitle = serviceGetDTOs.localTitle;
                    getService.status = "Not Approved";
                    getService.logopath = updatedImage;
                  
                    await _homeDbContext.SaveChangesAsync();
                    return new ResponseDto
                    {
                        isSuccess = true,
                        message = "The Service Successfully Updated"
                    };
                }
                else
                {
                    return new ResponseDto
                    {
                        isSuccess = false,
                        message = "there is no data tha you are insert to change the previous Service data"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseDto { isSuccess = false, message = ex.Message };
            }
        }
        public async Task<ResponseDto> DeleteServiceById(int id)
        {
            try
            {
                var deleteService = await _homeDbContext.services.FindAsync(id);
                if (deleteService != null)
                {
                    _homeDbContext.services.Remove(deleteService);
                    await _homeDbContext.SaveChangesAsync();
                    return new ResponseDto { isSuccess = true, message = "The Service Is Successfuly Deleted" };
                }
                else
                {
                    return new ResponseDto { isSuccess = true, message = "The Service Is Not Found" };
                }

            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    isSuccess = false,
                    message = ex.Message
                };
            }
        }



        // About Team
        public async Task<ResponseDto> AddTeamMember(TeamMemberPostDTOs teamMemberPostDTOs)
        {
            try
            {
                var Image = "";
                if (teamMemberPostDTOs != null)
                {
                    if(teamMemberPostDTOs.image != null)
                    {
                        var imagePath= Guid.NewGuid().ToString();
                        Image = await _helperSrevice.UploadFiles(teamMemberPostDTOs.image, imagePath, "TeamMembers");
                    }

                    var addTeam = new TeamMember
                    {
                       fullName = teamMemberPostDTOs.fullName,
                       localFullName = teamMemberPostDTOs.localFullName,
                       position = teamMemberPostDTOs.position,
                       localPosition = teamMemberPostDTOs.localPosition,
                       imageUrl =Image,
                        status = "Not Approved",
                     

                    };
                    await _homeDbContext.teamMember.AddAsync(addTeam);
                    await _homeDbContext.SaveChangesAsync();

                }
                return new ResponseDto { isSuccess = true, message = "success" };
            }
            catch (Exception ex)
            {
                return new ResponseDto { isSuccess = false, message = ex.Message };

            }
        }
        public async Task<List<TeamMemberGetDTOs>> GetAllTeamMember()
        {
            var getAllSlides = await _homeDbContext.teamMember.Select(y => new TeamMemberGetDTOs
            {
                Id = y.Id,
                fullName = y.fullName,
                localFullName = y.localFullName,
                position = y.position,
                localPosition = y.localPosition,
                imageUrl = y.imageUrl,
                status = y.status,

            }).ToListAsync();
            //var mapSlides = _autoMapper.Map<List<SlideGetDtos>>(geAlltSlides);
            return getAllSlides;
        }
        public async Task<List<TeamMemberGetDTOs>> GetTeamMemberById(int id)
        {
            var getSlideById = await _homeDbContext.teamMember.Where(x => x.Id == id).Select(y => new TeamMemberGetDTOs
            {
                Id = y.Id,
                fullName = y.fullName,
                localFullName = y.localFullName,
                position = y.position,
                localPosition = y.localPosition,
                imageUrl = y.imageUrl,
                status = y.status,
            }).ToListAsync();
            return getSlideById;

        }
        public async Task<ResponseDto> ApproveTeamMemberById(int id)
        {
            try
            {
                var findTeamById = await _homeDbContext.teamMember.FindAsync(id);
                if (findTeamById == null)
                {
                    return new ResponseDto { isSuccess = false, message = "the team is not found" };
                }
                if (findTeamById.status == "Approved")
                {
                    findTeamById.status = "Not Approved";
                    await _homeDbContext.SaveChangesAsync();
                    return new ResponseDto { isSuccess = true, message = "the team is not approved" };
                }
                else
                {
                    findTeamById.status = "Approved";
                    await _homeDbContext.SaveChangesAsync();
                    return new ResponseDto { isSuccess = true, message = "the team is approved" };
                }

            }
            catch (Exception ex)
            {
                return new ResponseDto { isSuccess = false, message = ex.Message };
            }
        }
        public async Task<List<TeamMemberGetDTOs>> GetApprovedTeamMember()
        {
            var getApprovedSlides = await _homeDbContext.teamMember.Where(x => x.status == "Approved").Select(y => new TeamMemberGetDTOs
            {
                Id = y.Id,
             fullName=y.fullName,
             localFullName=y.localFullName,
             position=y.position,
             localPosition=y.localPosition,
             imageUrl=y.imageUrl,
                status = y.status,
               
            }).ToListAsync();
            return getApprovedSlides;
        }
        public async Task<List<TeamMemberGetDTOs>> GetApprovedTeamMemberById(int id)
        {
            var getApprovedSlideById = await _homeDbContext.teamMember.Where(x => x.Id == id && x.status == "Approved").Select(y => new TeamMemberGetDTOs
            {
                Id = y.Id,
                fullName = y.fullName,
                localFullName=y.localFullName,
                position=y.position,
                localPosition = y.localPosition,
              imageUrl=y.imageUrl,
                status = y.status,
               

            }).ToListAsync();
            return getApprovedSlideById;
        }
        public async Task<ResponseDto> UpdateTeamMember(TeamMemberGetDTOs teamMember)
        {
            try
            {
                var updatedImage = "";
                if (teamMember != null)
                {
                    var getTeam = await _homeDbContext.teamMember.FindAsync(teamMember.Id);
                    if (teamMember.image != null)
                    {
                        string[] imageUrl = getTeam.imageUrl.Split('\\');
                        var imageName = imageUrl.LastOrDefault().Split('.')[0];
                        updatedImage = await _helperSrevice.UploadFiles(teamMember.image, imageName, "TeamMembers");
                    }

                    getTeam.fullName = teamMember.fullName;
                    getTeam.localFullName = teamMember.localFullName;
                    getTeam.position = teamMember.position;
                    getTeam.localPosition = teamMember.localPosition;
                    getTeam.status = "Not Approved";
                    getTeam.imageUrl = updatedImage;
                    
                    await _homeDbContext.SaveChangesAsync();
                    return new ResponseDto
                    {
                        isSuccess = true,
                        message = "The Team Successfully Updated"
                    };
                }
                else
                {
                    return new ResponseDto
                    {
                        isSuccess = false,
                        message = "there is no data tha you are insert to change the previous Team data"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseDto { isSuccess = false, message = ex.Message };
            }
        }
        public async Task<ResponseDto> DeleteTeamMemberById(int id)
        {
            try
            {
                var deleteTeam = await _homeDbContext.teamMember.FindAsync(id);
                if (deleteTeam != null)
                {
                    _homeDbContext.teamMember.Remove(deleteTeam);
                    await _homeDbContext.SaveChangesAsync();
                    return new ResponseDto { isSuccess = true, message = "The Team Is Successfuly Deleted" };
                }
                else
                {
                    return new ResponseDto { isSuccess = true, message = "The Team Is Not Found" };
                }

            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    isSuccess = false,
                    message = ex.Message
                };
            }
        }



        // About Testimonies
        public async Task<ResponseDto> AddTestimonies(testiminiesUpdateDto testiminiesUpdate)
        {
            try
            {
                var Image = "";
                if (testiminiesUpdate != null)
                {

                    if (testiminiesUpdate.image != null)
                    {
                        var imagePath= Guid.NewGuid().ToString();
                        Image = await _helperSrevice.UploadFiles(testiminiesUpdate.image, imagePath, "Testimonies");

                    }

                    var addTestimonies = new testimonies
                    {
                        fullName = testiminiesUpdate.fullName,
                        localFullName = testiminiesUpdate.localFullName,
                        position = testiminiesUpdate.position,
                        localPosition = testiminiesUpdate.localPosition,
                        imageUrl = Image,
                        Description=testiminiesUpdate.Description,
                        localDescription = testiminiesUpdate.localDescription,
                        status = "Not Approved",
                       

                    };
                    await _homeDbContext.testimonies.AddAsync(addTestimonies);
                    await _homeDbContext.SaveChangesAsync();

                }
                return new ResponseDto { isSuccess = true, message = "success" };
            }
            catch (Exception ex)
            {
                return new ResponseDto { isSuccess = false, message = ex.Message };

            }
        }
        public async Task<List<testiminiesGetDto>> GetAllTestimonies()
        {
            var getAllTestimonies = await _homeDbContext.testimonies.Select(x => new testiminiesGetDto
            {
                Id = x.Id,
                fullName = x.fullName,
                localFullName = x.localFullName,
                position=x.position,
                localPosition=x.localPosition,
                Description = x.Description,
                localDescription = x.localDescription,
                imageUrl = x.imageUrl,
                status = x.status,

            }).ToListAsync();
            //var mapSlides = _autoMapper.Map<List<SlideGetDtos>>(geAlltSlides);
            return getAllTestimonies;
        }
        public async Task<List<testiminiesGetDto>> GetTestimoniesById(int id)
        {
            var getTeamById = await _homeDbContext.testimonies.Where(x => x.Id == id).Select(x => new testiminiesGetDto
            {
                Id = x.Id,
                fullName = x.fullName,
                localFullName = x.localFullName,
                position = x.position,
                localPosition = x.localPosition,
                Description = x.Description,
                localDescription = x.localDescription,
                imageUrl = x.imageUrl,
                status = x.status,
            }).ToListAsync();
            return getTeamById;

        }
        public async Task<ResponseDto> ApproveTestimoniesById(int id)
        {
            try
            {
                var findById = await _homeDbContext.testimonies.FindAsync(id);
                if (findById == null)
                {
                    return new ResponseDto { isSuccess = false, message = "the testimonies is not found" };
                }
                if (findById.status == "Approved")
                {
                    findById.status = "Not Approved";
                    await _homeDbContext.SaveChangesAsync();
                    return new ResponseDto { isSuccess = true, message = "the testimonies is not approved" };
                }
                else
                {
                    findById.status = "Approved";
                    await _homeDbContext.SaveChangesAsync();
                    return new ResponseDto { isSuccess = true, message = "the testimonies is approved" };
                }

            }
            catch (Exception ex)
            {
                return new ResponseDto { isSuccess = false, message = ex.Message };
            }
        }
        public async Task<List<testiminiesGetDto>> GetApprovedTestimonies()
        {
            var getApproved = await _homeDbContext.testimonies.Where(x => x.status == "Approved").Select(x => new testiminiesGetDto
            {
                Id = x.Id,
                fullName = x.fullName,
                localFullName = x.localFullName,
                position = x.position,
                localPosition = x.localPosition,
                Description = x.Description,
                localDescription = x.localDescription,
                imageUrl = x.imageUrl,
                status = x.status,
            }).ToListAsync();
            return getApproved;
        }
        public async Task<List<testiminiesGetDto>> GetApprovedTestimoniesById(int id)
        {
            var getApprovedTestimoniesById = await _homeDbContext.testimonies.Where(x => x.Id == id && x.status == "Approved").Select(x => new testiminiesGetDto
            {
                Id = x.Id,
                fullName = x.fullName,
                localFullName = x.localFullName,
                position = x.position,
                localPosition = x.localPosition,
                Description = x.Description,
                localDescription = x.localDescription,
                imageUrl = x.imageUrl,
                status = x.status,

            }).ToListAsync();
            return getApprovedTestimoniesById;
        }
        public async Task<ResponseDto> UpdateTestimonies(testiminiesGetDto testiminiesGet)
        {
            try
            {
                var updatedImage = "";
                if (testiminiesGet != null)
                {
                    var getTestimonies = await _homeDbContext.testimonies.FindAsync(testiminiesGet.Id);
                    if (testiminiesGet.image != null)
                    {
                        string[] imageUrl = getTestimonies.imageUrl.Split('\\');
                        var imageName = imageUrl.LastOrDefault().Split('.')[0];
                        updatedImage = await _helperSrevice.UploadFiles(testiminiesGet.image, imageName, "Testimonies");
                    }

                    getTestimonies.fullName = testiminiesGet.fullName;
                   getTestimonies.localFullName = testiminiesGet.localFullName;
                   getTestimonies.position = testiminiesGet.position;
                    getTestimonies.localPosition = testiminiesGet.localPosition;
                    getTestimonies.Description = testiminiesGet.Description;
                  getTestimonies.localDescription = testiminiesGet.localDescription;
                    getTestimonies.imageUrl = updatedImage;
                   getTestimonies.status = testiminiesGet.status;
               
                    await _homeDbContext.SaveChangesAsync();
                    return new ResponseDto
                    {
                        isSuccess = true,
                        message = "The Testimonies Successfully Updated"
                    };
                }
                else
                {
                    return new ResponseDto
                    {
                        isSuccess = false,
                        message = "there is no data tha you are insert to change the previous Testimony data"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseDto { isSuccess = false, message = ex.Message };
            }
        }
        public async Task<ResponseDto> DeleteTestimoniesById(int id)
        {
            try
            {
                var deleteSlide = await _homeDbContext.testimonies.FindAsync(id);
                if (deleteSlide != null)
                {
                    _homeDbContext.testimonies.Remove(deleteSlide);
                    await _homeDbContext.SaveChangesAsync();
                    return new ResponseDto { isSuccess = true, message = "The Testimony Is Successfuly Deleted" };
                }
                else
                {
                    return new ResponseDto { isSuccess = true, message = "The Testimony Is Not Found" };
                }

            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    isSuccess = false,
                    message = ex.Message
                };
            }
        }



        // About Vision
        public async Task<ResponseDto> AddVision(VisionPostDto visionPostDto)
        {
            try
            {
     
                if (visionPostDto != null)
                {
                    var addVision = new Vision
                    {
                        date=visionPostDto.date,
                        Description=visionPostDto.Description,
                        localDescription=visionPostDto.localDescription,
                        status = "Not Approved",
                   

                    };
                    await _homeDbContext.vision.AddAsync(addVision);
                    await _homeDbContext.SaveChangesAsync();

                }
                return new ResponseDto { isSuccess = true, message = "success" };
            }
            catch (Exception ex)
            {
                return new ResponseDto { isSuccess = false, message = ex.Message };

            }
        }
        public async Task<List<VisionGetDto>> GetAllVision()
        {
            var getAllVision = await _homeDbContext.vision.Select(x => new VisionGetDto
            {
                Id = x.Id,
               date=x.date,
               Description=x.Description,
               localDescription=x.localDescription,
                status = x.status,

            }).ToListAsync();
            //var mapSlides = _autoMapper.Map<List<SlideGetDtos>>(geAlltSlides);
            return getAllVision;
        }
        public async Task<List<VisionGetDto>> GetVisionById(int id)
        {
            var getById = await _homeDbContext.vision.Where(x => x.Id == id).Select(x => new VisionGetDto
            {
                Id = x.Id,
               date=x.date,
               Description=x.Description,
               localDescription=x.localDescription,
                status = x.status,
            }).ToListAsync();
            return getById;

        }
        public async Task<ResponseDto> ApproveVisionById(int id)
        {
            try
            {
                var findById = await _homeDbContext.vision.FindAsync(id);
                if (findById == null)
                {
                    return new ResponseDto { isSuccess = false, message = "the Vision is not found" };
                }
                if (findById.status == "Approved")
                {
                    findById.status = "Not Approved";
                    await _homeDbContext.SaveChangesAsync();
                    return new ResponseDto { isSuccess = true, message = "the Vision is not approved" };
                }
                else
                {
                    findById.status = "Approved";
                    await _homeDbContext.SaveChangesAsync();
                    return new ResponseDto { isSuccess = true, message = "the Vision is approved" };
                }

            }
            catch (Exception ex)
            {
                return new ResponseDto { isSuccess = false, message = ex.Message };
            }
        }
        public async Task<List<VisionGetDto>> GetApprovedVision()
        {
            var getApprovedVision = await _homeDbContext.vision.Where(x => x.status == "Approved").Select(y => new VisionGetDto
            {
                Id = y.Id,
                date=y.date,
                Description=y.Description,
                localDescription=y.localDescription,
                status = y.status,
              
            }).ToListAsync();
            return getApprovedVision;
        }
        public async Task<List<VisionGetDto>> GetApprovedVisionById(int id)
        {
            var getApprovedVisionById = await _homeDbContext.vision.Where(x => x.Id == id && x.status == "Approved").Select(y => new VisionGetDto
            {
                Id = y.Id,
              date=y.date,
              Description=y.Description,
              localDescription=y.localDescription,
                status = y.status,
             

            }).ToListAsync();
            return getApprovedVisionById;
        }
        public async Task<ResponseDto> UpdateVision(VisionGetDto visionGetDto)
        {
            try
            {
              
                if (visionGetDto != null)
                {
                    var getVision = await _homeDbContext.vision.FindAsync(visionGetDto.Id);
                    getVision.date = visionGetDto.date;
                    getVision.Description = visionGetDto.Description;
                    getVision.localDescription = visionGetDto.localDescription;
                    getVision.status = "Not Approved";
                    await _homeDbContext.SaveChangesAsync();
                    return new ResponseDto
                    {
                        isSuccess = true,
                        message="the Vision is successfuly updated"
                    };
                }
                else
                {
                    return new ResponseDto
                    {
                        isSuccess = false,
                        message = "there is no data tha you are insert to change the previous vision data"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseDto { isSuccess = false, message = ex.Message };
            }
        }
        public async Task<ResponseDto> DeleteVisionById(int id)
        {
            try
            {
                var deleteVision = await _homeDbContext.vision.FindAsync(id);
                if (deleteVision != null)
                {
                    _homeDbContext.vision.Remove(deleteVision);
                    await _homeDbContext.SaveChangesAsync();
                    return new ResponseDto { isSuccess = true, message = "The Vision Is Successfuly Deleted" };
                }
                else
                {
                    return new ResponseDto { isSuccess = true, message = "The Vision Is Not Found" };
                }

            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    isSuccess = false,
                    message = ex.Message
                };
            }
        }

    }
}
