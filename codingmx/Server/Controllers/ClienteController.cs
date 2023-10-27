using codingmx.Server.Data;
using codingmx.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace codingmx.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public ClienteController(ApplicationDbContext context)
        {

            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> GetCliente()
        {
            var lista = await _context.Clientes.ToListAsync();
            return Ok(lista);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<Cliente>>> GetSingleCliente(int id)
        {
            var miobjeto = await _context.Clientes.FirstOrDefaultAsync(ob => ob.ClienteId == id);
            if (miobjeto == null)
            {
                return NotFound(" :/");
            }

            return Ok(miobjeto);
        }
        [HttpPost]

        public async Task<ActionResult<Cliente>> CreateCliente(Cliente objeto)
        {

            _context.Clientes.Add(objeto);
            await _context.SaveChangesAsync();
            return Ok(await GetDbCliente());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Cliente>>> UpdateCliente(Cliente objeto)
        {

            var DbObjeto = await _context.Clientes.FindAsync(objeto.ClienteId);
            if (DbObjeto == null)
                return BadRequest("no se encuentra");
            DbObjeto.ClienteNombre = objeto.ClienteNombre;


            await _context.SaveChangesAsync();

            return Ok(await _context.Clientes.ToListAsync());


        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Cliente>>> DeleteCliente(int id)
        {
            var DbObjeto = await _context.Clientes.FirstOrDefaultAsync(Ob => Ob.ClienteId == id);
            if (DbObjeto == null)
            {
                return NotFound("no existe :/");
            }

            _context.Clientes.Remove(DbObjeto);
            await _context.SaveChangesAsync();

            return Ok(await GetDbCliente());
        }


        private async Task<List<Cliente>> GetDbCliente()
        {
            return await _context.Clientes.ToListAsync();
        }
    }
}
