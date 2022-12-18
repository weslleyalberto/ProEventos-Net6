using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly DataContext _context;
        const string error = "requisição inválida";

        public EventoController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Evento>>> GetAll()
        {
            try
            {
                IEnumerable<Evento> eventos = await _context.Eventos.ToListAsync();
                if (eventos is not null)
                {
                    return Ok(eventos);
                }
                return NotFound("Não há eventos cadastrados");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + "- " + error);
            }
            

            
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Evento>> GetAlunoById(int id)
        {
            try
            {
                var aluno = await _context.Eventos.FindAsync(id);
                if (aluno is not null)
                {
                    return Ok(aluno);
                }
                return NotFound($"Não há aluno cadastrado com id -> {id}");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message + "- " + error);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Create(Evento evento)
        {
            try
            {
                _context.Eventos.Add(evento);
                await _context.SaveChangesAsync();
                return CreatedAtRoute(nameof(GetAlunoById), new {id =evento.EventoId},evento);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message + "- " + error);
            }
        }
    }
}
