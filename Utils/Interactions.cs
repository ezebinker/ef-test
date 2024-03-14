
namespace Utils;
class Interactions
{
    public static char CharInput(string prompt = "")
    {
        string? input;
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine();
            if (input == null || input.Length == 0)
            {
                Console.WriteLine("Invalid input. Please try again.");
                Console.ReadLine();
                if(prompt.Length > 0)
                {
                    Console.Clear();
                }
            }
        } while (input == null || input.Length == 0);
        return input.ToUpper()[0];
    }
    
    public static string? StringInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }

    public static int IntInput(string prompt = "")
    {
        string? input;
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine();
            if (input == null || input.Length == 0 || !int.TryParse(input, out _))
            {
                Console.WriteLine("Invalid input. Please try again.");
                Console.ReadLine();
                if(prompt.Length > 0)
                {
                    Console.Clear();
                }
            }
        } while (input == null || input.Length == 0 || !int.TryParse(input, out _));
        return int.Parse(input);
    }
}