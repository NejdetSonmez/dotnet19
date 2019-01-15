using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string readText = Console.ReadLine();
            string[] words = readText.Split(' ');
            var isNumeric1 = int.TryParse(words[0], out int first);
            var isNumeric2 = int.TryParse(words[2], out int second);
            int c = 0;
            var isOperator = words[1] == "+" || words[1] == "-" || words[1] == "/" || words[1] == "*";

            if (!isNumeric1)
            {
                Console.WriteLine("1. Sayı Hatalı...!");
            }
            else if(!isNumeric2){
                Console.WriteLine("2. Sayı Hatalı...!");
            }
            else if(!isOperator)
            {
                Console.WriteLine("Operator Hatalı...!");
            }
            switch (words[1])
            {
                case "*":
                    c = first * second;
                    break;
                case "+":
                    c = first + second;
                    break;
                case "-":
                    c = first - second;
                    break;
                case "/":
                    c = first / second;
                    break;
                  
            }
            Console.WriteLine("{0} {1} {2} = {3}", first, words[1], second, c);



            Console.ReadKey();
            Console.ReadLine();

        }
    }
}
