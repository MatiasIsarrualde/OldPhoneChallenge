using System;
using System.Collections.Generic;

static class Program
{
    static void Main()
    {
        string input = "8 88777444666*664#";  // Example
        OldPhonePad(input);
    }

    static void OldPhonePad(string input)
    {
        // Validation: The last character should be '#'
        if (input[input.Length - 1] != '#')
        {
            Console.WriteLine("Error: The string must end with '#'.");
            return;
        }

        // Validation: The only acceptable characters are numbers, spaces or asterisks.
        for (int i = 0; i < input.Length - 1; i++)  // Ignore the last character because it must be '#'
        {
            if (!(char.IsDigit(input[i]) || input[i] == ' ' || input[i] == '*'))
            {
                Console.WriteLine("Error: All characters must be numbers, spaces or asterisks.");
                return;
            }
        }

        // Map numbers to letters
        Dictionary<string, string[]> keypad = new Dictionary<string, string[]>
        {
            { "2", new string[] { "A", "B", "C" } },
            { "3", new string[] { "D", "E", "F" } },
            { "4", new string[] { "G", "H", "I" } },
            { "5", new string[] { "J", "K", "L" } },
            { "6", new string[] { "M", "N", "O" } },
            { "7", new string[] { "P", "Q", "R", "S" } },
            { "8", new string[] { "T", "U", "V" } },
            { "9", new string[] { "W", "X", "Y", "Z" } }
        };

        List<string> output = new List<string>();  // Accumulate the letters for the final output
        int index = 0;

        // Loop that analyzes the string
        while (index < input.Length - 1)  // Exclude the last character ('#')
        {
            char currentChar = input[index];

            // If it's a space we ignore it and move to the next character
            if (currentChar == ' ')
            {
                index++;
                continue;
            }
            // If it's a '*', delete the last item from "output" 
            if(currentChar == '*')
            {
                output.RemoveAt(output.Count - 1);
            }

            string currentNumber = currentChar.ToString();
            int count = 1;

            // Count how many times the number is repeated consecutively
            while (index + 1 < input.Length - 1 && input[index] == input[index + 1])
            {
                count++;
                index++;
            }

            // Get the corresponding letter from the dictionary
            if (keypad.ContainsKey(currentNumber))
            {
                string[] letters = keypad[currentNumber];
                int letterIndex = (count - 1) % letters.Length;  // Cycle through if more repetitions than necessary
                output.Add(letters[letterIndex]);
            }

            index++;
        }

        // Join the result and display it
        string result = String.Join("", output);
        Console.WriteLine($"Output: {result}");
    }
}
