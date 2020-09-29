using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsNews.Entities
{
    public class Post:BaseEntity
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }


        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }


        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
    }
}
