using System.Collections.Generic;

namespace Parsing
{
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
            for (int i = 0; i < Nodes.Count; i++)// проходимся по всем нодам, спрашиваем у ноды ее индекс
            {
                if (Nodes[i].GetIndex() == index)// сравниваем с переданным в метод индексом
                {
                    return Nodes[i];// возвращаем нужную ноду
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

        public int GetNodeCount()// метод получения количества нод
        {
            return Nodes.Count;
        }

        public int GetEdgesCount()// метод получения количества связей
        {
            var number = 0;
            foreach (var node in Nodes)
            {
                number = number + node.Neighbours.Count;
            }
            return number / 2;
        }
    }
}