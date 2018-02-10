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
    public class AddressInfoController : GenericBaseController<Data.Models.AddressInfo>
    {
        public AddressInfoController(Data.Repositories.IModelDataRepository<Data.Models.AddressInfo> oModelDataRepository)
            : base(oModelDataRepository)
        {}

        // GET: api/AddressInfo
        [HttpGet]
        public override IEnumerable<AddressInfo> GetAll() => base.GetAll();

        // GET: api/AddressInfo/5
        [HttpGet("{id}")]
        public override async Task<IActionResult> GetItem([FromRoute] Guid id) => await base.GetItem(id);

        // PUT: api/AddressInfo/5
        [HttpPut("{id}")]
        public override async Task<IActionResult> UpdateItem([FromRoute] Guid id, [FromBody] AddressInfo oInstance) => await base.UpdateItem(id, oInstance);

        // POST: api/AddressInfo
        [HttpPost]
        public override async Task<IActionResult> AddItem([FromBody] AddressInfo oInstance) => await base.AddItem(oInstance);

        // DELETE: api/AddressInfo/5
        [HttpDelete("{id}")]
        public override async Task<IActionResult> DeleteItem([FromRoute] Guid id) => await base.DeleteItem(id);

        [HttpGet("prototype")]
        public override IActionResult GetPrototype() => base.GetPrototype();
    }
}