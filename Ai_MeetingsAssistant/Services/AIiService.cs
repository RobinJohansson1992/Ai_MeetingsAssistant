namespace Ai_MeetingsAssistant.Services
{
    public interface AIiService
    {
        Task<string> SendPrompt(string systemPrompt, string userPrompt);

    }
}
