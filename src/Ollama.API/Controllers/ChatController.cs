namespace Ollama.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly ILogger<ChatController> _logger;
    private readonly IChatService _chatService;

    public ChatController(ILogger<ChatController> logger,
        IChatService chatService)
    {
        _logger = logger;
        _chatService = chatService;
    }

    [HttpPost]
    public async Task<IActionResult> Chat(ChatPrompt chatPrompt)
    {
        try
        {
            var response = await _chatService.CompleteChat(chatPrompt);
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

        try
        {
            var response = await _chatService.ChatHistory(chatPrompt);
            return Ok(response.Select(m => new
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
}
