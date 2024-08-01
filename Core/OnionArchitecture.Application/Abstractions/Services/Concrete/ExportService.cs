using OnionArchitecture.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Abstractions.Services.Concrete
{
    public class ExportService
    {
        private readonly ITextService textService;
        private readonly IFileService fileService;

        public ExportService(ITextService textService, IFileService fileService)
        {
            this.textService = textService;
            this.fileService = fileService;
        }

        public async Task ExportEventsAsync(IEnumerable<EventDTO> eventItems, string path)
        {
            var formattedText = textService.FormatTextForEvent(eventItems);
            formattedText.Insert(0, "Event Name - Event Date - Event Location\n");
            await fileService.SaveTextAsync(formattedText,path);
        }
    }
}
