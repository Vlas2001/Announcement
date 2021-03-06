using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace Repository.Abstraction
{
    public interface IAnnouncementRepository
    {
        Task AddAnnouncementAsync(Announcement announcement);

        Task RemoveAnnouncementAsync(int id);

        Task UpdateAnnouncementAsync(Announcement announcement);

        Task<Announcement> GetAnnouncementAsync(int id);

        Task<List<Announcement>> GetAllAnnouncementsAsync();
    }
}