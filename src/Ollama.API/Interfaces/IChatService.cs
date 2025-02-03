namespace Ollama.API.Interfaces;

public interface IChatService
{
    Task<ChatCompletion> CompleteChat(ChatPrompt prompt);
    Task<List<ChatMessage>> ChatHistory(ChatPrompt prompt);
}
