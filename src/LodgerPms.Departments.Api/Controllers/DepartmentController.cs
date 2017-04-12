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
    [Route("api/v1/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentContext _deptoContext;
        private readonly IOptionsSnapshot<Settings> _settings;
        private readonly IDepartmentIntegrationEventService _departmentIntegrationEventService;

        public DepartmentController(DepartmentContext Context, IOptionsSnapshot<Settings> settings, IDepartmentIntegrationEventService departmentIntegrationEventService)
        {
            _deptoContext = Context;
            _departmentIntegrationEventService = departmentIntegrationEventService;
            _settings = settings;

            ((DbContext)Context).ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }


        // GET api/v1/[controller]/items[?pageSize=3&pageIndex=10]
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Items([FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        {
            var totalItems = await _deptoContext.Departments
                .LongCountAsync();

            var itemsOnPage = await _deptoContext.Departments
                .OrderBy(c => c.Description)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();

           // itemsOnPage = ComposePicUri(itemsOnPage);

            var model = new PaginatedItemsViewModel<Department>(
                pageIndex, pageSize, totalItems, itemsOnPage);

            return Ok(model);
        }

        // GET api/v1/[controller]/items/withname/samplename[?pageSize=3&pageIndex=10]
        [HttpGet]
        [Route("[action]/withname/{name:minlength(1)}")]
        public async Task<IActionResult> Items(string description, [FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        {

            var totalItems = await _deptoContext.Departments
                .Where(c => c.Description.StartsWith(description))
                .LongCountAsync();

            var itemsOnPage = await _deptoContext.Departments
                .Where(c => c.Description.StartsWith(description))
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();

           // itemsOnPage = ComposePicUri(itemsOnPage);

            var model = new PaginatedItemsViewModel<Department>(
                pageIndex, pageSize, totalItems, itemsOnPage);

            return Ok(model);
        }

        // GET api/v1/[controller]/items/type/1/group/null[?pageSize=3&pageIndex=10]
        [HttpGet]
        [Route("[action]/type/{departmentTypeId}/brand/{departmentGroupId}")]
        public async Task<IActionResult> Items(int? departmentTypeId, string departmentGroupId, [FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        {
            var root = (IQueryable<Department>)_deptoContext.Departments;

            if (departmentTypeId.HasValue)
            {
                root = root.Where(ci => ci.DepartmentType ==(DepartmentType)departmentTypeId);
            }

            if (departmentGroupId !=null)
            {
                root = root.Where(ci => ci.DepartmentGroup.Id == departmentGroupId);
            }

            var totalItems = await root
                .LongCountAsync();

            var itemsOnPage = await root
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();

           // itemsOnPage = ComposePicUri(itemsOnPage);

            var model = new PaginatedItemsViewModel<Department>(
                pageIndex, pageSize, totalItems, itemsOnPage);

            return Ok(model);
        }

        // GET api/v1/[controller]/DepartmentGroups
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> DepartmentGroups()
        {
            var items = await _deptoContext.DepartmentGroups
                .ToListAsync();

            return Ok(items);
        }


        //POST api/v1/[controller]/update
        [Route("update")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody]Department deptoToUpdate)
        {
            var depto = await _deptoContext.Departments.SingleOrDefaultAsync(i => i.Id == deptoToUpdate.Id);
            if (depto == null) return NotFound();
            var raiseDeptoNameChangedEvent = depto.Description != deptoToUpdate.Description;
            var oldName = depto.Description;

            // Update current department
            depto = deptoToUpdate;
            _deptoContext.Departments.Update(depto);

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
                await _deptoContext.SaveChangesAsync();
            }

            return Ok();
        }

        //POST api/v1/[controller]/create
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Department depto)
        {
            var newDepto = Department.Create(depto.Id, depto.DepartmentGroup, depto.DepartmentType, depto.Description, depto.ApplyTax, depto.Amount, depto.Percentage);

            _deptoContext.Departments.Add(newDepto);

            await _deptoContext.SaveChangesAsync();

            return Ok();
        }

        //DELETE api/v1/[controller]/id
        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var product = _deptoContext.Departments.SingleOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            _deptoContext.Departments.Remove(product);
            await _deptoContext.SaveChangesAsync();

            return Ok();
        }



        //private List<Department> ComposePicUri(List<Department> items)
        //{
        //    var baseUri = _settings.Value.ExternalDepartmentBaseUrl;
        //    items.ForEach(x =>
        //    {
        //        x.PictureUri = x.PictureUri.Replace("http://externalcatalogbaseurltobereplaced", baseUri);
        //    });

        //    return items;
        //}
    }
}