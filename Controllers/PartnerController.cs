using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PsychologyApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PsychologyApp.Controllers
{
    public class PartnerController : Controller
    {
        private readonly PsychologyAppContext _context;

        public PartnerController(PsychologyAppContext context)
        {
            _context = context;
        }

        // Display all partners
        public async Task<IActionResult> Index()
        {
            var partners = await _context.Partners
                                         .Include(p => p.PsychologyType)
                                         .Include(p => p.PsychotherapyType)
                                         .ToListAsync();
            return View(partners);
        }

        // API to get partners based on quiz results
        [HttpGet]
        public async Task<IActionResult> GetPartners(int? psychologyTypeId, int? psychotherapyTypeId)
        {
            var partners = await _context.Partners
                .Include(p => p.PsychologyType)
                .Include(p => p.PsychotherapyType)
                .Where(p => (psychologyTypeId == null || p.PsychologyTypeId == psychologyTypeId) &&
                            (psychotherapyTypeId == null || p.PsychotherapyTypeId == psychotherapyTypeId))
                .ToListAsync();

            Console.WriteLine($"Found {partners.Count} partners for PsychologyTypeId={psychologyTypeId} and PsychotherapyTypeId={psychotherapyTypeId}");

            return PartialView("_PartnerCards", partners);
        }
        public IActionResult Profile(int id)
        {
            var partner = _context.Partners
                .Include(p => p.PsychologyType)
                .Include(p => p.PsychotherapyType)
                .FirstOrDefault(p => p.Id == id);

            if (partner == null)
            {
                return NotFound();
            }

            return View(partner);
        }

    }
}
