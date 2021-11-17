using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AnnouncementContext: DbContext
    {
        public DbSet<Announcement> Announcements { get; set; }

        public AnnouncementContext(DbContextOptions<AnnouncementContext> options): base(options)
        {
            Database.EnsureCreated();
        }
    }
}