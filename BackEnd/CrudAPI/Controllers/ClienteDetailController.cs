using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudAPI.Models;

namespace CrudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteDetailController : ControllerBase
    {
        private readonly ClienteDetailContext _context;

        public ClienteDetailController(ClienteDetailContext context)
        {
            _context = context;
        }

        // GET: api/ClienteDetail
        [HttpGet]
        public IEnumerable<ClienteDetail> GetClienteDetails()
        {
            return _context.ClienteDetails;
        }

        // GET: api/ClienteDetail/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClienteDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clienteDetail = await _context.ClienteDetails.FindAsync(id);

            if (clienteDetail == null)
            {
                return NotFound();
            }

            return Ok(clienteDetail);
        }

        // PUT: api/ClienteDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClienteDetail([FromRoute] int id, [FromBody] ClienteDetail clienteDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clienteDetail.id)
            {
                return BadRequest();
            }

            _context.Entry(clienteDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ClienteDetail
        [HttpPost]
        public async Task<IActionResult> PostClienteDetail([FromBody] ClienteDetail clienteDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Deu erro em");
            }

            _context.ClienteDetails.Add(clienteDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClienteDetail", new { id = clienteDetail.id }, clienteDetail);
        }

        // DELETE: api/ClienteDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClienteDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clienteDetail = await _context.ClienteDetails.FindAsync(id);
            if (clienteDetail == null)
            {
                return NotFound();
            }

            _context.ClienteDetails.Remove(clienteDetail);
            await _context.SaveChangesAsync();

            return Ok(clienteDetail);
        }

        private bool ClienteDetailExists(int id)
        {
            return _context.ClienteDetails.Any(e => e.id == id);
        }
    }
}