using Ionic.Zip;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Start();
        }

        private static void Start()
        {
            Users users = new Users();

            while (true)
            {
                Console.WriteLine("Welcome!\nВы можете:\nВыйти - Escape\nВойти - Enter");
                var consoleKey = Console.ReadKey();

                switch (consoleKey.Key)
                {
                    case ConsoleKey.Escape:
                        return;
                    case ConsoleKey.Enter:
                        SignIn();
                        break;
                    default:
                        break;
                }
            }
        }

        private static void SignIn()
        {
            Console.Write("Enter LOGIN: ");
            string login = Console.ReadLine();
            if (Users.UsersList.ContainsKey(login))
            {
                Console.Write("Enter PASSWORD: ");
                string password = Console.ReadLine();
                if (Users.UsersList.ContainsValue(password))
                {
                    WorkWithDirectory(login, password);
                }
            }
            else
            {
                Registration();
            }
        }

        private static void Registration()
        {
            Console.Write("Registration: ");
            string login = Console.ReadLine();
            Console.Write("Write password: ");
            string password = Console.ReadLine();
            Users.UsersList.Add(login, password);
        }

        private static void WorkWithDirectory(string name, string password)
        {
            while (true)
            {
                string fullPath = name;

                DirectoryInfo directoryInfo = new DirectoryInfo(fullPath);

                if (!directoryInfo.Exists)
                {
                    if (File.Exists(fullPath + ".zip"))
                    {
                        OpenningFolder(fullPath + ".zip", fullPath, password);
                    }
                    else
                    {
                        directoryInfo.Create();
                        Console.WriteLine("It's your first time. We added the folder for you");
                    }
                }

                Console.WriteLine("Welcome!\nВы можете:\nВыйти - Escape\nЗаписать что-нибудь в файл - 1");

                var consoleKey = Console.ReadKey();

                switch (consoleKey.Key)
                {
                    case ConsoleKey.Escape:
                        HiddenFolder(fullPath, password);
                        DeleteFolder(fullPath);
                        return;
                    case ConsoleKey.D1:
                        WriteTextInFile(fullPath);
                        break;
                    default:
                        break;
                }
            }
        }

        private static void WriteTextInFile(string path)
        {
            Console.Write("Enter name of file: ");
            string name = path + @"\" + Console.ReadLine() + ".txt";

            using (StreamWriter writer = new StreamWriter(name))
            {
                Console.Write("What will write?\nText: ");
                string text = Console.ReadLine();
                writer.Write(text);
            }
        }

        private static void HiddenFolder(string path, string key)
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.Encryption = EncryptionAlgorithm.WinZipAes256;
                zip.Password = key;
                zip.AddFiles(Directory.GetFiles(path), path);
                zip.Save(path + ".zip");
            }
        }

        private static void OpenningFolder(string file, string path, string key)
        {
            
            using (ZipFile zip = ZipFile.Read(file))
            {
                zip.Password = key;
                zip.ExtractAll("");
            }
        }

        private static void DeleteFolder(string path)
        {
            Directory.Delete(path, true);
        }
    }
}
