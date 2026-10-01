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
        public async Task<IActionResult> SummarizeMeetingNotes(SummarizeRequest request)
        {
            try
            {
                var result = await _assistantService.SummarizeMeetingNotes(request.Notes);

                return Ok(new
                {
                    result
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel vid sammanfattning: {ex.Message}");

                return StatusCode(500, new
                {
                    error = "Kunde inte skapa sammanfattningen."
                });
            }
        }
        // skapa mötesagenda
        [HttpPost("agenda")]
        public async Task<IActionResult> CreateMeetingAgenda(AgendaRequest request)
        {
            try
            {

            var result = await _assistantService.CreateMeetingAgenda(request.Title, request.Purpose, request.DurationInMinutes);

            return Ok(new
            {
                result
            });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel vid skapande av agenda: {ex.Message}");

                return StatusCode(500, new
                {
                    error = "Kunde inte skapa agenda."
                });
            }
        }

        // skriva en professionell mötesinbjudan
        [HttpPost("invitation")]
        public async Task<IActionResult> CreateMeetingInvitation(InvitationRequest request)
        {
            try
            {

            var result = await _assistantService.CreateMeetingInvitation(request.Title, request.Week, request.WeekDay, request.Time, request.Location, request.Purpose);

            return Ok(new
            {
                result
            });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel vid skapande av inbjudan: {ex.Message}");

                return StatusCode(500, new
                {
                    error = "Kunde inte skapa inbjudan."
                });
            }
        }
    }
}
