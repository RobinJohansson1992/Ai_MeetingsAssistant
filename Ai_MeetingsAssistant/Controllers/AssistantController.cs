using Ai_MeetingsAssistant.DTOs;
using Ai_MeetingsAssistant.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ai_MeetingsAssistant.Controllers
{
    [ApiController]
    [Route("api/ai")]
    public class AssistantController : Controller
    {
        private readonly AssistantService _assistantService;

        public AssistantController(AssistantService assistantService) 
        {
            _assistantService = assistantService;
        }
        // sammanfatta mötesantekningar
        [HttpPost("summarize")]
        public async Task<IActionResult> SummarizeNotes(SummarizeRequest request)
        {
            var result = await _assistantService.SummarizeNotes(request.Notes);

            return Ok(new
            {
                result
            });
        }
        // skapa mötesagenda
        [HttpPost("agenda")]
        public async Task<IActionResult> CreateMeetingAgenda(AgendaRequest request)
        {
            var result = await _assistantService.CreateMeetingAgenda(request.Title, request.Purpose, request.DurationInMinutes);

            return Ok(new
            {
                result
            });
        }

        // skriva en professionell mötesinbjudan
    }
}
