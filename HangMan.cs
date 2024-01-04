using System.Text.RegularExpressions;

namespace hangman;

public class HangMan
{
    public static void Start()
    {

        //Lista med orden som ska användas för spelet
        string[] words =
        {
            "katten",
            "giraffen",
            "hunden",
            "tassarna",
            "tussen",
        };

        // Väljer ut ett random ord från arrayen
        string chosenWord = words[new Random().Next(0, words.Length - 1)];

        // Regex med  giltiga tecke (en bokstav mellan a-z).
        Regex validCharacters = new Regex("^[a-z]$");
        // Antal liv
        int lives = 5;

        // Tom array med bokstäverna som spelaren skrivit
        // vad skriver vi istället för var?
        var letters = new List<string>();

        // Så länge det finns liv kvar fortsätter loopen
        while (lives != 0)
        {
            // Antal karaktärer kvar att gissa.
            int charactersLeft = 0;

            // Loopar igenom alla karaktärer i ett ord
            foreach (var character in chosenWord)
            {
                // Gör om till string.
                string letter = character.ToString();

                // Om bokstaven i loopen finns i vår array av använda bokstäer, skriver vi
                // bokstaven, annars visar vi ett understräck (som en bokstav kvar att gissa på)
                if (letters.Contains(letter))
                {
                    Console.Write(letter);
                }
                else
                {
                    Console.Write("_");

                    // Vi ökar också räkningen av bokstäver som är kvar, som används för
                    // att spåra om spelet är över eller inte. 
                    charactersLeft++;
                }
            }
            Console.WriteLine(string.Empty);

            // Om inga bokstäver finns kvar avslutas spelet och loopen bryts
            if (charactersLeft == 0)
            {
                break;
            }

            Console.Write("Type in a letter: ");

            // läser input och jämför med tidigare angivna bokstäver samt gör om dem till små bokstäver 
            string key = Console.ReadKey().Key.ToString().ToLower();
            Console.WriteLine(string.Empty);

            // med regex ovan avgörs om tecknet är giltigt el
            if (!validCharacters.IsMatch(key))
            {
                // Om tecknet är ogiltigt, loopar vi bakåt till början genom att använda
                // "continue" statement och låter användaren veta att tecknet är ogiltigt.
                Console.WriteLine($"The letter {key} is invalid. Try again.");
                continue;
            }

            // Ser efter om bokstaven redan i vår array med använda bokstäver
            if (letters.Contains(key))
            {
                // visar meddelande om bokstaven redan skrivits
                Console.WriteLine("You already entered this letter!");
                continue;
            }

            // Om tecknet inte redan har använts, lägger vi till det till vår array av bokstäver. 
            letters.Add(key);

            // om ordet inte innehåller det angivna tecknet minskas antal liv med 1
            if (!chosenWord.Contains(key))
            {
                lives--;
                //+ Om det finns liv kvar visas nedan
                if (lives > 0)
                {
                    // Om det är endast 1 liv kvar visas Try annars Tries.
                    Console.WriteLine($"The letter {key} is not in the word. You have {lives} {(lives == 1 ? "try" : "tries")} left.");
                }
            }
        }

        // Om vinnaren har liv kvar visas You Won, annars You lost.
        if (lives > 0)
        {
            // Om det är endast 1 liv kvar visas life annars lives
            Console.WriteLine($"You won with {lives} {(lives == 1 ? "life" : "lives")} left!");
        }
        else
        {
            Console.WriteLine($"You lost! The word was {chosenWord}.");
        }
    }
}