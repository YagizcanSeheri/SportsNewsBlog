using SportsNews.Entities;
using SportsNews.Service.Services;
using SportsNews.UI.Areas.Admin.Data.DTO;
using SportsNews.Utility.ImageProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsNews.UI.Areas.Admin.Controllers
{
    public class AppUserController : Controller
    {
        public AppUserService _appUserService;
        public AppUserController()
        {
            _appUserService = new AppUserService();
        }
        // GET: Admin/AppUser
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AppUser data,HttpPostedFileBase Image ) 
        {
            List<string> UploadImagePath = new List<string>();
            UploadImagePath = ImageUploader.UploadSingleImage(ImageUploader.OriginalProfileImagePath, Image, 1);
            data.UserImage = UploadImagePath[0];
            if (data.UserImage == "0" || data.UserImage == "1" || data.UserImage == "2")
            {
                data.UserImage = ImageUploader.DefaultProfileImagePath;
                data.XSmallUserImage = ImageUploader.DefaultXSmallProfileImagePath;
                data.CruptedUserImage = ImageUploader.DefaultCruptedProfileImagePath;
            }
            else
            {
                data.XSmallUserImage = UploadImagePath[1];
                data.CruptedUserImage = UploadImagePath[2];
            }

            _appUserService.Add(data);
            return Redirect("/Admin/AppUser/List");

        }

        public ActionResult List() 
        {
            List<AppUser> model = _appUserService.GetActive();
            return View(model);
        
        }
        public ActionResult Update(int id) 
        {
            AppUser appUser = _appUserService.GetById(id);
            AppUserDTO model = new AppUserDTO();
            model.Id = appUser.Id;
            model.FirstName = appUser.FirstName;
            model.LastName = appUser.LastName;
            model.UserName = appUser.UserName;
            model.Mail = appUser.Mail;
            model.Password = appUser.Password;
            appUser.Role = appUser.Role;
            model.XSmallUserImage = appUser.XSmallUserImage;
            return View(model);
        
        }

        [HttpPost]
        public ActionResult Update(AppUserDTO data, HttpPostedFileBase Image) 
        {
            List<string> UploadImagePaths = new List<string>();
            UploadImagePaths = ImageUploader.UploadSingleImage(ImageUploader.OriginalProfileImagePath,Image,1);
            data.UserImage = UploadImagePaths[0];
            AppUser appUser = _appUserService.GetById(data.Id);
            if (data.UserImage =="0" ||data.UserImage =="1" ||data.UserImage=="2" )
            {
                if (appUser.UserImage== null||appUser.UserImage == ImageUploader.DefaultProfileImagePath)
                {
                    appUser.UserImage = ImageUploader.DefaultProfileImagePath;
                    appUser.UserImage = ImageUploader.DefaultCruptedProfileImagePath;
                    appUser.UserImage = ImageUploader.DefaultXSmallProfileImagePath;
                }
                else
                {
                    appUser.UserImage = appUser.UserImage;
                    appUser.XSmallUserImage = appUser.XSmallUserImage;
                    appUser.CruptedUserImage = appUser.CruptedUserImage;
                }
            }
            else
            {
                appUser.UserImage = UploadImagePaths[0];
                appUser.XSmallUserImage = UploadImagePaths[1];
                appUser.CruptedUserImage = UploadImagePaths[2];
            }

            appUser.FirstName = data.FirstName;
            appUser.LastName = data.LastName;
            appUser.UserName = data.UserName;
            appUser.Mail = data.Mail;
            appUser.Password = data.Password;
            appUser.Role = data.Role;
            appUser.ImagePath = data.ImagePath;
            appUser.UpdateDate = DateTime.Now;
            appUser.Status = Status.Modified;
            _appUserService.Update(appUser);
            return Redirect("/Admin/AppUser/List");
        
        }

        public ActionResult Delete(int id) 
        {
            _appUserService.Remove(id);
            return Redirect("/Admin/AppUser/List");
        
        }
    }
}