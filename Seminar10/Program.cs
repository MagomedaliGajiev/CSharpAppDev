using System.Text;

namespace Seminar10
{
    public class Program
    {
        static void Main(string[] args)
        {
            // C:\Users\Mago\Desktop\GB\Разработка приложения на С#\Семинар8
            var path = @"C:\Users\Mago\Desktop\GB\Разработка приложения на С#";
            var fileName = "findme.txt";

            //if (File.Exists(path))  
            //{
            //    using (var sr = new StreamReader(path))
            //    {
            //        var str = string.Empty;
            //        while (!sr.EndOfStream)
            //        {
            //            str += sr.ReadLine() + "\n";
            //        }

            //        Console.WriteLine(str);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Такого файла нет!");
            //}

            var filePath = FindFile(path, fileName);
            if (File.Exists(filePath))
            {
                using (var sr = new StreamReader(filePath))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }

            string str = "SomeText in some file";

            using (var streamWriter  = new StreamWriter(@"C:\Users\Mago\Desktop\GB\Разработка приложения на С#\data.txt"))
            {
                streamWriter.WriteLine(str);
            }


        }
        static string FindFile(string directory, string fileName)
        {
            var names = Directory.GetFiles(directory);
            var notFound = "Файл не найден";

            foreach (var name in names)
            {
                if (Path.GetFileName(name) == fileName) // Сравниваем только имя файла, а не полный путь
                {
                    return name;
                }
            }
            foreach (var dir in Directory.GetDirectories(directory))
            {
                if (FindFile(dir, fileName) != notFound) // Рекурсивно вызываем FindFile и проверяем результат
                {
                    return FindFile(dir, fileName);
                }
            }
            return notFound;
        }
    }

    class FileTree
    {
        private enum Format { txt, jpg, jpeg, mp4, mp3, pdf, cs, cpp }
        private FolderNode root;

        private class FolderNode
        {
            private string name;
            List<FolderNode>[] folders;
            List<FileNode> files;
            byte[] data;
        }

        private class FileNode
        {
            private string name;
            private double size;
            private Format format;

            public string GetName
            {
                get { return name; }
            }

            public string GetFormat
            {
                get { return format; }
            }
        }

        private class List<T>
        {
            Node root;
            private class Node
            {
                Node next;
                T value;
            }
        }
    }
}
