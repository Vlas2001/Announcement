using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Abstraction;

namespace Repository.Implementation
{
    public class AnnouncementRepository: IAnnouncementRepository
    {
        private readonly AnnouncementContext _announcementContext;

        public AnnouncementRepository(AnnouncementContext announcementContext)
        {
            _announcementContext = announcementContext;
        }

        public async Task AddAnnouncementAsync(Announcement announcement)
        {
            await _announcementContext.Announcements.AddAsync(announcement);
            await _announcementContext.SaveChangesAsync();
        }

        public async Task RemoveAnnouncementAsync(int id)
        {
            var announcement = new Announcement { Id = id };
            await Task.Run(() => _announcementContext.Announcements.Remove(announcement));
            await _announcementContext.SaveChangesAsync();
        }

        public async Task UpdateAnnouncementAsync(Announcement announcement)
        {
            await Task.Run(() => _announcementContext.Update(announcement));
            await _announcementContext.SaveChangesAsync();
        }

        public async Task<Announcement> GetAnnouncementAsync(int id)
        {
            return await _announcementContext.Announcements.FirstOrDefaultAsync(item => item.Id == id);
        }

        public async Task<List<Announcement>> GetAllAnnouncementsAsync()
        {
            return await _announcementContext.Announcements.ToListAsync();
        }
    }
}