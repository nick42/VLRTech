using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyEvent.WebApp.Controllers
{
    [Produces("application/json")]
    //[Route("api/GenericBase")]
    public class GenericBaseController<TModel> : Controller where TModel : Data.Models.ObjectWithRowID, new()
    {
        private readonly Data.Repositories.IModelDataRepository<TModel> m_oModelDataRepository;

        public GenericBaseController(Data.Repositories.IModelDataRepository<TModel> oModelDataRepository)
        {
            m_oModelDataRepository = oModelDataRepository;
        }

        public virtual IEnumerable<TModel> GetAll()
        {
            return m_oModelDataRepository.GetAll();
        }

        public virtual async Task<IActionResult> GetItem(/*[FromRoute]*/ Guid id)
        {
            var oInstance = await m_oModelDataRepository.FindByIDAsync(id);

            if (oInstance == null)
            {
                return NotFound();
            }

            return Ok(oInstance);
        }

        public virtual async Task<IActionResult> UpdateItem(/*[FromRoute]*/ Guid id, /*[FromBody]*/ TModel oInstance)
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

        public virtual async Task<IActionResult> AddItem(/*[FromBody]*/ TModel oInstance)
        {
            await m_oModelDataRepository.AddAsync(ref oInstance);
            await m_oModelDataRepository.SaveChangesAsync();

            return CreatedAtAction("GetItem", new { id = oInstance.idRowID }, oInstance);
        }

        public virtual async Task<IActionResult> DeleteItem(/*[FromRoute]*/ Guid id)
        {
            await m_oModelDataRepository.DeleteByIDAsync(id);
            await m_oModelDataRepository.SaveChangesAsync();

            return NoContent();
        }

        public virtual IActionResult GetPrototype()
        {
            return Ok(new TModel());
        }
    }
}