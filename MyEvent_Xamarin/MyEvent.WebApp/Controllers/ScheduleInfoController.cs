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
    [Filters.ValidateModelFilter]
    public class ScheduleInfoController : Controller
    {
        private readonly Data.Repositories.IModelDataRepository<Data.Models.ScheduleInfo> m_oModelDataRepository;

        public ScheduleInfoController(Data.Repositories.IModelDataRepository<Data.Models.ScheduleInfo> oModelDataRepository)
        {
            m_oModelDataRepository = oModelDataRepository;
        }

        // GET: api/ScheduleInfo
        [HttpGet]
        public IEnumerable<ScheduleInfo> GetScheduleInfo()
        {
            return m_oModelDataRepository.GetAll();
        }

        // GET: api/ScheduleInfo/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetScheduleInfo([FromRoute] Guid id)
        {
            var oInstance = await m_oModelDataRepository.FindByIDAsync(id);

            if (oInstance == null)
            {
                return NotFound();
            }

            return Ok(oInstance);
        }

        // PUT: api/ScheduleInfo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScheduleInfo([FromRoute] Guid id, [FromBody] ScheduleInfo oInstance)
        {
            if (id != oInstance.idRowID)
            {
                return BadRequest();
            }

            // TODO: Catch update errors...
            await m_oModelDataRepository.UpdateAsync(oInstance);
            await m_oModelDataRepository.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/ScheduleInfo
        [HttpPost]
        public async Task<IActionResult> PostScheduleInfo([FromBody] ScheduleInfo oInstance)
        {
            await m_oModelDataRepository.AddAsync(ref oInstance);
            await m_oModelDataRepository.SaveChangesAsync();

            return CreatedAtAction("GetScheduleInfo", new { id = oInstance.idRowID }, oInstance);
        }

        // DELETE: api/ScheduleInfo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScheduleInfo([FromRoute] Guid id)
        {
            await m_oModelDataRepository.DeleteByIDAsync(id);
            await m_oModelDataRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}