
using LodgerPms.Property.Api.Application.Commands;
using LodgerPms.Property.Api.Infrastructure.Commands;
using LodgerPms.Property.Api.Infrastructure.Data;
using LodgerPms.Property.Api.Infrastructure.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LodgerPms.Property.Api.ViewModel;
using LodgerPms.Domain.Rooms;
using LodgerPms.Property.Api.Repository;

namespace LodgerPms.Property.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    public class RoomInfoController : ControllerBase       
    {
        private readonly IMediator _mediator;
        private readonly IRoomInfoRepository _roomRepository;
        private readonly PropertySettings _settings;
        private readonly IIdentityService _identityService;

        public  RoomInfoController (IMediator mediator, IRoomInfoRepository roomRepository, PropertySettings settings, IIdentityService identityService)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _roomRepository = roomRepository;
            _settings = settings;
            _identityService = identityService;
        }


        [Route("new")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateRoomInfoCommand command, [FromHeader(Name = "x-requestid")] string requestId)
        {
            bool commandResult = false;
            if (Guid.TryParse(requestId, out Guid guid) && guid != Guid.Empty)
            {
                var requestCreateOrder = new IdentifiedCommand<CreateRoomInfoCommand, bool>(command, guid);
                commandResult = await _mediator.SendAsync(requestCreateOrder);
            }
            else
            {
                // If no x-requestid header is found we process the order anyway. This is just temporary to not break existing clients
                // that aren't still updated. When all clients were updated this could be removed.
                commandResult = await _mediator.SendAsync(command);
            }

            return commandResult ? (IActionResult)Ok() : (IActionResult)BadRequest();

        }
        [Route("{roomInfoId:string}")]
        [HttpGet]
        public async Task<IActionResult> GetRoomInfo(string id)
        {
            try
            {
                var room = await _roomRepository.GetAsync(id);                    

                return Ok(room);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // GET api/v1/[controller]/items[?pageSize=3&pageIndex=10]
        [Route("[action]")]
        [HttpGet]       
        public async Task<IActionResult> Items([FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        {
            var model = await _roomRepository.GetAsync(pageSize, pageIndex);

            return Ok(model);

    }



    //private List<RoomInfo> ChangeUriPlaceholder(List<RoomInfo> items)
    //{
    //    var baseUri = _settings.ExternalCatalogBaseUrl;

    //    items.ForEach(x =>
    //    {
    //        x.RoomPictures = x.RoomPictures.Replace("http://externalcatalogbaseurltobereplaced", baseUri);
    //    });

    //    return items;
    //}

}
}
