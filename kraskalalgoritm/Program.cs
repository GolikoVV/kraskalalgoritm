using System;

namespace kraskalalgoritm
{
    // класс для тестирования алгоритма Краскала
    class Program
    {
        static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            Console.WriteLine("Добро пожаловать. Здесь вы можете использовать алгоритм Краскала.");
            ConsoleUI ui = new ConsoleUI();
            ui.GraphFromFile();

            Console.WriteLine("Вы хотите ввести свой собственный график? Нажмите 1, если хотите. В противном случае нажмите 0.");
            if (Int32.Parse(Console.ReadLine()) == 1) new ConsoleUI().GraphFromConsole();

            // Держите окно консоли открытым в режиме отладки.
            Console.WriteLine("Нажмите любую клавишу для выхода.");
            System.Console.ReadKey();
        }
    }
}