using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using LodgerPms.Property.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using LodgerPms.Property.Api.ViewModel;
using LodgerPms.Domain.Rooms;

namespace LodgerPms.Property.Api.csproj.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    public class BedTypeController : ControllerBase
    {
        private readonly PropertyContext _propertyContext;
        private readonly PropertySettings _settings;
        private readonly IMediator _mediator;

        public BedTypeController(PropertyContext propertyContext, PropertySettings settings, IMediator mediator)
        {
            _propertyContext = propertyContext;
            _settings = settings;
            _mediator = mediator;
        }

        // GET api/v1/[controller]/items[?pageSize=3&pageIndex=10]
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Items([FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        {
            var totalItems = await _propertyContext.BedTypes.LongCountAsync();

            var itemsOnPage = await _propertyContext.BedTypes
               .OrderBy(c => c.Description)
               .Skip(pageSize * pageIndex)
               .Take(pageSize)
               .ToListAsync();            

            var model = new PaginatedItemsViewModel<BedType>(
                pageIndex, pageSize, totalItems, itemsOnPage);

            return Ok(model);

        }
        [HttpGet]
        [Route("items/{id:int}")]
        public async Task<IActionResult> GetItemById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            var item = await _propertyContext.BedTypes.SingleOrDefaultAsync(ci => ci.Id == id);
            if (item != null)
            {
                return Ok(item);
            }

            return NotFound();
        }

        // GET api/v1/[controller]/items/withdescription/sampledescription[?pageSize=3&pageIndex=10]
        [HttpGet]
        [Route("[action]/withdescription/{name:minlength(1)}")]
        public async Task<IActionResult> Items(string description, [FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        {
            var totalItems = await _propertyContext.BedTypes
               .Where(c => c.Description.StartsWith(description))
               .LongCountAsync();

            var itemsOnPage = await _propertyContext.BedTypes
                .Where(c => c.Description.StartsWith(description))
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();
             

            var model = new PaginatedItemsViewModel<BedType>(
                pageIndex, pageSize, totalItems, itemsOnPage);

            return Ok(model);
        }

        //PUT api/v1/[controller]/items
        [Route("items")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]BedType bedType)
        {
            var tmp = await _propertyContext.BedTypes.SingleOrDefaultAsync(b => b.Id == bedType.Id);

            if (tmp == null)
            {
                return NotFound(new { Message = $"Item with id {bedType.Id} not found." });
            }
            _propertyContext.Update(bedType);
            await _propertyContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItemById), new { id = bedType.Id }, null);
        }
        //POST api/v1/[controller]/items
        [Route("items")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]BedType bedType)
        {
            var bed = BedType.Create(bedType.Code, bedType.Description);
            
            _propertyContext.BedTypes.Add(bed);

            await _propertyContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItemById), new { id = bed.Id }, null);
        }
        //DELETE api/v1/[controller]/id
        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var bedtype = _propertyContext.BedTypes.SingleOrDefault(x => x.Id == id);

            if (bedtype == null)
            {
                return NotFound();
            }

            _propertyContext.BedTypes.Remove(bedtype);

            await _propertyContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
