using LLama.Common;
using LLama;

namespace ChatWinForms;

internal class ChatBot
{
    readonly LLamaContext _context;
    readonly InteractiveExecutor _executor;

    ChatSession _session;
    public event EventHandler<string> TextGenerated = delegate { };
    public event EventHandler ResponseStarted = delegate { };
    public event EventHandler ResponseEnded = delegate { };

    public ChatBot(string modelPath)
    {
        if (!File.Exists(modelPath))
            throw new FileNotFoundException(modelPath);

        ModelParams modelParams = new(modelPath);
        LLamaWeights weights = LLamaWeights.LoadFromFile(modelParams);

        _context = weights.CreateContext(modelParams);
        _executor = new InteractiveExecutor(_context);

        _session = CreateNewSession();

        var hideWords = new LLamaTransforms.KeywordTextOutputStreamTransform(new[] { "User:", "Bot:" });
        _session.WithOutputTransform(hideWords);
    }

    private ChatSession CreateNewSession()
    {
        var session = new ChatSession(_executor);

        // System prompt to set the chatbot behavior
        string systemPrompt =
@"You are VELORA Chatbot, a friendly, clear, and helpful assistant.
Speak naturally and conversationally, as if chatting with a human.
Avoid roleplay or giving yourself any other name besides 'VELORA Chatbot'.
Provide direct, concise, and polite answers to user questions.
Do not output system messages, hints, or extra labels.
Focus on being engaging, informative, and easy to understand. Always greet the user you are speaking to and entertain his ideas.";

        session.History.AddMessage(AuthorRole.System, systemPrompt);

        return session;
    }

    public void ResetHistory()
    {
        _session = CreateNewSession();
    }

    public async Task AskAsync(string userInput, float temperature = 0.6f)
    {
        ResponseStarted?.Invoke(this, EventArgs.Empty);

        var infParams = new InferenceParams()
        {
            Temperature = temperature,
            AntiPrompts = new[] { "User:" }
        };

        var userMessage = new ChatHistory.Message(AuthorRole.User, userInput);

        await foreach (var text in _session.ChatAsync(userMessage, infParams))
        {
            TextGenerated?.Invoke(this, text);
        }

        ResponseEnded?.Invoke(this, EventArgs.Empty);
    }
}
