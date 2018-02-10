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
    public class LocationInfoController : GenericBaseController<Data.Models.LocationInfo>
    {
        public LocationInfoController(Data.Repositories.IModelDataRepository<Data.Models.LocationInfo> oModelDataRepository)
            : base(oModelDataRepository)
        {
        }

        // GET: api/LocationInfo
        [HttpGet]
        public override IEnumerable<LocationInfo> GetAll() => base.GetAll();

        // GET: api/LocationInfo/5
        [HttpGet("{id}")]
        public override async Task<IActionResult> GetItem([FromRoute] Guid id) => await base.GetItem(id);

        // POST: api/LocationInfo
        [HttpPost]
        public override async Task<IActionResult> UpdateItem([FromRoute] Guid id, [FromBody] LocationInfo oInstance) => await base.UpdateItem(id, oInstance);

        // PUT: api/LocationInfo/5
        [HttpPut("{id}")]
        public override async Task<IActionResult> AddItem([FromBody] LocationInfo oInstance) => await base.AddItem(oInstance);

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public override async Task<IActionResult> DeleteItem([FromRoute] Guid id) => await base.DeleteItem(id);

        [HttpGet("prototype")]
        public override IActionResult GetPrototype() => base.GetPrototype();
    }
}
