using SportsNews.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsNews.Map.Mapping
{
    public class CommentMap:KernelMap<Comment>
    {
        public CommentMap()
        {
            ToTable("dbo.Comments");
            Property(x => x.Content).IsRequired();

            HasRequired(x => x.Post)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.PostId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.AppUser)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.AppUserId)
                .WillCascadeOnDelete(false);
        }
    }
}
