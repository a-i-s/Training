using System.Collections.Generic;
using System.Numerics;

namespace Parsing
{
    public class Node
    {
        private int _index; // номер узла
        Vector2 Position; // содержит две координаты x и y
        public List<Node> Neighbours {get; set;} = new List<Node>();  // список ссылок на другие ноды 

        public Node(int index)
        {
            _index = index;
        }
        
        public void SetCoordinate(Vector2 coordinate)// установить координаты
        {
            Position = coordinate;
        }

        public int GetIndex()// получить номер узла
        {
            return _index;
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
                neigbourghs = neigbourghs + neighbour._index + ", ";
            }
            
            return $"Node[number - {_index}, position - {Position}, Neighbours - {neigbourghs}]";
        }
    }
}