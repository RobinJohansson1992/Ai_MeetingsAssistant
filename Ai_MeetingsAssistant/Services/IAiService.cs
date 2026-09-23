namespace Ai_MeetingsAssistant.Services
{
    public interface IAiService
    {
        Task<string> SendPrompt(string systemPrompt, string userPrompt);

    }
}
