using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuesser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetAppInfo();
            string userName = GetUserName();
            GreetUser(userName);

            Random random = new Random();

            int correctNumber = random.Next(1,11);
            bool correctAnswer = false;

            Console.WriteLine("Zgadnij wylosowaną liczbę z przedziału od 1 do 10.");

            while (correctAnswer == false)
            {
                string input = Console.ReadLine();

                int guess;

                bool isNumber = int.TryParse(input, out guess);
                if (!isNumber)
                {
                    PrintColorMessage(ConsoleColor.Yellow, "Proszę wprowadzić liczbę.");
                    continue;
                }

                if (guess < 1 || guess > 10)
                {
                    PrintColorMessage(ConsoleColor.Yellow, "Proszę wprowadzić liczbę od 1 do 10.");
                    continue;
                }

                if (guess < correctNumber)
                {
                    PrintColorMessage(ConsoleColor.Red, "Błędna odpowiedź. Wylosowana liczba jest większa.");
                }
                else if (guess > correctNumber)
                {
                    PrintColorMessage(ConsoleColor.Red, "Błędna odpowiedź. Wylosowana liczba jest mniejsza.");
                }
                else
                {
                    correctAnswer = true;
                    PrintColorMessage(ConsoleColor.Green, "Brawo! Prawidłowa odpowiedź!");
                }
            }

            Console.ReadLine();
        }

        static void GetAppInfo()
        {
            string appName = "Zgadywanie liczb";
            int appVersion = 1;
            string appAuthor = "Patryk Sładek";

            string info = $"[{appName}] Wersja: 0.0.{appVersion}, Autor: {appAuthor}";
            PrintColorMessage(ConsoleColor.Magenta, info);
        }
        static string GetUserName()
        {
            Console.WriteLine("Jak masz na imię?");
            string inputUserName = Console.ReadLine();
            return inputUserName;
        }
        static void GreetUser(string userName)
        {
            string greetings = $"Powodzenia {userName}, odgadnij liczbę...";
            PrintColorMessage(ConsoleColor.Blue, greetings);

        }
        static void PrintColorMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
