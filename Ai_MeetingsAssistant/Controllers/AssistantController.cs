using Ai_MeetingsAssistant.DTOs;
using Ai_MeetingsAssistant.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ai_MeetingsAssistant.Controllers
{
    [ApiController]
    public class AssistantController : Controller
    {
        private readonly AssistantService _assistantService;
        private readonly IAiService _aiService;

        public AssistantController(AssistantService assistantService, IAiService aiService) 
        {
            _assistantService = assistantService;
            _aiService = aiService;
        }
        // sammanfatta mötesantekningar
        public async Task<IActionResult> SummarizeNotes([FromBody]AssistantRequest request)
        {

        }
        // skapa mötesagenda

        // skriva en professionell mötesinbjudan
    }
}
