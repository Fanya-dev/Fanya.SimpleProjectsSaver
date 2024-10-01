using Fanya.SimpleProjectsSaver.Modules;
using System;
using System.Text;

namespace Fanya.SimpleProjectsSaver;

public class Program
{
    public static List<string> CopyFolder = new();
    public static List<string> CopyFiles = new();
    public static void Main()
    {
        Console.InputEncoding = UTF8Encoding.UTF8;
        Console.OutputEncoding = UTF8Encoding.UTF8;
        Console.WriteLine("Создание бэкапа проектов");
        Console.WriteLine("Если программа увидит в папке папку .git сохранит только эту папку и папку .git");
        Console.WriteLine("Иначе полностью скопирует папку и данные в ней.");
        Console.WriteLine("Меню:");
        Console.WriteLine("0. Закрыть программу");
        Console.WriteLine("1. Сделать бэкап из текущей папки");
        Console.Write("Выберите пункт в меню: ");
        string? MenuNumber = Console.ReadLine();

        switch(MenuNumber)
        {
            case "1":
                Backup.Start();
                Console.WriteLine("Готово, нажмите любую клавишу чтобы закрыть программу.");
                Console.Read();
                break;
                default:
                break;
        }
    }
}