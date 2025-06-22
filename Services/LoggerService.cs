using System;
using System.Collections.Generic;
using System.IO;

namespace TurismoApp.Services
{
    public static class LoggerService
    {
        public static List<string> LogMemory = new List<string>();

        public static void LogToConsole(string mensagem)
        {
            Console.WriteLine($"[Console] {mensagem}");
        }

        public static void LogToFile(string mensagem)
        {
            File.AppendAllText("logs.txt", $"[File] {mensagem}{Environment.NewLine}");
        }

        public static void LogToMemory(string mensagem)
        {
            LogMemory.Add($"[Memory] {mensagem}");
        }
    }
}
