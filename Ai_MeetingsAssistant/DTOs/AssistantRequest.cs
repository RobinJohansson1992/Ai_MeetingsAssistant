using System.ComponentModel.DataAnnotations;

namespace Ai_MeetingsAssistant.DTOs
{
    public class AssistantRequest
    {
        [Required]
        [MinLength(5)]
        public string? notes { get; set; }
    }
}
