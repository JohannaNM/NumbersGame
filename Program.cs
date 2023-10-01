using System;

namespace NumbersGame  //Johanna Marklund .NET23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlayGame();
            

        }

        public static bool ResetGame() // Resets the game if user press J
        { 
            Console.WriteLine("Vill du spela igen? tryck på J för JA. ");
            if (Console.ReadKey().Key == ConsoleKey.J)
            {
                Console.WriteLine("");
                PlayGame();
                return true;
            }
            
            else return false;

        }

        public static int GetGuess()  // Validates user input
        {
            int guess = 0;
            try
            {
                guess = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Ogiltig gissning. Försök igen.");
                guess = GetGuess();
            }

            if (guess > 20 || guess < 1)
            {
                Console.WriteLine("Talet måste vara mellan 1 och 20. Försök igen.");
                guess = GetGuess();
            }
           
            return guess;
        }


        public static void PlayGame() // Evaluates answer against "randomNumber" to determine win or loss and keeps track of tries. 
        {
            Console.WriteLine("Välkommen! Jag tänker på ett tal mellan 1 och 20. Kan du gissa vilket? Du får fem försök.");

            Random random = new Random();
            int randomNumber = random.Next(1, 21); // Generates a random number between 1 and 21. 

            int maxAllowedTries = 5;
            int numberOfTries = 0;

            while (numberOfTries < maxAllowedTries)
            {
                int guess = GetGuess();
                numberOfTries++;


                if (guess == randomNumber)
                {
                    Console.WriteLine("Wohoo! Du klarade det!");
                    Console.WriteLine("**********************************************************************************************");
                    break;
                }
                else if (numberOfTries == maxAllowedTries)
                {
                    Console.WriteLine($"Tyvärr, du lyckades inte gissa talet på fem försök. Talet var {randomNumber}!");
                    Console.WriteLine("**********************************************************************************************");
                    break;
                }
                else if (guess < randomNumber)
                {
                    if (guess >= (randomNumber - 2) && guess < randomNumber)
                    {
                        Console.WriteLine("Nära men tyvärr lite för lågt!");
                        Console.WriteLine($"Du har {maxAllowedTries - numberOfTries} försök kvar. Gissa igen:");
                    }
                    else
                    {
                        Console.WriteLine("Tyvärr, du gissade för lågt!");
                        Console.WriteLine($"Du har {maxAllowedTries - numberOfTries} försök kvar. Gissa igen:");
                    }

                }
                else if (guess > randomNumber)
                {
                    if (guess <= (randomNumber + 2) && guess > randomNumber)
                    {
                        Console.WriteLine("Nära men tyvärr lite för högt!");
                        Console.WriteLine($"Du har {maxAllowedTries - numberOfTries} försök kvar. Gissa igen:");
                    }
                    else
                    {
                        Console.WriteLine("Tyvärr, du gissade för högt!");
                        Console.WriteLine($"Du har {maxAllowedTries - numberOfTries} försök kvar. Gissa igen:");
                    }

                }

            }

            ResetGame();
        }

    }
}