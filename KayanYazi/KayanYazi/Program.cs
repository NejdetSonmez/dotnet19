using System;
using System.Threading;

namespace KayanYazi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Real Slider!");
            var slider = new RealSlider();
            slider.slideText("DotNet19");
        }
    }
    class RealSlider
    {
        public void slideText(string slideText)
        {
            Console.Clear();
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;
            int textLength = slideText.Length;
            Console.WriteLine("width:{0} height:{1}", width, height);
            Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.BackgroundColor = ConsoleColor.Blue;
            int curx = width - 1;
            int milliseconds = 100;
            while (true)
            {
                cleanLine();
                curx = curx == 0 ? width : curx - 1;
                Console.SetCursorPosition(curx, 0);
                int length = (width - curx) < textLength ? (width - curx) : textLength;
                Console.Write(slideText.Substring(0, length));
                Console.SetCursorPosition(0, 0);
                Console.Write(slideText.Substring(length, textLength - length));
               // Console.SetCursorPosition(80, 80);
                Thread.Sleep(milliseconds);
            }
        }
        private void cleanLine()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < 80; i++)
            {
                Console.Write(" ");
            }
        }
    }
}