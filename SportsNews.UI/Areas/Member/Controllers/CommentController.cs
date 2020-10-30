using SportsNews.Entities;
using SportsNews.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsNews.UI.Areas.Member.Controllers
{
    public class CommentController : Controller
    {
        CommentService _commentService;
        AppUserService _appUserService;
        LikeService _likeService;
        PostService _postService;

        public CommentController()
        {
            _commentService = new CommentService();
            _appUserService = new AppUserService();
            _likeService = new LikeService();
            _postService = new PostService();
        }
        // GET: Member/Comment
        public JsonResult AddComment(string userComment, int id)
        {
            Comment comment = new Comment();
            comment.AppUserId = _appUserService.FindByUserName(HttpContext.User.Identity.Name).Id;
            comment.PostId = id;
            comment.Content = userComment;
            bool isAdded = false;
            try
            {
                _commentService.Add(comment);
                isAdded = true;
            }
            catch (Exception)
            {

                isAdded = false;
            }
            return Json(isAdded, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteComment(int id) 
        {
            int userId = _appUserService.FindByUserName(HttpContext.User.Identity.Name).Id;
            Comment comment = _commentService.GetById(id);
            bool isDelete = false;
            if (comment.AppUserId == userId)
            {
                isDelete = true;
                _commentService.Remove(id);
                return Json(isDelete, JsonRequestBehavior.AllowGet);
            }
            else
            {
                isDelete = false;
                return Json(isDelete, JsonRequestBehavior.AllowGet);
            }
            
        }

        public JsonResult GetPostComment(int id)
        {
            Comment comment = _commentService.GetDefault(x => x.PostId == id && x.Status != Status.Passive).LastOrDefault();
            return Json(new
            {
                AppUserImagePath = comment.AppUser.UserImage,
                FirstName = comment.AppUser.FirstName,
                LastName = comment.AppUser.LastName,
                CreateDate = comment.CreateDate.ToString(),
                Content = comment.Content,
                CommentCount = _commentService.GetDefault(x=> x.PostId == id && x.Status != Status.Passive).Count(),
                LikeCount = _commentService.GetDefault(x=> x.PostId ==id&&x.Status != Status.Passive).Count(),
            },JsonRequestBehavior.AllowGet);
        }
    }
}