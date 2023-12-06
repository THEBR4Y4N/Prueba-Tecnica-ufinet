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
    public class HotelsController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public HotelsController(AplicationDbContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public IActionResult ObtenerHotelConPais()
        //{
        //    var hotelConPais = _context.Hotel
        //        .Include(h => h.PaisId);


        //    return Ok(hotelConPais);
        //}


    }
}
