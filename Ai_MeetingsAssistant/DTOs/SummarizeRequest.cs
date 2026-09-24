using System.ComponentModel.DataAnnotations;

namespace Ai_MeetingsAssistant.DTOs
{
    public class SummarizeRequest
    {
        [Required]
        [MinLength(5)]
        public string Notes { get; set; } = "";
    }
}
