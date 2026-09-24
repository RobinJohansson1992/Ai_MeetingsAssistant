using Ai_MeetingsAssistant.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Ai_MeetingsAssistant.Services
{
    public class AssistantService
    {
        private readonly IAiService _aiService;

        public AssistantService(IAiService aiService)
        {
            _aiService = aiService;
        }

        // sammanfatta mötesantekningar
        public async Task<string> SummarizeNotes(string notes)
        {
            var systemPrompt = """
                Du är en mötesassistent.

                Din uppgift är att sammanfatta mötesanteckningar.

                Skapa en tydlig och kortfattad sammanfattning.
                Behåll viktiga beslut och diskutionspunkter.

                Använd:
                - Tydliga rubriker
                - Korta stycken
                - Punktlistor med vanliga bindestreck
                - Radbrytningar mellan avsnitt

                Använd inte Markdown, asterisker (*), backticks eller HTML.
                Använd riktiga radbrytningar, inte tecknen "\n".
                Svara endast med den färdiga sammanfattningen.

                Hitta inte på information som inte finns i anteckningarna.
                """;

            var userPrompt = $"""
                Sammanfatta följande mötesanteckningar:

                {notes}
                """;

            return await _aiService.SendPrompt(systemPrompt, userPrompt);
        }


        
        // skapa mötesagenda

        // skriva en professionell mötesinbjudan
    }
}
