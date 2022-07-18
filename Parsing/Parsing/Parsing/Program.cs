using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Reflection;

namespace Parsing
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Получение пути к файлу https://ru.stackoverflow.com/a/743372
            // StreamReader streamReader = new StreamReader("C://Users//user//Desktop//GameDevAcademy//Введение в Unity//Parsing//Parsing//source.txt");
            // var appDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            StreamReader streamReader = new StreamReader("source.txt");//файл нужно положить в корень проекта bin\Debug\net6.0
            
            /*while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                Console.WriteLine(line);// выводим на экран считанный текстовый документ
            }*/

            // LevelSettings levelSettings = new LevelSettings(streamReader);// создали объект levelSettings
            LevelSettings res = Parse(streamReader);// конечный готовый результат парсинга
            
            Console.WriteLine(res);
            streamReader.Close();
        }

        public static LevelSettings Parse(StreamReader streamReader)
        {
            LevelSettings result = new LevelSettings();// создали объект

            var count = Convert.ToInt32(streamReader.ReadLine()); // кол-во фишек

            result._count = count;// записали количество фишек в наш созданный объект
            
            var nodeCount = Convert.ToInt32(streamReader.ReadLine());// количество точек
            
            result._nodeCount = nodeCount;// записали количество точек в наш созданный объект

            Graph board = new Graph(nodeCount);

            result.Board = board;// записали граф в наш созданный объект

            List<Vector2> coordinates = new List<Vector2>(); // временный список координат
            for (int i = 0; i < nodeCount; i++)
            {
                string[]? coordinatesArray = streamReader.ReadLine().Split(',');

                int x = Convert.ToInt32(coordinatesArray[0]);
                int y = Convert.ToInt32(coordinatesArray[1]);
                var coordinate = new Vector2(x, y);

                coordinates.Add(coordinate); //добавляем в список наших координат.
                // Таким образом мы распарсили наши координаты
            }


            for (int i = 0; i < nodeCount; i++)
            {
                var node = new Node(i+1);
                node.SetCoordinate(coordinates[i]);
                board.AddNode(node);// добавили ноды в граф
            }


            List<int> StartPositions = new List<int>();// стартовое расположение фишек
            string[] start = streamReader.ReadLine().Split(','); 
            for (int i = 0; i < start.Length; i++)
            {
                int feature = Convert.ToInt32(start[i]);
                StartPositions.Add(feature);
            }
            result.StartPositions = StartPositions;// записали стартовое расположение фишек в наш созданный объект

            List<int> FinalPositions = new List<int>();// конечное расположение фишек
                
            string[] final = streamReader.ReadLine().Split(',');
            
            for (int i = 0; i < final.Length; i++)
            {
                int feature = Convert.ToInt32(final[i]);
                FinalPositions.Add(feature);
            }

            result.FinalPositions = FinalPositions;// записали конечное расположение фишек в наш созданный объект
            
            var countEdges = Convert.ToInt32(streamReader.ReadLine()); // кол - во ребер

            result._countEdges = countEdges; // записали количество ребер в наш созданный объект
            
            for (int i = 0; i < countEdges; i++)
            {
                string[] edgesArray = streamReader.ReadLine().Split(',');

                int numberOne = Convert.ToInt32(edgesArray[0]);// номер первого узла
                int numberTwo = Convert.ToInt32(edgesArray[1]);// номер второго узла
                Node nodeNumberOne = board.GetNode(numberOne);// получили первый узел по его номеру
                Node nodeNumberTwo = board.GetNode(numberTwo);// получили второй узел по его номеру
                nodeNumberOne.AddNeighbour(nodeNumberTwo);// сделали связь первого узла со вторым
                nodeNumberTwo.AddNeighbour(nodeNumberOne);// сделали связь второго узла с первым
            }
            return result;
        }
    }

/* 1. Количество фишек
	 
	2. Количество точек
	3. Координаты точек
	 
	4. Расположение фишек стартовое
	5. Расположение фишек конечное
	 
	6. Сколько ребер между точками
	7. Ребра*/

    public class LevelSettings// настройки уровня
    {
        public List<int> StartPositions { get; set; }
        public List<int> FinalPositions { get; set; }
        public int _count { get; set; }
        public int _nodeCount { get; set; }
        public Graph Board { get; set; }
        public int _countEdges { get; set; }// количество ребер
        
        public override string ToString()// метод для форматированной печати объектов
        {
            string start = "";
            foreach (var startPosition in StartPositions)
            {
                start = start + startPosition + ", ";
            }

            string final = "";
            foreach (var finalPosition in FinalPositions)
            {
                final = final + finalPosition + ", ";
            }

            return $"LevelSettings[count - {_count}, nodeCount - {_nodeCount}, countEdges - {_countEdges}, startPositions - {start}, finalPositions - {final},\nboard - {Board}]";
        }
        
    } 
    
    public class Graph
    {
        private int _nodeCound; // количество узлов
        List<Node> Nodes = new List<Node>();
        
        public Graph(int nodeCound) 
        {
            _nodeCound = nodeCound;
        }

        public Node GetNode(int index)// получить узел по индексу 
        {
            for (int i = 0; i < Nodes.Count; i++)
            {
                if (Nodes[i].GetNumber() == index)
                {
                    return Nodes[i];
                }
            }
            return null;
        }

        public void AddNode(Node node)// метод добавления нод (узлов)
        {
            Nodes.Add(node);
        }
        
        public override string ToString()// метод для форматированной печати объектов
        {
            string result = "";
            foreach (var node in Nodes)
            {
                result = result + "\n- " + node.ToString();
            }
           return $"Graph[nodeCount - {_nodeCound},\nNodes:{result}]";
        }
    }

    public class Node
    {
        private int _number; // номер узла
        Vector2 Position; // содержит две координаты x и y
        List<Node> Neighbours = new List<Node>(); // список ссылок на другие ноды 

        public Node(int number)
        {
            _number = number;
        }
        
        public void SetCoordinate(Vector2 coordinate)// установить координаты
        {
            Position = coordinate;
        }

        public int GetNumber()// получить номер узла
        {
            return _number;
        }

        public void AddNeighbour(Node node)// метод связи двух узлов
        {
             Neighbours.Add(node);
        }

        public override string ToString()// метод для форматированной печати объектов
        {
            string neigbourghs = "";
            foreach (Node neighbour in Neighbours)
            {
                neigbourghs = neigbourghs + neighbour._number + ", ";
            }
            
            return $"Node[number - {_number}, position - {Position}, Neighbours - {neigbourghs}]";
        }
    }
}