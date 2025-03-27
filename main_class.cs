using System;
using System.Linq;

namespace POE_PROG_PART1
{
    public class main_class
    {
        // Variable declaration [Global]
        private string user_name = string.Empty;
        private string user_asking = string.Empty;

        // Cybersecurity Questions and Answers (Stored in a Dictionary-like structure)
        private readonly (string question, string answer, string[] keywords)[] cybersecurityData =
        {
            ("What is phishing?", "Phishing is a type of cyber attack where attackers impersonate legitimate organizations to steal sensitive information.", new[] { "phishing" }),
            ("What is two-factor authentication?", "Two-factor authentication (2FA) adds an extra layer of security by requiring a second form of verification in addition to your password.", new[] { "two-factor", "2fa", "authentication" }),
            ("What is malware?", "Malware refers to malicious software designed to damage, exploit, or gain unauthorized access to computer systems.", new[] { "malware", "virus", "trojan", "spyware" }),
            ("How can you protect your password?", "You can protect your password by using complex, unique passwords, and enabling two-factor authentication wherever possible.", new[] { "password", "secure password", "protect password" }),
            ("What is ransomware?", "Ransomware is a type of malware that locks or encrypts files, demanding payment in exchange for the decryption key.", new[] { "ransomware", "encrypt", "cyber extortion" }),
            ("What is a firewall?", "A firewall is a network security system that monitors and controls incoming and outgoing network traffic based on predetermined security rules.", new[] { "firewall", "network security" }),
            ("What is encryption?", "Encryption is the process of converting data into a code to prevent unauthorized access during transmission or storage.", new[] { "encryption", "encrypt", "secure data" }),
            ("What are strong passwords?", "Strong passwords are at least 12 characters long, with uppercase, lowercase, numbers, and symbols.", new[] { "strong password", "secure password" }),
            ("What is social engineering?", "Social engineering manipulates people into revealing confidential information by exploiting human psychology.", new[] { "social engineering", "manipulation", "psychology attack" }),
            ("What should you do if you receive a suspicious email?", "Do not click on any links or download attachments from unknown sources. Report it to your organization's IT department.", new[] { "suspicious email", "email scam", "phishing email" })
        };

        // Constructor
        public main_class()
        {
            // Play the greeting audio before anything else (audio is not implemented in this code)
            new voice_greeting();

            // Display the logo (image is not displayed here, it's part of another class)
            new image_display();

            // Display chatbot header with a border for a more visual appearance
            PrintBorder();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("  AI CHATBOT  ");
            PrintBorder();

            // Prompt user for their name with a visual prompt
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("ChatBot: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Please enter your name.");

            // Capture user's name with a visual prompt
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("You: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            user_name = Console.ReadLine();

            // Greet the user after capturing their name with a visual prompt
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("ChatBot: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Hello {user_name}, how can I assist you today?");

            // Start chatbot loop for continuous interaction with a visual element
            do
            {
                // Prompt user for their question with a visual prompt
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(user_name + ": ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                user_asking = Console.ReadLine();

                // Check if the user asked to exit the chatbot
                if (user_asking.ToLower() == "exit")
                {
                    // Output the exit message
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("ChatBot: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("THANK YOU FOR USING AI CHATBOT, SEE YOU NEXT TIME!");

                    // Exit the program immediately without showing the picture again
                    Environment.Exit(0);
                }

                // Process the question and give an answer if it's not exit
                answer(user_asking);

            } while (true); // Infinite loop until user exits
        }

        // Method to print a border around messages for better UI
        private void PrintBorder()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(new string('-', 20));
        }

        // Answering method to handle user queries
        private void answer(string asked)
        {
            asked = asked.ToLower(); // Convert user input to lowercase for case insensitivity
            bool foundAnswer = false; // Flag to check if an answer was found

            // Loop through predefined cybersecurity questions and answers
            foreach (var (question, answer, keywords) in cybersecurityData)
            {
                // Check if any keyword or full question is in the user's input (case insensitive)
                if (keywords.Any(keyword => asked.Contains(keyword)) || asked.Contains(question.ToLower()))
                {
                    // Add a decorative line before the answer for separation
                    PrintBorder();

                    // Output the answer to the user's question
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("ChatBot: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(answer); // Display the correct answer

                    // Follow-up message after providing the answer
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("ChatBot: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("We hope this response was helpful.");

                    // Add a decorative line after the answer for separation
                    PrintBorder();

                    foundAnswer = true; // Mark that an answer was found
                    break; // Exit loop once an answer is found
                }
            }

            // If no relevant question is found
            if (!foundAnswer)
            {
                // Add a decorative line before the response
                PrintBorder();

                // Inform user that their question is off-topic
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ChatBot: SORRY BUT THE INFORMATION YOU ARE LOOKING FOR IS NOT RELATED TO THE TOPIC OF THIS CHATBOT! TRY AGAIN PLEASE.");

                // Encourage the user to ask another question
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("ChatBot: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Please ask another question related to cybersecurity.");

                // Add a decorative line after the response for separation
                PrintBorder();
            }
        }
    }
}