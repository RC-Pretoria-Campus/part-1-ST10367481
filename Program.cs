using System;
using System.Speech.Synthesis; // Namespace for speech synthesis
using System.Threading.Tasks; // Namespace for asynchronous programming

class Program
{
    static SpeechSynthesizer synthesizer = new SpeechSynthesizer(); // Initialize the speech synthesizer

    static async Task Main(string[] args) // Change Main to async
    {
        DisplayAsciiArt();
        PlayVoiceGreeting();
        await StartConversation(); // Await the StartConversation method
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    // Method to play a voice greeting
    static void PlayVoiceGreeting()
    {
        synthesizer.Rate = 0;
        synthesizer.Volume = 100;
        string greetingMessage = "Hello! Welcome to the Cybersecurity Awareness Bot, my name is Rachel. I'm here to help you stay safe online.";
        ColorWrite("Rachel the chatBot: ", ConsoleColor.Magenta);
        Console.WriteLine(greetingMessage);
        synthesizer.Speak(greetingMessage);
    }

    // The method to start a conversation with the user
    static async Task StartConversation()
    {
        string firstName = GetFirstName();
        AskUserHowTheyAre(firstName);
        await HandleUserQuestions(firstName);
    }

    // Method to get the user's first name
    static string GetFirstName()
    {
        while (true)
        {
            ColorWrite("\nRachel the chatBot: ", ConsoleColor.Magenta);
            Console.Write("What is your first name? ");
            string firstName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(firstName))
                return firstName;
            ColorWrite("Rachel the chatBot: ", ConsoleColor.Red);
            Console.WriteLine("Oops! Please enter a valid name.");
        }
    }

    // Method to ask how the user is doing
    static void AskUserHowTheyAre(string firstName)
    {
        ColorWrite("\nRachel the chatBot: ", ConsoleColor.Magenta);
        Console.WriteLine($"How are you today, {firstName}?");
        ColorWrite($"{firstName}: ", ConsoleColor.Cyan);
        Console.ReadLine();
        ColorWrite("\nRachel the chatBot: ", ConsoleColor.Magenta);
        Console.WriteLine("That's great to hear! I am also keeping well, thanks for asking!");
    }

    // The method to handle user questions
    static async Task HandleUserQuestions(string firstName)
    {
        while (true)
        {
            ColorWrite("\nRachel the chatBot: ", ConsoleColor.Magenta);
            Console.WriteLine("Do you have any questions about cybersecurity or would you like to exit? Type 'exit' to quit.");
            ColorWrite($"{firstName}: ", ConsoleColor.Cyan);
            string response = Console.ReadLine().ToLower();
            if (response == "exit")
            {
                ColorWrite("\nRachel the chatBot: ", ConsoleColor.Magenta);
                Console.WriteLine("It was nice chatting with you! Goodbye!");
                synthesizer.Speak("It was nice chatting with you! Goodbye!");
                break;
            }
            else
            {
                await HandleUserResponse(response, firstName);
            }
        }
    }

