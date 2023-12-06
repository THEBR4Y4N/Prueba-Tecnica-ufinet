using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Context;
using PruebaTecnica.Models;

namespace PruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public PaisController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Pais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pais>>> GetPais()
        {
          if (_context.Pais == null)
          {
              return NotFound();
          }
            return await _context.Pais.ToListAsync();
        }

        // GET: api/Pais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pais>> GetPais(int id)
        {
          if (_context.Pais == null)
          {
              return NotFound();
          }
            var pais = await _context.Pais.FindAsync(id);

            if (pais == null)
            {
                return NotFound();
            }

            return pais;
        }

        private bool PaisExists(int id)
        {
            return (_context.Pais?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
