using System;
using System.Collections.Generic;
using System.Text;

namespace kraskalalgoritm
{
    public class ConsoleUI
    {
        private readonly string[] filenames = new string[] { @"..\..\..\..\TestFiles\test.txt", @"..\..\..\..\TestFiles\test1.txt", @"..\..\..\..\TestFiles\test2.txt" };

        public void GraphFromFile()
        {
            foreach (string filename in filenames)
            {
                try
                {
                    string[] lines = System.IO.File.ReadAllLines(filename);

                    Graph graph = new Graph();
                    foreach (string line in lines)
                    {
                        string[] splitted = line.Split();
                        Edge edge = new Edge(splitted[0], splitted[1], Int32.Parse(splitted[2]));
                        graph.Add(edge);
                    }
                    Console.WriteLine("Ваш граф: ");
                    Console.WriteLine(graph.ToString());
                    Result(graph);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка при чтении файла {filename}: {ex.Message}");
                }
            }
        }

        public void GraphFromConsole()
        {
            Console.WriteLine("Введите количество ребер: ");
            int amount = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Хорошо. Теперь введите ребра: каждое с новой строки, формат: Vertex1 Vertex2 EdgeWeight");
            Console.WriteLine();
            Graph graph = new Graph();


            for(int i = 0; i < amount; i++)
{
                string line = Console.ReadLine();
                string[] splitted = line.Split();
                Edge edge;
                try
                {
                    edge = new Edge(splitted[0], splitted[1], int.Parse(splitted[2]));
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Некорректное значение для веса ребра: {ex.Message}");
                    i--;
                    continue;
                }
                graph.Add(edge);
            }
            Result(graph);
        }

        public void Result(Graph graph)
        {
            graph = graph.FindMinimumSpanningTree();
            Console.WriteLine();
            Console.WriteLine("Minimum backbone: ");
            Console.Write(graph.ToString());
            Console.WriteLine(graph.GetWeight());
            Console.WriteLine();
        }
    }
}