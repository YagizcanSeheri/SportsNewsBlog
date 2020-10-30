using SportsNews.Entities;
using SportsNews.Service.Services;
using SportsNews.UI.Areas.Member.Data.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsNews.UI.Areas.Member.Controllers
{
    public class LikeController : Controller
    {
        AppUserService _appUserService;
        LikeService _likeService;
        CommentService _commentService;
        public LikeController()
        {
            _appUserService = new AppUserService();
            _likeService = new LikeService();
            _commentService = new CommentService();
        }

        // GET: Member/Like
        public JsonResult AddLike(int id) 
        {
            JsonLikeVM jr = new JsonLikeVM();
            int appUserId = _appUserService.FindByUserName(HttpContext.User.Identity.Name).Id;
            if (!(_likeService.Any(x=> x.AppUserId == appUserId && x.PostId ==id)))
            {
                Like like = new Like();
                like.PostId = id;
                like.AppUserId = appUserId;
                _likeService.Add(like);

                jr.Likes = _likeService.GetDefault(x => x.PostId == id).Count();
                jr.userMessage = "like it";
                jr.isSuccess = true;
                jr.Likes = _likeService.GetDefault(x => x.PostId == id && x.Status != Status.Passive).Count();
                jr.Comments = _commentService.GetDefault(x => x.PostId == id && x.Status != Status.Passive).Count();
                return Json(jr, JsonRequestBehavior.AllowGet);
            }
            else
            {
                jr.isSuccess = false;
                jr.userMessage = "You have liked this post before..!!";
                return Json(jr, JsonRequestBehavior.AllowGet);
            }
        
        }
    }
}