
using System;
using System.Speech.Synthesis;

class Program
{
    static SpeechSynthesizer synthesizer = new SpeechSynthesizer();

    static void Main(string[] args)
    {
        // Display ASCII Art First
        DisplayAsciiArt();

        // Voice Greeting
        PlayVoiceGreeting();

        // Ask for user input
        StartConversation();

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static void PlayVoiceGreeting()
    {
        synthesizer.Rate = 0;
        synthesizer.Volume = 100;

        string greetingMessage = "Hello! Welcome to the Cybersecurity Awareness Bot. I’m that friend that always has your best interest at heart.";
        ColorWrite("Rachel the chatBot: ", ConsoleColor.Green);
        Console.WriteLine(greetingMessage);

        synthesizer.Speak(greetingMessage);
    }

    static void StartConversation()
    {
        string firstName = "";
        while (string.IsNullOrWhiteSpace(firstName))
        {
            ColorWrite("\nRachel the chatBot: ", ConsoleColor.Green);
            Console.Write("What is your first name? ");
            ColorWrite("", ConsoleColor.Cyan);
            firstName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(firstName))
            {
                ColorWrite("Rachel the chatBot: ", ConsoleColor.Red);
                Console.WriteLine("Oops! Please enter a valid name.");
                synthesizer.Speak("Oops! Please enter a valid name.");
            }
        }

        synthesizer.Speak($"Nice to meet you, {firstName}!");

        ColorWrite("\nRachel the chatBot: ", ConsoleColor.Green);
        Console.WriteLine($"Nice to meet you, {firstName}!");

        string level = "";
        while (string.IsNullOrWhiteSpace(level))
        {
            ColorWrite("\nRachel the chatBot: ", ConsoleColor.Green);
            Console.WriteLine("How familiar are you with Cybersecurity? (Beginner, Intermediate, Advanced)");
            ColorWrite("> ", ConsoleColor.Cyan);
            level = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(level))
            {
                ColorWrite("Rachel the chatBot: ", ConsoleColor.Red);
                Console.WriteLine("Please enter a valid response!");
                synthesizer.Speak("Please enter a valid response.");
            }
        }

        ColorWrite("\nRachel the chatBot: ", ConsoleColor.Green);
        Console.WriteLine("Great! I'll make sure to tailor the tips according to your level.");
        synthesizer.Speak("Great! I'll make sure to tailor the tips according to your level.");
    }

    static void ColorWrite(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ResetColor();
    }

    static void DisplayAsciiArt()
    {
        Console.Clear();

        ColorWrite(@"
   _______  __     __  ______   ______   ______   ______   __          __        __         
  / ____\ \/ /   / / / /  _  \ |  ____| |  ____| |  ____|  \ \        / /        \ \       
 | |     \  /   / /_/ /| |_)  || |__    | |__    | |__      \ \  /\  / /    __    \ \      
 | |      / /   |  _  | |  _ < |  __|   |  __|   |  __|      \ \/  \/ /    |__|    > >     
 | |____ / /    | | | | | |_) || |____  | |      | |____      \  /\  /            / /      
  \_____/_/     |_| |_| |____/ |______| |_|      |______|      \/  \/            /_/       
                                                                                          

        CYBERSECURITY FOR THE WIN!!!!!!!!!!!!!!
        ------------------------------------------------
", ConsoleColor.Blue);
    }
}