    // The method to handle user responses based on their input
    static async Task HandleUserResponse(string response, string firstName)
    {
        response = response.ToLower();
        if (response.Contains("protect") || response.Contains("personal information"))
        {
            ColorWrite("\nRachel the chatBot: ", ConsoleColor.Magenta);
            string message = "To protect your personal information, avoid sharing sensitive data on unsecured websites...";
            Console.WriteLine(message);
            await AskForFollowUp("protect", firstName);
        }
        else if (response.Contains("phishing"))
        {
            ColorWrite("\nRachel the chatBot: ", ConsoleColor.Magenta);
            string message = "Phishing attacks trick users into giving away sensitive information...";
            Console.WriteLine(message);
            await AskForFollowUp("phishing", firstName);
        }
        else if (response.Contains("password"))
        {
            ColorWrite("\nRachel the chatBot: ", ConsoleColor.Magenta);
            string message = "Strong passwords include a mix of letters, numbers, and symbols...";
            Console.WriteLine(message);
            await AskForFollowUp("password", firstName);
        }
        else if (response.Contains("wifi"))
        {
            ColorWrite("\nRachel the chatBot: ", ConsoleColor.Magenta);
            string message = "To secure your Wi-Fi, change the default password, use WPA3 encryption...";
            Console.WriteLine(message);
            await AskForFollowUp("Wi-Fi", firstName);
        }
        else if (response.Contains("two-factor"))
        {
            ColorWrite("\nRachel the chatBot: ", ConsoleColor.Magenta);
            string message = "Two-factor authentication adds an extra layer of security...";
            Console.WriteLine(message);
            await AskForFollowUp("two-factor authentication", firstName);
        }
        else if (response.Contains("safe browsing"))
        {
            ColorWrite("\nRachel the chatBot: ", ConsoleColor.Magenta);
            string message = "To browse safely, make sure to use reputable antivirus software...";
            Console.WriteLine(message);
            await AskForFollowUp("safe browsing", firstName);
        }
        else
        {
            ColorWrite("\nRachel the chatBot: ", ConsoleColor.Magenta);
            Console.WriteLine("I didn't quite understand that. Could you please rephrase your question?");
        }
    }

    // The method to ask follow-up questions based on the topic
    static async Task AskForFollowUp(string topic, string firstName)
    {
        ColorWrite("\nRachel the chatBot: ", ConsoleColor.Magenta);
        Console.WriteLine($"Do you have any follow-up questions about {topic}?");

        ColorWrite($"{firstName}: ", ConsoleColor.Cyan);
        string followUpResponse = Console.ReadLine().ToLower();

        if (followUpResponse.Contains("yes") || followUpResponse.Contains("sure"))
        {
            string followUp = GetFollowUpQuestion(topic);
            if (!string.IsNullOrEmpty(followUp))
            {
                ColorWrite("\nRachel the chatBot: ", ConsoleColor.Magenta);
                Console.WriteLine(followUp);
                ColorWrite($"{firstName}: ", ConsoleColor.Cyan);
                string followUpAnswer = Console.ReadLine().ToLower();
                AnswerFollowUp(topic, followUpAnswer, firstName);
            }
        }
    }

    // The method to get a follow-up question based on the topic
    static string GetFollowUpQuestion(string topic)
    {
        return topic switch
        {
            "protect" => "You can ask how to improve your privacy or about specific tools for protection. What would you like to know?",
            "phishing" => "Would you like to know how to identify phishing emails or examples of phishing attempts?",
            "password" => "Do you want tips on creating strong passwords or information about password managers?",
            "Wi-Fi" => "Would you like to know more about securing your network or tools to manage your Wi-Fi security?",
            "two-factor authentication" => "Would you like to learn how to set it up or its benefits?",
            "safe browsing" => "Would you like to know more about how to avoid malware or how to use a VPN for safe browsing?",
            _ => string.Empty
        };
    }

