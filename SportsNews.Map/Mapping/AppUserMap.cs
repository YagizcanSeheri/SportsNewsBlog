using SportsNews.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsNews.Map.Mapping
{
    public class AppUserMap:KernelMap<AppUser>
    {
        public AppUserMap()
        {
            ToTable("dbo.AppUsers");
            Property(x => x.FirstName).HasMaxLength(50).IsRequired();
            Property(x => x.LastName).HasMaxLength(50).IsRequired();
            Property(x => x.UserName).HasMaxLength(50).IsRequired();
            Property(x => x.Password).HasMaxLength(50).IsRequired();
            Property(x => x.Role).IsRequired();

            HasMany(x => x.Posts)
                .WithRequired(x => x.AppUser)
                .HasForeignKey(x => x.AppUserId)
                .WillCascadeOnDelete(false);

            HasMany(x => x.Comments)
                .WithRequired(x => x.AppUser)
                .HasForeignKey(x => x.AppUserId)
                .WillCascadeOnDelete(false);

            HasMany(x => x.Likes)
                .WithRequired(x => x.AppUser)
                .HasForeignKey(x => x.AppUserId)
                .WillCascadeOnDelete(false);
        }
    }
}
