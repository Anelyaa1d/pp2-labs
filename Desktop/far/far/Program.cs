using System;
using System.IO;

namespace far
{
    class Program
    {
        static void ShowDirectoryInfo(DirectoryInfo directoryInfo, int cursor)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            FileSystemInfo[] fileSystemInfo = directoryInfo.GetFileSystemInfos();
            int index = -1;
            foreach (FileSystemInfo file in fileSystemInfo)
            {
                index++;
                if (file.GetType() == typeof(DirectoryInfo))
                    Console.ForegroundColor = ConsoleColor.Magenta;
                else
                    Console.ForegroundColor = ConsoleColor.Red;
                if (index == cursor)
                    Console.BackgroundColor = ConsoleColor.White;
                else
                    Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine(file.Name);
            }
        }
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"bin");
            int cursor = 0;
            bool t = true;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            foreach (FileSystemInfo file in dir.GetFileSystemInfos())
            {
                if (file.GetType() == typeof(DirectoryInfo))
                    Console.ForegroundColor = ConsoleColor.Magenta;
                else
                    Console.ForegroundColor = ConsoleColor.Red;
                if (t)
                    Console.BackgroundColor = ConsoleColor.White;
                else
                    Console.BackgroundColor = ConsoleColor.Blue;
                t = false;
                Console.WriteLine(file.Name);
            }
            while (true)
            {
                int n = dir.GetFileSystemInfos().Length;
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.UpArrow)
                    cursor--;
                if (keyInfo.Key == ConsoleKey.DownArrow)
                    cursor++;
                if (cursor == -1)
                    cursor = n - 1;
                if (cursor == n)
                    cursor = 0;
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (dir.GetFileSystemInfos()[cursor].GetType() == typeof(DirectoryInfo))
                    {
                        dir = new DirectoryInfo(dir.GetFileSystemInfos()[cursor].FullName);
                        n = dir.GetFileSystemInfos().Length;
                        cursor = 0;
                    }
                    else
                    {
                        StreamReader sr = new StreamReader(dir.GetFileSystemInfos()[cursor].FullName);
                        try
                        {
                            Console.Clear();
                            string s = sr.ReadToEnd();
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(s);
                            Console.ReadKey();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        finally
                        {
                            sr.Close();
                        }
                    }
                }

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    if (dir.Parent != null)
                    {
                        dir = dir.Parent;
                        n = dir.GetFileSystemInfos().Length;
                        cursor = 0;
                    }
                }
                ShowDirectoryInfo(dir, cursor);
            }
        }
    }
}
