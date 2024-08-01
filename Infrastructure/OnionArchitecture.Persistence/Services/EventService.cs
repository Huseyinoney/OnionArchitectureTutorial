using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Application.Abstractions.Services;
using OnionArchitecture.Application.DTOs;
using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Persistence.Services
{
    public class EventService : IEventService

    {
        private readonly AppDbContext context;

        public EventService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task CreateEventAsync(CreateEventDTO createEventDTO)
        {
            if (createEventDTO is not null)
            {
                var newEvent = new Event()
            {
                Title = createEventDTO.Title,
                Date = createEventDTO.Date,
                Location = createEventDTO.Location,
            };
                await context.AddAsync(newEvent);
                await context.SaveChangesAsync();

            }
            
        }

        public async Task<IEnumerable<EventDTO>> GetAllEventsAsync(Pagination pagination)
        {
            return await context.Events
                .AsNoTracking()
                .Select(e => new EventDTO()
            {
                Title = e.Title,
                Date = e.Date,
                Location = e.Location,
            })
                  .Skip(pagination.PageCount * pagination.ItemCount)
                  .Take(pagination.ItemCount)
                  .ToListAsync();
        }
    }
}
