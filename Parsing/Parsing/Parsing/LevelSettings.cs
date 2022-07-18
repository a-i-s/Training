using System.Collections.Generic;

namespace Parsing
{
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
}