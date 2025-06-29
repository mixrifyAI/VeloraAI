using LLama.Common;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace VeloraAI.ConsoleApp
{
    internal class Program
    {

        private static bool Authorized = false;
        private static CancellationTokenSource? _cts;

        static async Task Main(string[] args)
        {
            VeloraAI.TextGenerated += (_, text) => Console.Write(text);
            VeloraAI.ResponseStarted += (_, __) => Console.WriteLine("\n[VELORA is typing...]\n");
            VeloraAI.ResponseEnded += (_, __) => Console.WriteLine("\n\n[Done]\n");

            Console.WriteLine("Authenticating model...");
            var result = await VeloraAI.AuthenticateAsync(VeloraAI.Models.Crystal_Think_V2_Q4);
            Console.WriteLine($"Authentication result: {result}");

            if (result != VeloraAI.AuthState.Authenticated)
            {
                Console.WriteLine("Authentication failed. Exiting.");
                return;
            }

            Authorized = true;

            Console.WriteLine("Type your prompt and press Enter to send. Type 'exit' to quit.");

            while (true)
            {
                Console.Write("\n> ");
                string? prompt = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(prompt)) continue;
                if (prompt.Trim().ToLower() == "exit") break;

                if (Authorized && !VeloraAI.IsResponding())
                {
                    _cts = new CancellationTokenSource();

                    try
                    {
                        // You can adjust parameters or make them configurable
                        float temperature = 0.3f;
                        float topP = 0.8f;
                        int topK = 0;
                        int maxTokens = 128;

                        await VeloraAI.AskAsync(prompt, temperature, topP, topK, 1.1f, maxTokens);
                    }
                    catch (OperationCanceledException)
                    {
                        Console.WriteLine("\nRequest canceled.");
                    }
                    finally
                    {
                        _cts.Dispose();
                        _cts = null;
                    }
                }
                else if (VeloraAI.IsResponding())
                {
                    Console.WriteLine("Cancelling previous request...");
                    _cts?.Cancel();
                }
            }
        }
    }
}
