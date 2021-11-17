using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Repository.Abstraction;
using Services.Abstraction;

namespace Services.Implementation
{
    public class AnnouncementService: IAnnouncementService
    {
        private readonly IAnnouncementRepository _announcementRepository;

        public AnnouncementService(IAnnouncementRepository announcementRepository)
        {
            _announcementRepository = announcementRepository;
        }
        
        public async Task AddAnnouncementAsync(Announcement announcement)
        { 
            await _announcementRepository.AddAnnouncementAsync(announcement);
        }

        public async Task RemoveAnnouncementAsync(int id)
        {
            await _announcementRepository.RemoveAnnouncementAsync(id);
        }

        public async Task UpdateAnnouncementAsync(Announcement announcement)
        {
            await _announcementRepository.UpdateAnnouncementAsync(announcement);
        }

        public async Task<Announcement> GetAnnouncementAsync(int id)
        {
            return await _announcementRepository.GetAnnouncementAsync(id);
        }

        public async Task<List<Announcement>> GetAllAnnouncementsAsync()
        {
            return await _announcementRepository.GetAllAnnouncementsAsync();
        }

        public List<Announcement> GetTopSimilarAnnouncements(Announcement announcement)
        {
            var announcements = _announcementRepository.GetAllAnnouncementsAsync().Result;
            return announcements.Where(item => IsAnnouncementsSimilar(item, announcement)).Take(3).ToList();
        }

        private bool IsAnnouncementsSimilar(Announcement first, Announcement second)
        {
            return first.Title.Split(' ').Any(word => second.Title.Contains(word)) &&
                   first.Description.Split(' ').Any(word => second.Description.Contains(word)) &&
                   first.Id != second.Id;
        }
    }
}