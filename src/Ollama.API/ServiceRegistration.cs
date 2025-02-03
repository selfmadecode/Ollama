namespace Ollama.API;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddScoped<IChatService, ChatService>();

        builder.AddAIServices();
    }

    public static void AddAIServices(this IHostApplicationBuilder builder)
    {
        var loggerFactory = builder.Services.BuildServiceProvider().GetService<ILoggerFactory>();

        string? ollamaEndpoint = builder.Configuration["AI:Ollama:Endpoint"];

        if (!string.IsNullOrWhiteSpace(ollamaEndpoint))
        {
            builder.Services.
                AddChatClient(new OllamaChatClient(ollamaEndpoint, builder.Configuration["AI:Ollama:ChatModel"] ?? "llama3.1"))
                .UseFunctionInvocation()
                .UseOpenTelemetry(configure: t => t.EnableSensitiveData = true)
                .UseLogging(loggerFactory)
                .Build();
        }
    }
}