    // The method to provide answers to follow-up questions
    static void AnswerFollowUp(string topic, string followUpAnswer, string firstName)
    {
        ColorWrite("\nRachel the chatBot: ", ConsoleColor.Magenta);
        string answer = topic switch
        {
            "protect" => followUpAnswer.Contains("privacy") ?
                "To improve your privacy, consider using a VPN and regularly review your privacy settings on social media." :
                followUpAnswer.Contains("tools") ?
                "Tools like antivirus software and privacy-focused browsers can help protect your personal information." :
                string.Empty,

            "phishing" => followUpAnswer.Contains("identify") ?
                "Check for suspicious links, poor grammar, and sender addresses that look unusual. Always verify before clicking." :
                followUpAnswer.Contains("examples") ?
                "An example of phishing is receiving an email that looks like it's from your bank, asking you to verify your account." :
                string.Empty,

            "password" => followUpAnswer.Contains("strong") ?
                "To create a strong password, use at least 12 characters, including a mix of letters, numbers, and symbols." :
                followUpAnswer.Contains("manager") ?
                "A password manager securely stores your passwords and helps you create strong ones." :
                string.Empty,

            "Wi-Fi" => followUpAnswer.Contains("secure") ?
                "To secure your Wi-Fi, use a strong password and enable WPA3 encryption." :
                followUpAnswer.Contains("manage") ?
                "You can use apps to manage your Wi-Fi settings and monitor connected devices for unauthorized access." :
                string.Empty,

            "two-factor authentication" => followUpAnswer.Contains("setup") ?
                "To set up two-factor authentication, go to your account settings and follow the prompts to enable it." :
                followUpAnswer.Contains("benefits") ?
                "The benefits include added security and protection against unauthorized access to your accounts." :
                string.Empty,

            "safe browsing" => followUpAnswer.Contains("malware") ?
                "To avoid malware, keep your antivirus software up to date and avoid downloading attachments from unknown sources." :
                followUpAnswer.Contains("vpn") ?
                "A VPN can help protect your data by encrypting it and hiding your IP address." :
                string.Empty,

            _ => string.Empty
        };

        if (!string.IsNullOrEmpty(answer))
        {
            Console.WriteLine(answer);
        }
    }

    // The Method to write colored text to the console
    static void ColorWrite(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ResetColor();
    }

    // The Method to display ASCII art
    static void DisplayAsciiArt()
    {
        ColorWrite(@"
  _______      ____     __  _______       .-''-.  .-------.             ________     ,-----.    .-------.            ,---------. .---.  .---.     .-''-.          .--.      .--..-./`) ,---.   .--. 
   /   __  \     \   \   /  /\  ____  \   .'_ _   \ |  _ _   \           |        |  .'  .-,  '.  |  _ _   \           \          \|   |  |_ _|   .'_ _   \         |  |_     |  |\ .-.')|    \  |  | 
  | ,_/  \__)     \  _. /  ' | |    \ |  / ( ` )   '| ( ' )  |           |   .----' / ,-.|  \ _ \ | ( ' )  |            `--.  ,---'|   |  ( ' )  / ( ` )   '        | _( )_   |  |/ `-' \|  ,  \ |  | 
,-./  )            _( )_ .'  | |____/ / . (_ o _)  ||(_ o _) /           |  _|____ ;  \  '_ /  | :|(_ o _) /               |   \   |   '-(_{;}_). (_ o _)  |        |(_ o _)  |  | `-'`""`|  |\_ \|  | 
\  '_ '`)      ___(_ o _)'   |   _ _ '. |  (_,_)___|| (_,_).' __         |_( )_   ||  _`,/ \ _/  || (_,_).' __             :_ _:   |      (_,_) |  (_,_)___|        | (_,_) \ |  | .---. |  _( )_\  | 
 > (_)  )  __ |   |(_,_)'    |  ( ' )  \'  \   .---.|  |\ \  |  |        (_ o._)__|: (  '\_/ \   ;|  |\ \  |  |            (_I_)   | _ _--.   | '  \   .---.        |  |/    \|  | |   | | (_ o _)  | 
(  .  .-'_/  )|   `-'  /     |  (_,_)  /  \       / |  |  \    /         |   |       '. \_/``"".'  |  |  \    /             (_(=)_)  |( ' ) |   |  \  `-'    /         |    /  \    | |   | |  (_,_)\  | 
 `-'`-'     /  \      /      |  (_,_)  /  \       / |  |  \    /         |   |       '. \_/``"".'  |  |  \    /             (_I_)   '(_,_) '---'    `'-..-'          `---'    `---` '---' '--'    '--' 
   `._____.'    `-..-'       /_______.'    `'-..-'  ''-'   `'-'          '---'         '-----'    ''-'   `'-'              '---'   '(_,_) '---'    `'-..-'          `---'    `---` '---' '--'    '--' 
                                                                                                                                                                                                                                                                                
        ", ConsoleColor.Cyan);

       
    }
}



