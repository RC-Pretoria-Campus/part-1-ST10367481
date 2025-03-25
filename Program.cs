
using System;
using System.Speech.Synthesis;
using System.Threading.Tasks;

class Program
{
    static SpeechSynthesizer synthesizer = new SpeechSynthesizer();

    static void Main(string[] args)
    {
       
        DisplayAsciiArt();

        PlayVoiceGreeting();

        StartConversation().Wait();

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static void PlayVoiceGreeting()
    {
        synthesizer.Rate = 0;
        synthesizer.Volume = 100;

        string greetingMessage = "Hello! Welcome to the Cybersecurity Awareness Bot. I’m that friend that always has your best interest at heart.";
        ColorWrite("Rachel the chatBot: ", ConsoleColor.Magenta);
        Console.WriteLine(greetingMessage);
        synthesizer.Speak(greetingMessage);
    }

    static async Task StartConversation()
    {
        string firstName = "";
        while (string.IsNullOrWhiteSpace(firstName))
        {
            ColorWrite("\nRachel the chatBot: ", ConsoleColor.Magenta);
            Console.Write("What is your first name? ");
            firstName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(firstName))
            {
                ColorWrite("Rachel the chatBot: ", ConsoleColor.Red);
                Console.WriteLine("Oops! Please enter a valid name.");
                synthesizer.Speak("Oops! Please enter a valid name.");
            }
        }

        synthesizer.Speak($"Nice to meet you, {firstName}!");

        ColorWrite("\nRachel the chatBot: ", ConsoleColor.Magenta);
        Console.WriteLine($"Nice to meet you, {firstName}!");

       
        AskGeneralQuestions(firstName);
    }

    static void AskGeneralQuestions(string firstName)
    {
        bool askedHowAreYou = false;
        string[] questions =
        {
            "How are you today?",
            "Have you ever experienced a cybersecurity threat?",
            "Would you like to learn more about password safety, phishing, or safe browsing?"
        };

        foreach (string question in questions)
        {
            if (question == "How are you today?")
            {
                askedHowAreYou = true;
            }

            ColorWrite("\nRachel the chatBot: ", ConsoleColor.Magenta);
            Console.WriteLine(question);
            ColorWrite($"{firstName}: ", ConsoleColor.Cyan);
            string response = Console.ReadLine();
            HandleUserResponse(response);

            if (askedHowAreYou)
            {
                ColorWrite("\nRachel the chatBot: ", ConsoleColor.Magenta);
                Console.WriteLine("I'm good, thanks for asking!");
                askedHowAreYou = false;
            }
        }
    }

    static void HandleUserResponse(string response)
    {
        response = response.ToLower();
        if (response.Contains("password"))
        {
            ColorWrite("\nRachel the chatBot: ", ConsoleColor.Magenta);
            string message = "Password safety is crucial! Always use a strong, unique password with a mix of letters, numbers, and symbols. Consider using a password manager.";
            Console.WriteLine(message);
            synthesizer.Speak(message);
        }
        else if (response.Contains("phishing"))
        {
            ColorWrite("\nRachel the chatBot: ", ConsoleColor.Magenta);
            string message = "Phishing attacks trick users into giving away sensitive information. Be cautious of unexpected emails asking for login credentials or financial details. Would you like an example?";
            Console.WriteLine(message);
            synthesizer.Speak(message);

            string followUp = Console.ReadLine().ToLower();
            if (followUp.Contains("yes") || followUp.Contains("example"))
            {
                string exampleMessage = "A common phishing example is receiving an email that appears to be from your bank, asking you to click a link and verify your account details. The link leads to a fake website designed to steal your information.";
                ColorWrite("\nRachel the chatBot: ", ConsoleColor.Magenta);
                Console.WriteLine(exampleMessage);
                synthesizer.Speak(exampleMessage);
            }
        }
        else if (response.Contains("safe browsing"))
        {
            ColorWrite("\nRachel the chatBot: ", ConsoleColor.Magenta);
            string message = "Safe browsing means avoiding suspicious websites, not clicking on unknown links, and using security features like HTTPS and browser extensions to protect your data.";
            Console.WriteLine(message);
            synthesizer.Speak(message);
        }
    }

    static void ColorWrite(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ResetColor();
    }

    static void DisplayAsciiArt()
    {
        ColorWrite(@"
 /_/\
( o.o )
 > ^ <
CYBERSECURITY FOR THE WIN!!!!!!!!!!!!!!
------------------------------------------------
", ConsoleColor.Blue);
    }
}


