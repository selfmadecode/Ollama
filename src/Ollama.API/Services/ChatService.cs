namespace Ollama.API;

internal sealed class ChatService : IChatService
{
    private readonly IChatClient _chatClient;
    public ChatService(IChatClient chatClient)
    {
        _chatClient = chatClient;
    }

    public async Task<List<ChatMessage>> ChatHistory(ChatPrompt prompt)
    {
        var messages = GroundPrompt(prompt);

        var response = await _chatClient.CompleteAsync(messages);
        messages.Add(new ChatMessage(ChatRole.Assistant, response.Message.Contents));

        return messages;
    }

    public async Task<ChatCompletion> CompleteChat(ChatPrompt prompt)
    {
        var messages = GroundPrompt(prompt);

        return await _chatClient.CompleteAsync(messages);
    }

    private List<ChatMessage> GroundPrompt(ChatPrompt chatPrompt)
    {
        return
        [
            new ChatMessage(ChatRole.User, chatPrompt.Message)
        ];
    }
}
