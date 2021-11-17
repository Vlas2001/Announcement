using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;

namespace Announcement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnnouncementService _announcementService;

        public HomeController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public IActionResult Index()
        {
            return View(_announcementService.GetAllAnnouncementsAsync().Result);
        }

        [HttpGet]
        public IActionResult NewAnnouncement()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewAnnouncement(Entities.Announcement announcement)
        {
            await _announcementService.AddAnnouncementAsync(announcement);
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> DeleteAnnouncement([FromRoute]int id)
        {
            await _announcementService.RemoveAnnouncementAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateAnnouncement(int id)
        {
            return View(_announcementService.GetAnnouncementAsync(id).Result);
        }
        
        [HttpPost]
        public async Task<IActionResult> UpdateAnnouncement(Entities.Announcement announcement)
        {
            await _announcementService.UpdateAnnouncementAsync(announcement);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetAnnouncement(int id)
        {
            var announcement = _announcementService.GetAnnouncementAsync(id).Result;
            ViewBag.SimilarAnnouncements = _announcementService.GetTopSimilarAnnouncements(announcement);
            return View(announcement);
        }
    }
}