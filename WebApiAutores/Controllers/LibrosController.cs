using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.Entidades;

namespace WebApiAutores.Controllers
{
    [ApiController]
    [Route("api/libros")]
    public class LibrosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public LibrosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Libro>> Get(int id)
        {
            return await context.Libros.FirstOrDefaultAsync(libro => libro.Id == id);
        }

        //[HttpPost]
        //public async Task<ActionResult> Post(Libro libro)
        //{
        //    var existeAutor = await context.Autores.AnyAsync(autor => autor.Id == libro.AutorId);

        //    if(!existeAutor) {
        //        return BadRequest($"El autor {libro.AutorId} no existe");
        //    }

        //    context.Add(libro);
        //    await context.SaveChangesAsync();
        //    return Ok();
        //}
    }
}

