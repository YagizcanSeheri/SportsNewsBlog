using SportsNews.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsNews.UI.Areas.Admin.Data.DTO.VMs
{
    public class AddPostVM
    {
        public AddPostVM()
        {
            Categories = new List<Category>();
            AppUsers = new List<AppUser>();
        }
        public List<Category> Categories { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }
}