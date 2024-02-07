using System;
using System.IO;

namespace FileSearchUtility
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Usage: utility.exe <extension> <text> <directory>");
                return;
            }

            string extension = args[0];
            string text = args[1];
            string directory = args[2];

            // Рекурсивно ищем файлы с указанным расширением
            var files = FindFiles(directory, extension);

            // Ищем указанный текст в найденных файлах
            foreach (var file in files)
            {
                if (FileContainsText(file, text))
                {
                    Console.WriteLine($"Файл {file} содержит текст '{text}'");
                }
            }
        }

        static string[] FindFiles(string directory, string extension)
        {
            var files = Directory.GetFiles(directory, $"*.{extension}");
            foreach (var dir in Directory.GetDirectories(directory))
            {
                files = files.Concat(FindFiles(dir, extension)).ToArray();
            }
            return files;
        }

        static bool FileContainsText(string file, string text)
        {
            using (var sr = new StreamReader(file))
            {
                return sr.ReadToEnd().Contains(text);
            }
        }
    }
}