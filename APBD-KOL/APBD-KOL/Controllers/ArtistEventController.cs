using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBD_KOL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APBD_KOL.Controllers
{
    [Route("api/artistevent")]
    [ApiController]
    public class ArtistEventController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ArtistEventController(MyDbContext context)
        {
            _context = context;
        }


        [HttpPost("{id}")]
        public IActionResult UpdatePerform(DateTime date, int eventId, int artistId)
        {

            var ev = _context.Events.Where(d => d.IdEvent == eventId).First();

            if (ev == null)
            {
                return BadRequest();
            }

            if (ev.StastDate < DateTime.Now || date < ev.StastDate || date > ev.EndDate)
            {
                return BadRequest();
            }

            var perform = new Artist_Event
            {
                IdArtist = artistId,
                IdEvent = eventId,
                PerformanceDate = date
            };

            _context.Attach(perform);
            _context.Entry(perform).Property("PerformanceDate").IsModified = true;
            _context.SaveChanges();
            return Ok(perform);
        }
    }
}