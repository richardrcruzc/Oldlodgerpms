using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LodgerPms.Service.Departments.Api.Infrastructure;
using Microsoft.Extensions.Options;
using LodgerPms.Departments.Api.IntegrationEvents;
using Microsoft.EntityFrameworkCore;
using LodgerPms.Departments.Api.Model;
using LodgerPms.Departments.Api.ViewModel;
using LodgerPms.Departments.Api.IntegrationEvents.Events;

namespace LodgerPms.Departments.Api.Controllers
{
    public class DepartmentGroupController : ControllerBase
    {
        private readonly DepartmentContext _context;
        private readonly IOptionsSnapshot<Settings> _settings;
        private readonly IDepartmentIntegrationEventService _departmentIntegrationEventService;

        public DepartmentGroupController(DepartmentContext context, IOptionsSnapshot<Settings> settings, IDepartmentIntegrationEventService departmentIntegrationEventService)
        {
            _context = context;
            _departmentIntegrationEventService = departmentIntegrationEventService;
            _settings = settings;

            ((DbContext)context).ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }


        // GET api/v1/[controller]/items[?pageSize=3&pageIndex=10]
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Items([FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        {
            var totalItems = await _context.DepartmentGroups
                .LongCountAsync();

            var itemsOnPage = await _context.DepartmentGroups
                .OrderBy(c => c.Description)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();

            // itemsOnPage = ComposePicUri(itemsOnPage);

            var model = new PaginatedItemsViewModel<DepartmentGroup>(
                pageIndex, pageSize, totalItems, itemsOnPage);

            return Ok(model);
        }

        // GET api/v1/[controller]/items/withname/samplename[?pageSize=3&pageIndex=10]
        [HttpGet]
        [Route("[action]/withname/{name:minlength(1)}")]
        public async Task<IActionResult> Items(string description, [FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        {

            var totalItems = await _context.DepartmentGroups
                .Where(c => c.Description.StartsWith(description))
                .LongCountAsync();

            var itemsOnPage = await _context.DepartmentGroups
                .Where(c => c.Description.StartsWith(description))
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();

            // itemsOnPage = ComposePicUri(itemsOnPage);

            var model = new PaginatedItemsViewModel<DepartmentGroup>(
                pageIndex, pageSize, totalItems, itemsOnPage);

            return Ok(model);
        }

        


        //POST api/v1/[controller]/update
        [Route("update")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody]DepartmentGroup deptoToUpdate)
        {
            var depto = await _context.DepartmentGroups.SingleOrDefaultAsync(i => i.Id == deptoToUpdate.Id);
            if (depto == null) return NotFound();
            var raiseDeptoNameChangedEvent = depto.Description != deptoToUpdate.Description;
            var oldName = depto.Description;

            // Update current department
            depto = deptoToUpdate;
            _context.DepartmentGroups.Update(depto);

            if (raiseDeptoNameChangedEvent) // Save and publish integration event if Description has changed
            {
                //Create Integration Event to be published through the Event Bus
                var descriptionChangedEvent = new DepartmentNameChangedIntegrationEvent(depto.Id, deptoToUpdate.Description, oldName);

                // Achieving atomicity between original Catalog database operation and the IntegrationEventLog thanks to a local transaction
                await _departmentIntegrationEventService.SaveEventAndDeptoContextChangesAsync(descriptionChangedEvent);

                // Publish through the Event Bus and mark the saved event as published
                await _departmentIntegrationEventService.PublishThroughEventBusAsync(descriptionChangedEvent);
            }
            else // Save updated product
            {
                await _context.SaveChangesAsync();
            }

            return Ok();
        }

        //POST api/v1/[controller]/create
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]DepartmentGroup depto)
        {
            var newDepto = DepartmentGroup.Create(depto.Code, depto.Description);

            _context.DepartmentGroups.Add(newDepto);

            await _context.SaveChangesAsync();

            return Ok();
        }

        //DELETE api/v1/[controller]/id
        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var product = _context.DepartmentGroups.SingleOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            _context.DepartmentGroups.Remove(product);
            await _context.SaveChangesAsync();

            return Ok();
        }



    }
}