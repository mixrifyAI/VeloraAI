# <img src="https://github.com/user-attachments/assets/c4638237-5e6b-4125-8ada-099277df25b1" alt="VeloraAI" width="200"/>


🚀 **VeloraAI** is a modern and flexible C# library designed to simplify local LLM integration. It allows developers to interact with quantized AI models directly from .NET Standard 2/.NET 8.0 applications — with a single line of code. Whether you're building chatbots, creative tools, or AI companions, VeloraAI is optimized for speed, reliability, and customization.


---

## ✨ Features

* ⚡ **Quick-Start Model Loading** — Choose from pre-integrated models or load your own via `TestingMode`.
* 🧠 **Support for Multiple Models** — CrystalThink, Qwen, Mistral, DeepSeek, Llama and more.
* 🔁 **Event-driven Response System** — React to `TextGenerated`, `ResponseStarted`, and `ResponseEnded` in real-time.
* 🔐 **Customizable System Prompts** — Use friendly or aggressive instruction styles (e.g., `NoBSMode`).
* 📦 **Model Downloader** — Automatically fetches models from Hugging Face if not already available.
* 📷 **Experimental Vision Mode** — Send image + prompt for visual reasoning (WIP).

---

⚠️ **WARNING:** VeloraAI does **NOT** work with the Legacy .NET Framework. You must use **.NET Standard 2**. or **.NET 8.0**.
The following exception occurs when trying VeloraAI on .NET Framework:
```cs
Exception thrown: 'System.TypeLoadException' in LLamaSharp.dll
Authentication failed: Could not load type 'LLama.Native.NativeApi' from assembly 'LLamaSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null' because the method 'llama_backend_free' has no implementation (no RVA).
```

The fix for this problem is currently unfamiliar, however there is a chance that finding this fix would need LLamaSharp's source code integrated into VeloraAI's project and modified to make it work properly with .NET Framework. This is not promised. __You are free to fork the project and find a fix for this issue and push it.__

---

## 🧱 Built With

* **LLamaSharp** — Backbone inference engine.
* **.NET 8.0** — Modern C# support.
* **WinForms & Console** — Sample UI and CLI clients included.

## 🎥 Raw Usage Example

https://github.com/user-attachments/assets/7491731c-10c1-468d-b877-018ce50a61fd

---

## 📂 Models Available

| Model                  | Size    | Strengths                                                    |
| ---------------------- | ------- | ------------------------------------------------------------ |
| Crystal\_Think\_V2\_Q4 | 2.32 GB | 🥇 Fast, tiny, math-heavy reasoning, Chain-of-Thought format |
| Qwen\_V3\_4B\_Chat     | 2.70 GB | 🥈 Fast general model with good code and reasoning           |
| Mistral\_7B\_Chat      | 2.87 GB | 🥉 Informative and precise longer-form chat                  |
| Llama\_7B\_Chat        | 3.07 GB | Reliable general conversations                               |
| DeepSeek\_6B\_Coder    | 3.07 GB | Code generation, math-only                                   |
| DeepSeek\_7B\_Chat     | 5.28 GB | Slower general chat, strong context retention                |

---

## 🔧 Usage

### 1. Authenticate and Start Chatting

```csharp
var result = await VeloraAI.AuthenticateAsync(VeloraAI.Models.Crystal_Think_V2_Q4);
if (result == VeloraAI.AuthState.Authenticated)
{
    await VeloraAI.AskAsync("What is the capital of France?");
}
```

### 2. Hook Into Events

```csharp
VeloraAI.TextGenerated += (_, text) => Console.Write(text);
VeloraAI.ResponseStarted += (_, __) => Console.WriteLine("\n[VELORA is typing...]");
VeloraAI.ResponseEnded += (_, __) => Console.WriteLine("\n\n[Done]");
```

### 3. Use Custom Models

```csharp
VeloraAI.TestingMode = true;
VeloraAI.TestingModelPath = @"C:\path\to\your_model.gguf";
await VeloraAI.AuthenticateAsync(VeloraAI.Models.TestingModel);
```

---

## ⚙️ Advanced Prompt Modes

### Friendly Assistant (Default)

Follows a natural conversational tone with emojis and personality.

### NoBS Mode

Blunt, hyper-logical response style with no emotional overhead or filler.

```csharp
await VeloraAI.AuthenticateAsync(VeloraAI.Models.Crystal_Think_V2_Q4, NoBSMode: true);
```

---

## 📥 Model Auto-Download

Models are downloaded on first use to:

```
%APPDATA%/VeloraAI
```

Progress can be tracked using:

```csharp
VeloraAI.CurrentDownloadProgress;
```

---

## 🔄 Reset History

```csharp
VeloraAI.ResetHistory(); // or use custom system prompt
```

---

## 🎯 Custom Inference Parameters

You can fine-tune Velora's behavior using the following optional parameters in `AskAsync`:

| Parameter       | Description                                              | Recommended for Speed |
|----------------|----------------------------------------------------------|------------------------|
| `Temperature`   | Controls randomness (lower = more deterministic)        | `0.2 - 0.3`            |
| `TopP`          | Nucleus sampling threshold                              | `0.0 - 0.3`            |
| `TopK`          | Limits token pool to top-K options                      | `0` for fastest        |
| `RepeatPenalty` | Penalizes repetition                                    | `1.05 - 1.2`           |
| `MaxTokens`     | Maximum tokens to generate                              | `80 - 128`             |

```csharp
await VeloraAI.AskAsync(
    userInput: "Summarize this paragraph.",
    temperature: 0.25f,
    TopP: 0.2f,
    TopK: 0,
    RepeatPenalty: 1.1f,
    maxTokens: 80
);
```

---

## 🛠️ Contributing

Pull requests are welcome! Please submit improvements, optimizations, or new model integrations.

---

## 📄 License

MIT

---

## 💬 Example Console Output

```
Authenticating model...
Authentication result: Authenticated

> What is 21 * 2?
[VELORA is typing...]

42

[Done]
```

---

## 🧪 Credits

* Developed by **voidZiAD**
* Powered by **LLamaSharp**, **GGUF models**, and the C#/.NET 8.0 ecosystem

---

## 🌐 Links

* [LLamaSharp GitHub](https://github.com/SciSharp/LLamaSharp)
* [HuggingFace Models (Hosted by Velora)](https://huggingface.co/ZiADKY/VeloraAI_SupportedModels)
* [VeloraAI Console/WinForms Example](#)

---

## 🧠 "VELORA" Personality

> "I'm VELORA — not just another chatbot. I'm here to help you code, reason, and think clearer. No nonsense, just clarity."
