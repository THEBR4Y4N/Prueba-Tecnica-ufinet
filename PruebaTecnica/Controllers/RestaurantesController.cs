﻿using System;
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
    public class RestaurantesController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public RestaurantesController(AplicationDbContext context)
        {
            _context = context;
        }
        //[HttpGet]
        //public IActionResult ObtenerRestauranteConPais()
        //{
        //    var restauranteConPais = _context.Restaurante
        //        .Include(h => h.Pais);


        //    return Ok(restauranteConPais);
        //}

    }
       
}
