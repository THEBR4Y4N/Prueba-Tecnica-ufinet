using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Context;
using PruebaTecnica.Models;

namespace PruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatosPaises : ControllerBase
    {
        private readonly AplicationDbContext _context;
        public DatosPaises(AplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("ObtenerDatosPorPais")]
        public IActionResult ObtenerDatosPorPais(int pagina = 1, int valores_por_pagina = 10, bool filtro = false, string? valor_Busqueda = "")
        {
            if (filtro && string.IsNullOrWhiteSpace(valor_Busqueda))
            {
                return BadRequest("El campo 'valor_Busqueda' es requerido cuando el filtro está activado.");
            }

            IQueryable<Pais> consultaBase = _context.Pais;

            if (filtro)
            {
                consultaBase = consultaBase.Where(p =>
                    EF.Functions.Like(p.Name, $"%{valor_Busqueda}%") ||
                    EF.Functions.Like(p.isoCode, $"%{valor_Busqueda}%") ||
                    p.Hotel.Any(h => EF.Functions.Like(h.Nameh, $"%{valor_Busqueda}%")) ||
                    p.Restaurante.Any(r => EF.Functions.Like(r.NameR, $"%{valor_Busqueda}%"))
                );
            }

            var totalRegistros = consultaBase.Count();

            var datosPorPais = consultaBase
            .Select(p => new
            {
                p.Id,
                p.isoCode,
                p.Name,
                p.population,
                hoteles = p.Hotel.Select(h => new
                {
                    h.Id,
                    h.Nameh,
                    h.Starts
                }).ToList(),
                restaurantes = p.Restaurante.Select(r => new
                {
                    r.Id,
                    r.NameR,
                    r.Type
                }).ToList()
            })
            .Skip((pagina - 1) * valores_por_pagina)
            .Take(valores_por_pagina)
            .ToList();

             Response.Headers.Add("Registros-totales", totalRegistros.ToString());

            return Ok(datosPorPais);
        }
         
    }
}
