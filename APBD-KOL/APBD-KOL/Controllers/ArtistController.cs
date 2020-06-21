using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBD_KOL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APBD_KOL.Controllers
{
    [Route("api/artist")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ArtistController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetArtist(int id)
        {
            return Ok(_context.Artists.Where(e => e.IdArtist == id).Include(d => d.Artist_Events).ThenInclude( d => d.Event).ToList());
        }

    }
}
