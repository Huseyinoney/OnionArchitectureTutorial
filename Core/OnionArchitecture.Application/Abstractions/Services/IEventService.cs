using OnionArchitecture.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Abstractions.Services
{
    public interface IEventService
    {
        Task CreateEventAsync(CreateEventDTO createEventDTO);
        
        Task <IEnumerable<EventDTO>> GetAllEventsAsync(Pagination pagination);
    }
}
