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
    public class AddressInfoController : Controller
    {
        private readonly Data.Repositories.IModelDataRepository<Data.Models.AddressInfo> m_oModelDataRepository;

        public AddressInfoController(Data.Repositories.IModelDataRepository<Data.Models.AddressInfo> oModelDataRepository)
        {
            m_oModelDataRepository = oModelDataRepository;
        }

        // GET: api/AddressInfo
        [HttpGet]
        public IEnumerable<AddressInfo> GetAddressInfo()
        {
            return m_oModelDataRepository.GetAll();
        }

        // GET: api/AddressInfo/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressInfo([FromRoute] Guid id)
        {
            var oInstance = await m_oModelDataRepository.FindByIDAsync(id);

            if (oInstance == null)
            {
                return NotFound();
            }

            return Ok(oInstance);
        }

        // PUT: api/AddressInfo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddressInfo([FromRoute] Guid id, [FromBody] AddressInfo oInstance)
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

        // POST: api/AddressInfo
        [HttpPost]
        public async Task<IActionResult> PostAddressInfo([FromBody] AddressInfo oInstance)
        {
            await m_oModelDataRepository.AddAsync(ref oInstance);
            await m_oModelDataRepository.SaveChangesAsync();

            return CreatedAtAction("GetAddressInfo", new { id = oInstance.idRowID }, oInstance);
        }

        // DELETE: api/AddressInfo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddressInfo([FromRoute] Guid id)
        {
            await m_oModelDataRepository.DeleteByIDAsync(id);
            await m_oModelDataRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}