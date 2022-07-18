using System.Collections.Generic;
using System.Numerics;

namespace Parsing
{
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