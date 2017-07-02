using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyEvent.WebApp.Data;
using MyEvent.WebApp.Data.Models;

namespace MyEvent.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class EventsController : Controller
    {
        private readonly Data.Repositories.IModelDataRepository<Data.Models.Event> m_oModelDataRepository;

        public EventsController(Data.Repositories.IModelDataRepository<Data.Models.Event> oModelDataRepository)
        {
            m_oModelDataRepository = oModelDataRepository;
        }

        // GET: api/Events
        [HttpGet]
        public IEnumerable<Event> GetEvent()
        {
            return m_oModelDataRepository.GetAll();
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var oInstance = await m_oModelDataRepository.FindByID(id);

            if (oInstance == null)
            {
                return NotFound();
            }

            return Ok(oInstance);
        }

        // PUT: api/Events/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent([FromRoute] Guid id, [FromBody] Event oInstance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != oInstance.idRowID)
            {
                return BadRequest();
            }

            // TODO: Catch update errors...
            await m_oModelDataRepository.Update(oInstance);
            await m_oModelDataRepository.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Events
        [HttpPost]
        public async Task<IActionResult> PostEvent([FromBody] Event oInstance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await m_oModelDataRepository.Add(ref oInstance);
            await m_oModelDataRepository.SaveChangesAsync();

            return CreatedAtAction("GetEvent", new { id = oInstance.idRowID }, oInstance);
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await m_oModelDataRepository.DeleteByID(id);
            await m_oModelDataRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}