using SportsNews.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsNews.UI.Areas.Member.Data.VMs
{
    public class PostDetailVM
    {
        public PostDetailVM()
        {
            AppUsers = new List<AppUser>();
            Posts = new List<Post>();
            Categories = new List<Category>();
            Comments = new List<Comment>();
            Likes = new List<Like>();
        }

        public List<AppUser> AppUsers { get; set; }
        public List<Post> Posts { get; set; }
        public List<Category> Categories { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Like> Likes { get; set; }

        public Post Post { get; set; }
        public AppUser AppUser { get; set; }

        public int CommentCount { get; set; }
        public int LikeCount { get; set; }
    }
}