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
}