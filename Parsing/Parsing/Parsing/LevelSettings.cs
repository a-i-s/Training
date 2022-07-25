using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace Parsing
{
    public class LevelSettings// настройки уровня
    {
        public List<int> StartPositions { get; set; }
        public List<int> FinalPositions { get; set; }
        
        public Graph Board { get; set; }
        
        public int CountChips { get; set; }// публичные свойства именуются с заглавной буквы
       
        
        public LevelSettings(StreamReader streamReader)
        {
            CountChips = ReadInteger(streamReader);// кол-во фишек
            Board = ReadGraph(streamReader);// наш граф
            StartPositions = ReadNumbers(streamReader);
            FinalPositions = ReadNumbers(streamReader);
            InitializeNeighbours(Board, streamReader);
        }

        private void InitializeNeighbours(Graph? board, StreamReader streamReader)// метод установления связей между нодами
        {
            var countEdges = ReadInteger(streamReader); // кол - во ребер (наши связи между нодами)
            for (int i = 0; i < countEdges; i++)
            {
                string[] edgesArray = streamReader.ReadLine().Split(',');

                // считываем индексы первой и второй ноды
                int firstNodeIndex = Convert.ToInt32(edgesArray[0]);// номер первого узла
                int secondNodeIndex = Convert.ToInt32(edgesArray[1]);// номер второго узла
                
                Node firstNode = board.GetNode(firstNodeIndex);// получили первый узел по его номеру
                Node secondNode = board.GetNode(secondNodeIndex);// получили второй узел по его номеру
                
                firstNode.AddNeighbour(secondNode);// сделали связь первого узла со вторым
                secondNode.AddNeighbour(firstNode);// сделали связь второго узла с первым
            }
        }

        private Graph? ReadGraph(StreamReader streamReader)// метод парсинга графа
        {
            var nodeCount = ReadInteger(streamReader);// количество точек
           
            Graph board = new Graph(nodeCount);// создали объект типа Graph

            List<Vector2> coordinates = new List<Vector2>(); // временный список координат
            for (int i = 0; i < nodeCount; i++)// проходимся циклом от 0 до количества вершин в нашем графе
            {
                string[]? coordinatesArray = streamReader.ReadLine().Split(',');// считываем строку и разбиваем
                // ее по запятым на массив из строк

                int x = Convert.ToInt32(coordinatesArray[0]);
                int y = Convert.ToInt32(coordinatesArray[1]);
                var coordinate = new Vector2(x, y);

                coordinates.Add(coordinate); //добавляем в список наших координат.
                // Таким образом мы распарсили наши координаты
            }


            for (int i = 0; i < nodeCount; i++)
            {
                var node = new Node(i+1);// создаем каждую ноду
                node.SetCoordinate(coordinates[i]);// устанавливаем каждой ноде координаты
                board.AddNode(node);// добавили ноды в граф
            }
            return board;
        }
        

        private int ReadInteger(StreamReader streamReader)// метод считывания строки и превращения в целое число
        {
            return Convert.ToInt32(streamReader.ReadLine());
        }

        
        private List<int> ReadNumbers(StreamReader streamReader)// метод считывания строки и превращения в список целых чисел
        {
            // 1. Создали временный список
            List<int> result = new List<int>(); 
            // 2. Считали массив позиций (пока в строковом формате)
            string[] numbersInStringFormat = streamReader.ReadLine().Split(',');
            // 3. Прошли по каждой цифре и добавили во временный масив
            for (int i = 0; i < numbersInStringFormat.Length; i++)
            {
                int feature = Convert.ToInt32(numbersInStringFormat[i]); // получили массив цифр
                result.Add(feature);
            }
            return result;
        }
        
        public override string ToString()// метод для форматированной печати объектов
        {
            string start = "";
            foreach (var startPosition in StartPositions)
            {
                start = start + startPosition + " ";
            }

            string final = "";
            foreach (var finalPosition in FinalPositions)
            {
                final = final + finalPosition + " ";
            }

            return $"LevelSettings[count - {CountChips}, nodeCount - {Board.GetNodeCount()}, countEdges - {Board.GetEdgesCount()}, startPositions - {start}, finalPositions - {final},\nboard - {Board}]";
        }
    }
}