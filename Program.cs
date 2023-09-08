using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_1300
{
    internal class Highscore
    {
        private int highscore;
        public Highscore()
        {
            highscore = int.MaxValue;
        }
        public void newHighscore(int attempts)
        {
            if (attempts < highscore)
            {
                highscore = attempts;
            }
        }
    }
}

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
            Highscore Highscore = new Highscore();

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

                        Highscore.newHighscore(attempts);
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
