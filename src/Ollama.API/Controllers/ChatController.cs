using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.AI;
using Ollama.API.Models;

namespace Ollama.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly IChatClient _chatClient;
    private readonly ILogger<ChatController> _logger;
    private readonly IConfiguration _configuration;

    public ChatController(IChatClient chatClient, ILogger<ChatController> logger, IConfiguration configuration)
    {
        _chatClient = chatClient;
        _logger = logger;
        _configuration = configuration;
    }

    [HttpPost]
    public async Task<IActionResult> Chat(ChatPrompt chatPrompt)
    {
        var messages = GroundPrompt(chatPrompt);
        try
        {
            var response = await _chatClient.CompleteAsync(messages);
            return Ok(response.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing chat prompt");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost("chathistory")]
    public async Task<IActionResult> ChatHistory(ChatPrompt chatPrompt)
    {
        var messages = GroundPrompt(chatPrompt);
        try
        {
            var response = await _chatClient.CompleteAsync(messages);
            messages.Add(new ChatMessage(ChatRole.Assistant, response.Message.Contents));
            return Ok(messages.Select(m => new
            {
                Role = m.Role.ToString(),
                Message = m.Contents
            }));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing chat prompt");
            return StatusCode(500, "Internal server error");
        }
    }

    private List<ChatMessage> GroundPrompt(ChatPrompt chatPrompt)
    {
        return
        [
            new ChatMessage(ChatRole.User, chatPrompt.Message)
        ];
    }
}
