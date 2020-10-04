using SportsNews.Entities;
using SportsNews.Service.Services;
using SportsNews.UI.Areas.Admin.Data.DTO;
using SportsNews.UI.Areas.Admin.Data.DTO.VMs;
using SportsNews.Utility.ImageProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsNews.UI.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        PostService _postService;
        CategoryService _categoryService;
        AppUserService _appUserService;
        public PostController()
        {
            _postService = new PostService();
            _categoryService = new CategoryService();
            _appUserService = new AppUserService();
        }

        // GET: Admin/Post
        public ActionResult Create()
        {
            AddPostVM addPostVM = new AddPostVM()
            {
                Categories = _categoryService.GetActive(),
                AppUsers=_appUserService.GetDefault(x=> x.Role!=Entities.Role.Member)

            };
            return View(addPostVM);
        }

        [HttpPost]
        public ActionResult Create(Post data,HttpPostedFileBase Image) 
        {
            List<string> UploadImagePaths = new List<string>();
            UploadImagePaths = ImageUploader.UploadSingleImage(ImageUploader.OriginalProfileImagePath, Image, 1);

            data.ImagePath = UploadImagePaths[0];
            if (data.ImagePath=="0"||data.ImagePath=="1"||data.ImagePath== "2")
            {
                data.ImagePath = ImageUploader.DefaultProfileImagePath;
                data.ImagePath = ImageUploader.DefaultXSmallProfileImagePath;
                data.ImagePath = ImageUploader.DefaultCruptedProfileImagePath;
            }
            else
            {
                data.ImagePath = UploadImagePaths[1];
                data.ImagePath = UploadImagePaths[2];
            }
            _postService.Add(data);
            return Redirect("/Admin/Post/List");
        
        }
        public ActionResult List() 
        {
            List<Post> model = _postService.GetActive();
            return View(model);
        }
        public ActionResult Details(int id) 
        {
            Post post = _postService.GetById(id);
            return View(post);
        }
        public ActionResult Update(int id) 
        {
            Post post = _postService.GetById(id);
            UpdatePostVM model = new UpdatePostVM();
            model.PostDTO.Id = post.Id;
            model.PostDTO.Header = post.Header;
            model.PostDTO.Content = post.Content;
            model.PostDTO.ImagePath = post.ImagePath;
            model.Categories = _categoryService.GetActive();
            model.AppUsers = _appUserService.GetActive();
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(PostDTO data, HttpPostedFileBase Image) 
        {
            Post post = _postService.GetById(data.Id);

            List<string> UploadImagePaths = new List<string>();

            UploadImagePaths = ImageUploader.UploadSingleImage(ImageUploader.OriginalProfileImagePath, Image, 1);
            data.ImagePath = UploadImagePaths[0];
            if (data.ImagePath=="0"||data.ImagePath=="1"||data.ImagePath=="2")
            {
                if (post.ImagePath ==null||post.ImagePath == ImageUploader.DefaultProfileImagePath)
                {
                    post.ImagePath = ImageUploader.DefaultProfileImagePath;
                    post.ImagePath = ImageUploader.DefaultXSmallProfileImagePath;
                    post.ImagePath = ImageUploader.DefaultCruptedProfileImagePath;
                }
                else
                {
                    post.ImagePath = data.ImagePath;
                }
            }
            else
            {
                post.ImagePath = UploadImagePaths[0];
                post.ImagePath = UploadImagePaths[1];
                post.ImagePath = UploadImagePaths[2];
            }

            post.Header = data.Header;
            post.Content = data.Content;
            post.CategoryId = data.CategoryId;
            post.AppUserId = data.AppUserId;
            post.Status = Status.Modified;
            post.UpdateDate = DateTime.Now;
            _postService.Update(post);
            return Redirect("/Admin/Post/List");
        }

        public ActionResult Delete(int id) 
        {
            _postService.Remove(id);
            return Redirect("/Admin/Post/List");
        }
    }
}