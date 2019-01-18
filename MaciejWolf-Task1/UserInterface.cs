using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebApi
{
    class UserInterface
    {
        public string GetUserInput(string message, List<string> validOptions)
        {
            Console.WriteLine(message);

            string input;

            while (true)
            {
                input = Console.ReadLine();

                if (validOptions.Any(s => s.Equals(input, StringComparison.OrdinalIgnoreCase)))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }

            return input;
        }

        public void WriteLine(string v)
        {
            Console.WriteLine(v);
        }

        public int GetUserInput(string message, int begin, int end)
        {
            int userInput;

            while (true)
            {
                while (true)
                {
                    try
                    {
                        Console.Write(message);
                        userInput = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid format");
                        continue;
                    }

                    break;
                }


                if (userInput < begin || userInput > end)
                {
                    Console.WriteLine("Input out of range");
                }
                else
                {
                    break;
                }
            }

            return userInput;
        }
    }
}
