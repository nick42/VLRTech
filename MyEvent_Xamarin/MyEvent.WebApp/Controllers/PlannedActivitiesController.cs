using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyEvent.WebApp.Data.Models;

namespace MyEvent.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Filters.ValidateModelFilter]
    public class PlannedActivityController : Controller
    {
        private readonly Data.Repositories.IModelDataRepository<Data.Models.PlannedActivity> m_oModelDataRepository;

        public PlannedActivityController(Data.Repositories.IModelDataRepository<Data.Models.PlannedActivity> oModelDataRepository)
        {
            m_oModelDataRepository = oModelDataRepository;
        }

        // GET: api/PlannedActivity
        [HttpGet]
        public IEnumerable<PlannedActivity> Get()
        {
            return m_oModelDataRepository.GetAll();
        }

        // GET: api/PlannedActivity/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlannedActivity([FromRoute] Guid id)
        {
            var oInstance = await m_oModelDataRepository.FindByIDAsync(id);

            if (oInstance == null)
            {
                return NotFound();
            }

            return Ok(oInstance);
        }

        // POST: api/PlannedActivity
        [HttpPost]
        public async Task<IActionResult> PostPlannedActivity([FromBody] PlannedActivity oInstance)
        {
            await m_oModelDataRepository.AddAsync(ref oInstance);
            await m_oModelDataRepository.SaveChangesAsync();

            return CreatedAtAction("GetEvent", new { id = oInstance.idRowID }, oInstance);
        }

        // PUT: api/PlannedActivity/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlannedActivity([FromRoute] Guid id, [FromBody] PlannedActivity oInstance)
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

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlannedActivity([FromRoute] Guid id)
        {
            await m_oModelDataRepository.DeleteByIDAsync(id);
            await m_oModelDataRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
