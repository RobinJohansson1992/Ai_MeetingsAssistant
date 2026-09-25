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
        public async Task<string> SummarizeMeetingNotes(string notes)
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

            return await _aiService.SendPrompt(
                systemPrompt, 
                userPrompt);
        }

        // skapa mötesagenda
        public async Task<string> CreateMeetingAgenda(string title, string purpose, int durationInMinutes)
        {
            var systemPrompt = """
                Du är en mötesassistent.

                Din uppgift är att hjälpa användaren att skapa en 
                agenda för ett möte baserad på det användaren skriver in.

                Du ska ta fram tydliga punkter och lägga dom i en logisk ordning
                med ett ungefärligt tidsintervall till varje punkt.

                Hitta inte på information som inte finns i anteckningarna.
                """;

            var userPrompt = $"""
                Skapa en agenda till följande anteckningar:

                Mötestitel:
                {title}

                Syfte:
                {purpose}

                Mötestid:
                {durationInMinutes} minuter
                """;

            return await _aiService.SendPrompt(
                systemPrompt, 
                userPrompt);
        }

        // skriva en professionell mötesinbjudan
        public async Task<string> CreateMeetingInvitation(
            string title,
            string week,
            string weekDay,
            string location,
            string purpose)
        {
            var systemPrompt = """
                Du är en mötesassistent.

                Skriv en professionel men trevlig mötesinbjudan baserad på användarens input.

                Inkludera:
                - hälsning
                - mötets namn
                - datum och tid
                - plats
                - sytfe
                - avsluta meddelandet med 'Välkommen!'
                
                Hitta inte på information som saknas, svara endast med själva inbjudan, ingenting annat.
                """;

            var userPrompt = $"""
                Skapa en mötesinbjudan med följande information:

                Möte:
                {title}

                Vecka:
                {week}

                Dag:
                {weekDay}

                Plats:
                {location}

                Syfte:
                {purpose}
                """;

            return await _aiService.SendPrompt(
                systemPrompt,
                userPrompt);
        }
    }
}
