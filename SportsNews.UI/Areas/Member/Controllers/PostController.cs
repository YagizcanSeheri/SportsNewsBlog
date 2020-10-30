using SportsNews.Service.Services;
using SportsNews.UI.Areas.Member.Data.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsNews.UI.Areas.Member.Controllers
{
    public class PostController : Controller
    {
        PostService _postService;
        AppUserService _appUserService;
        CategoryService _categoryService;
        CommentService _commentService;
        LikeService _likeService;
        public PostController()
        {
            _postService = new PostService();
            _appUserService = new AppUserService();
            _categoryService = new CategoryService();
            _commentService = new CommentService();
            _likeService = new LikeService();
        }
        // GET: Member/Post
        public ActionResult Show(int id)
        {
            PostDetailVM model = new PostDetailVM();
            model.Post = _postService.GetById(id);
            
            model.AppUser = _appUserService.GetById(model.Post.AppUserId);
            
            model.Comments = _commentService.GetDefault(x => x.PostId == id && x.Status != Entities.Status.Passive);
            
            model.Likes = _likeService.GetDefault(x => x.PostId == id && x.Status != Entities.Status.Passive);
            
            model.CommentCount = _commentService.GetDefault(x => x.PostId == id && x.Status != Entities.Status.Passive).Count;
            
            model.LikeCount = _likeService.GetDefault(x => x.PostId == id && x.Status != Entities.Status.Passive).Count;
            return View(model);
        }
    }
}