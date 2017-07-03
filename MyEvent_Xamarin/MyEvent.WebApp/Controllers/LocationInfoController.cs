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
    public class LocationInfoController : Controller
    {
        private readonly Data.Repositories.IModelDataRepository<Data.Models.LocationInfo> m_oModelDataRepository;

        public LocationInfoController(Data.Repositories.IModelDataRepository<Data.Models.LocationInfo> oModelDataRepository)
        {
            m_oModelDataRepository = oModelDataRepository;
        }

        // GET: api/LocationInfo
        [HttpGet]
        public IEnumerable<LocationInfo> Get()
        {
            return m_oModelDataRepository.GetAll();
        }

        // GET: api/LocationInfo/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationInfo([FromRoute] Guid id)
        {
            var oInstance = await m_oModelDataRepository.FindByIDAsync(id);

            if (oInstance == null)
            {
                return NotFound();
            }

            return Ok(oInstance);
        }

        // POST: api/LocationInfo
        [HttpPost]
        public async Task<IActionResult> PostLocationInfo([FromBody] LocationInfo oInstance)
        {
            await m_oModelDataRepository.AddAsync(ref oInstance);
            await m_oModelDataRepository.SaveChangesAsync();

            return CreatedAtAction("GetEvent", new { id = oInstance.idRowID }, oInstance);
        }

        // PUT: api/LocationInfo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocationInfo([FromRoute] Guid id, [FromBody] LocationInfo oInstance)
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
        public async Task<IActionResult> DeleteLocationInfo([FromRoute] Guid id)
        {
            await m_oModelDataRepository.DeleteByIDAsync(id);
            await m_oModelDataRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
