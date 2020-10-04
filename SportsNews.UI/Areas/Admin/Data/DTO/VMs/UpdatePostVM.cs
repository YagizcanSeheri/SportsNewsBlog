using SportsNews.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsNews.UI.Areas.Admin.Data.DTO.VMs
{
    public class UpdatePostVM
    {
        public UpdatePostVM()
        {
            Categories = new List<Category>();
            AppUsers = new List<AppUser>();
            PostDTO = new PostDTO();
        }

        public List<Category> Categories { get; set; }
        public List<AppUser> AppUsers { get; set; }
        public PostDTO PostDTO { get; set; }
    }
}