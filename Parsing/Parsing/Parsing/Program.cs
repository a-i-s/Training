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
            // StreamReader streamReader = new StreamReader("C://Users//user//Desktop//GameDevAcademy//Введение в Unity//Parsing//Parsing//source.txt");
            
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
}