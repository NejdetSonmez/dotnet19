using System;

namespace Powerball
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("POWERBALL");
            var powerball = new Powerball();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(powerball.generateNumbers());
                Console.ReadKey();
            }
        }
    }
    class Powerball
    {
        public string generateNumbers()
        {
            string numbers = "";
            Random rnd = new Random();
            for (int i = 0; i < 6; i++)
            {
                int num = rnd.Next(1, 56);
                numbers += num.ToString() + " ";
            }
            return numbers;
        }
       
    }
    
}
