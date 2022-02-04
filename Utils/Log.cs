using System;

namespace Utils.Debug
{
    public static class Log
    {
        public const ConsoleColor DefaultColor = ConsoleColor.White;

        public static void Print(object message)
        {
            ResetColor();
            Console.WriteLine(message.ToString());
        }
        public static void Print(object message, ConsoleColor color)
        {
            SetColor(color);
            Print(message);
            ResetColor();
        }

        public static void SetColor(ConsoleColor color) =>
            Console.ForegroundColor = color;
        public static void ResetColor() =>
            Console.ForegroundColor = DefaultColor;

        public static void Info(object message) => Print(message, ConsoleColor.Cyan);
        public static void Warning(object message) => Print(message, ConsoleColor.Yellow);
        public static void Error(object message) => Print(message, ConsoleColor.Red);
    }
}