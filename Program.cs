using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Xml.Serialization;

namespace LA_1300
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            bool PlayGame = true;

            while (PlayGame)
            {
                Random random = new Random();
                int secretNumber = random.Next(1, 101);

                int maxAttempts = 0;
                int attempts = 0;
                int highscore = 1000;

                Console.WriteLine("Willkommen beim Zahlen erraten. Wählen sie 1 für fünf Versuche oder 2 für unbegrenzte Versuche:");
                int choice;
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Ungültige Eingabe. Geben sie eine Zahl ein");
                    continue;
                }

                if (choice == 1)  //Chat GPT
                {
                    maxAttempts = 5;
                }
                else if (choice == 2)
                {
                    maxAttempts = int.MaxValue;
                }
                


                int eingabe;
                bool correctGuess = false;
                
                do
                {
                    attempts++;
                    Console.WriteLine("Versuch " + attempts);
                    Console.WriteLine("Geben sie eine Zahl ein:");
                    eingabe = int.Parse(Console.ReadLine());



                    if (eingabe < secretNumber)
                    {
                        Console.WriteLine("Die gesuchte Zahl ist grösser.");
                    }
                    else if (eingabe > secretNumber)
                    {
                        Console.WriteLine("Die gesuchte Zahl ist kleiner.");
                    }
                    else
                    {
                        correctGuess = true;
                        Console.WriteLine("Glückwunsch! Sie haben die richtige Zahl gefunden. Sie haben " + attempts + " Versuche gebraucht");

                        if (attempts < highscore && maxAttempts !=5)
                        {
                            highscore = attempts;
                        }
                        else
                        {
                            Console.WriteLine();
                        }
                    }
  

                } while (!correctGuess && attempts < maxAttempts);  //Chat GPT
                

                if (!correctGuess && attempts >= maxAttempts)   //Chat GPT
                {
                    Console.WriteLine("Sie haben keine Versuche mehr übrig. Die richtige Zahl war: " + secretNumber);
                }

                if (maxAttempts != 5)  
                {
                    Console.WriteLine("Dein Highscore ist: " + highscore);
                }

                 
                Console.WriteLine("Möchtest du erneut spielen? (ja/nein)");
                string repeat = Convert.ToString(Console.ReadLine());

                if (repeat == "nein")
                {
                    PlayGame = false;
                }
            }

        }
    }
}