using SportsNews.Entities;
using SportsNews.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsNews.UI.Areas.Admin.Controllers
{
    
    public class HomeController : Controller
    {
        public PostService _postService;
        public HomeController()
        {
            _postService = new PostService();
        }
        // GET: Admin/Home
        public ActionResult Index()
        {
            List<Post> posts = _postService.GetActive().OrderByDescending(x => x.CreateDate).ToList();
            return View(posts);
        }
    }
}