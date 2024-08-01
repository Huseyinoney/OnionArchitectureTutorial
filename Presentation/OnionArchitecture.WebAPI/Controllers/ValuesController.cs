using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.Application.Abstractions.Services;
using OnionArchitecture.Application.Abstractions.Services.Concrete;
using OnionArchitecture.Application.DTOs;
using System.ComponentModel.Design;
using System.Reflection.Metadata;

namespace OnionArchitecture.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService eventService;
        private readonly ExportService exportService;

        public EventsController(IEventService eventService, ExportService exportService)
        {
            this.eventService = eventService;
            this.exportService = exportService;
        }

        [HttpGet]
        public ActionResult GetAllEvents(Pagination pagination ) 
        {
            var events = eventService.GetAllEventsAsync( pagination );
            return Ok( events );
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(CreateEventDTO createEventDTO)
        {
            await eventService.CreateEventAsync(createEventDTO);
            return Ok();
        }
    }
}
