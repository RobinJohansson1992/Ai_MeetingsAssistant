using System.ComponentModel.DataAnnotations;

namespace Ai_MeetingsAssistant.DTOs
{
    public class AgendaRequest
    {
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Purpose { get; set; }
        [Range(1, 240)]
        public int DurationInMinutes { get; set; }

    }
}
