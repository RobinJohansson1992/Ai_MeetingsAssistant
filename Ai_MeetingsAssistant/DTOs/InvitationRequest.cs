using System.ComponentModel.DataAnnotations;

namespace Ai_MeetingsAssistant.DTOs
{
    public class InvitationRequest
    {
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Week { get; set; }
        [Required]
        public string? WeekDay { get; set; }
        [Required]
        public string? Location { get; set; }
        [Required]
        public string? Purpose { get; set; }

    }
}
