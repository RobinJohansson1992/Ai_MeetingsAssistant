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

                Din uppgift är att sammanfatta mötesanteckningar på ett tydligt och strukturerat sätt.

                Skapa sammanfattningen enligt exakt denna struktur:

                SAMMANFATTNING
                En kort sammanfattande text om mötet.

                ANSVARSOMRÅDEN
                - Personens namn: ansvarsområde
                - Personens namn: ansvarsområde

                BESLUT
                - Beslut 1
                - Beslut 2

                VIKTIGA DISKUSSIONSPUNKTER
                - Punkt 1
                - Punkt 2

                Anpassa rubrikerna efter informationen i anteckningarna.
                Ta endast med rubriker som är relevanta. Om det exempelvis inte finns några ansvarsområden ska rubriken ANSVARSOMRÅDEN utelämnas.

                REGLER:
                - Använd vanliga versaler för rubriker.
                - Skriv varje rubrik på en egen rad.
                - Lägg en tom rad efter varje rubrik och mellan varje avsnitt.
                - Varje punkt ska börja på en ny rad med ett bindestreck följt av ett mellanslag.
                - Använd korta och tydliga formuleringar.
                - Lägg inte flera punkter på samma rad.
                - Använd inte Markdown.
                - Använd inte asterisker (*).
                - Använd inte backticks.
                - Använd inte HTML.
                - Använd inte numrerade listor.
                - Använd riktiga radbrytningar.
                - Svara endast med den färdiga sammanfattningen.

                Hitta inte på information som inte finns i mötesanteckningarna.
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

                REGLER:
                - Använd vanliga versaler för rubriker.
                - Skriv varje rubrik på en egen rad.
                - Lägg en tom rad efter varje rubrik och mellan varje avsnitt.
                - Varje punkt ska börja på en ny rad med ett bindestreck följt av ett mellanslag.
                - Använd korta och tydliga formuleringar.
                - Lägg inte flera punkter på samma rad.
                - Använd inte Markdown.
                - Använd inte asterisker (*).
                - Använd inte backticks.
                - Använd inte HTML.
                - Använd inte numrerade listor.
                - Använd riktiga radbrytningar.
                - Svara endast med den färdiga agendan.

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
            string time,
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

                REGLER:
                - Använd vanliga versaler för rubriker.
                - Skriv varje rubrik på en egen rad.
                - Lägg en tom rad efter varje rubrik och mellan varje avsnitt.
                - Varje punkt ska börja på en ny rad med ett bindestreck följt av ett mellanslag.
                - Använd korta och tydliga formuleringar.
                - Lägg inte flera punkter på samma rad.
                - Använd inte Markdown.
                - Använd inte asterisker (*).
                - Använd inte backticks.
                - Använd inte HTML.
                - Använd inte numrerade listor.
                - Använd riktiga radbrytningar.
                - Svara endast med en färdig inbjudan.
                
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

                Tid:
                {time}

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
