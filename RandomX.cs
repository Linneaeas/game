namespace randomx;

using System;

public class RandomX
{
    public static void Start()
    {
        // Slumpa fram en sträng med 4 tecken
        string randomText = GenerateRandomText(4);
        Console.WriteLine(randomText);
    }

    public static string GenerateRandomText(int length)
    {
        // Tecken som används för slumpad text
        const string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        // slumpgenerator
        Random random = new Random();

        // array av slumpade tecken med längden 'length'
        char[] randomChars = new char[length];
        for (int i = 0; i < length; i++)
        {
            randomChars[i] = characters[random.Next(characters.Length)];
        }

        // gör om arrayen av slumpade tecken till en sträng
        string randomText = new string(randomChars);

        return randomText;
    }
}