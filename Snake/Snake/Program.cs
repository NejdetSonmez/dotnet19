using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{

    class Program
    {
        static void Main(string[] args)
        {

            int xPosition = 40;
            int yPosition = 11;
            decimal gameSpeed = 150m;
            int foodX = 10;
            int foodY = 10;
            int foodEaten = 0;
            bool isGame = true;
            bool isHit = false;
            bool isFoodEaten = false;

            Random rnd = new Random();


            buildDraw();
            setApplePosition(rnd, out foodX, out foodY);
            paintFood(foodX, foodY);

            ConsoleKey cmd = Console.ReadKey().Key;
            do
            {
                switch (cmd)
                {
                    case ConsoleKey.LeftArrow:
                        Console.SetCursorPosition(xPosition, yPosition);
                        Console.Write(" ");
                        xPosition--;
                        break;
                    case ConsoleKey.RightArrow:
                        Console.SetCursorPosition(xPosition, yPosition);
                        Console.Write(" ");
                        xPosition++;
                        break;
                    case ConsoleKey.UpArrow:
                        Console.SetCursorPosition(xPosition, yPosition);
                        Console.Write(" ");
                        yPosition--;
                        break;
                    case ConsoleKey.DownArrow:
                        Console.SetCursorPosition(xPosition, yPosition);
                        Console.Write(" ");
                        yPosition++;
                        break;
                }

                Console.SetCursorPosition(xPosition, yPosition);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine((char)2);

                isHit = SnakeHitWall(xPosition, yPosition);
                if (isHit)
                {
                    isGame = false;
                    Console.SetCursorPosition(35, 11);
                    Console.Write("GAME OVER!!!");
                }

                isFoodEaten = determineFoodIfEaten(xPosition, yPosition, foodX, foodY);
                if (isFoodEaten)
                {
                    setApplePosition(rnd, out foodX, out foodY);
                    paintFood(foodX, foodY);
                    foodEaten++;
                    gameSpeed *= .925m;
                }


                if (Console.KeyAvailable) cmd = Console.ReadKey().Key;
                System.Threading.Thread.Sleep(Convert.ToInt32(gameSpeed));
            }
            while (isGame);



            Console.ReadKey();
        }

        private static bool determineFoodIfEaten(int xPosition, int yPosition, int foodX, int foodY)
        {
            if (xPosition == foodX && yPosition == foodY) return true; return false;
        }

        private static void paintFood(int foodX, int foodY)
        {
            Console.SetCursorPosition(foodX, foodY);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write((char)179);
        }

        private static void setApplePosition(Random rnd, out int foodX, out int foodY)
        {
            foodX = rnd.Next(2, 78);
            foodY = rnd.Next(2, 22);
        }

        private static bool SnakeHitWall(int xPosition, int yPosition)
        {
            if (xPosition == 1 || xPosition == 78 || yPosition == 1 || yPosition == 22) return true; return false;
        }

        private static void buildDraw()
        {
            //    for (int i = 1; i < 24; i++)
            //    {
            //        Console.SetCursorPosition(1, i);
            //        Console.ForegroundColor = ConsoleColor.Yellow;
            //        Console.WriteLine("*");

            //        Console.SetCursorPosition(79, i);
            //        Console.ForegroundColor = ConsoleColor.Yellow;
            //        Console.WriteLine("*");
            //    }
            //    for (int i = 1; i < 80; i++)
            //    {
            //        Console.SetCursorPosition(i, 1);
            //        Console.ForegroundColor = ConsoleColor.Yellow;
            //        Console.WriteLine("*");
            //        Console.SetCursorPosition(i, 23);
            //        Console.ForegroundColor = ConsoleColor.Yellow;
            //        Console.WriteLine("*");
            //    }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            for (int x = 1; x < 80; x++)
            {
                for (int y = 1; y < 24; y++)
                {
                    if (y == 1 || y == 23 || x == 1 || x == 79)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write((char)178);
                    }
                }
            }
        }
    }

}
