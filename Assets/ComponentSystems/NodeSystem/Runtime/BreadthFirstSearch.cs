using System.Collections.Generic;
using UnityEngine;

namespace NodeSystem
{
    public static class BreadthFirstSearch
    {
        public static List<int> Search(Dictionary<int, NodeObject> nodeMap, int root, int destination)
        {
            Queue<int> queue = new Queue<int>();
            Dictionary<int, int> Path = new Dictionary<int, int>();

            queue.Enqueue(root);

            int terminator = 0;
            while (queue.Count > 0)
            {
                int nodeId = queue.Dequeue();

                if (nodeId == destination)
                    break;

                foreach (var neighbour in nodeMap[nodeId].Neighbours)
                {
                    if (Path.ContainsKey(neighbour.Id) == false)
                        Path.Add(neighbour.Id, nodeId);

                    queue.Enqueue(neighbour.Id);

                    terminator++;

                    if (terminator > 1000)
                    {
                        Debug.LogError("Error while BFS");
                        return null;
                    }
                }

                terminator++;

                if (terminator > 1000)
                {
                    Debug.LogError("Error while BFS");
                    return null;
                }
            }

            int current = destination;

            List<int> path = new List<int>();

            path.Add(current);

            for (; ; )
            {
                if (current == root)
                    break;

                path.Add(Path[current]);
                current = Path[current];
            }

            path.Reverse();

            return path;
        }

        public static int GetDistance(Dictionary<int, NodeObject> nodeMap, int root, int destination)
        {
            return Search(nodeMap, root, destination).Count - 1;
        }
    }
}