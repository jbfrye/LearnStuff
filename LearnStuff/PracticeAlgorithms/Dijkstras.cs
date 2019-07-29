using System;
using System.Collections.Generic;
using System.Text;
using Priority_Queue;

namespace LearnStuff.PracticeAlgorithms
{
    public struct PathData
    {
        public int cost;
        public DijkstrasNode via;

        public PathData(int c, DijkstrasNode v)
        {
            cost = c;
            via = v;
        }
    }
    class Dijkstras
    {
        DijkstrasNode start = null, end = null;
        SimplePriorityQueue<DijkstrasNode> priQueue = new SimplePriorityQueue<DijkstrasNode>();
        List<DijkstrasNode> dequeued = new List<DijkstrasNode>();
        Dictionary<DijkstrasNode, PathData> table = new Dictionary<DijkstrasNode, PathData>();
        public Dijkstras(DijkstrasNode s, DijkstrasNode e)
        {
            start = s;
            end = e;
            table.Add(s, new PathData(0, null));
            priQueue.Enqueue(s, 0);
            DijkstrasAlgorithm();
            TracePath();
        }

        void DijkstrasAlgorithm()
        {
            while (priQueue.Count > 0)
            {
                DijkstrasNode current = priQueue.Dequeue();
                dequeued.Add(current);

                foreach (KeyValuePair<DijkstrasNode, int> edge in current.edges)
                {
                    // If the table doesn't contain an entry for this node, add it
                    if (!table.ContainsKey(edge.Key))
                    {
                        PathData data = new PathData(table[current].cost + edge.Value, current);
                        table.Add(edge.Key, data);
                    }
                    // If the table contains an entry, update its cost with the new information
                    else
                    {
                        if (!dequeued.Contains(edge.Key))
                            if (table[edge.Key].cost > table[current].cost + edge.Value)
                                table[edge.Key] = new PathData(table[current].cost + edge.Value, current);
                    }
                    // Skip if the node has already been visited
                    if (!dequeued.Contains(edge.Key))
                    {
                        // If this node hasn't been put in the queue yet, add it with it's most up to date cost
                        if (!priQueue.Contains(edge.Key))
                            priQueue.Enqueue(edge.Key, table[edge.Key].cost);
                        // Otherwise update the value of the node in the queue if the cost has changed
                        else
                            priQueue.UpdatePriority(edge.Key, table[edge.Key].cost);
                    }
                }
            }
        }

        public void TracePath()
        {
            Console.WriteLine("Cost: " + table[end].cost);
            List<DijkstrasNode> path = new List<DijkstrasNode>();
            DijkstrasNode current = end;
            while (current != start)
            {
                path.Add(current);
                current = table[current].via;
            }
            path.Add(start);
            for (int i = path.Count-1; i >= 0; i--)
            {
                Console.WriteLine(path[i].name);
            }
        }
        public static void Run()
        {
            /*
            // Interview Cake Test Case
            DijkstrasNode memphis = new DijkstrasNode("Memphis");
            DijkstrasNode newOrleans = new DijkstrasNode("New Orleans");
            DijkstrasNode mobile = new DijkstrasNode("Mobile");
            DijkstrasNode savannah = new DijkstrasNode("Savannah");
            DijkstrasNode atlanta = new DijkstrasNode("Atlanta");
            DijkstrasNode nashville = new DijkstrasNode("Nashville");

            memphis.AddEdge(newOrleans, 3);
            memphis.AddEdge(mobile, 7);
            memphis.AddEdge(atlanta, 10);
            memphis.AddEdge(nashville, 15);

            mobile.AddEdge(newOrleans, 3);
            mobile.AddEdge(savannah, 6);
            mobile.AddEdge(atlanta, 2);

            atlanta.AddEdge(savannah, 1);
            atlanta.AddEdge(nashville, 2);

            Dijkstras findPath = new Dijkstras(memphis, nashville);
            
            /* Expected Output
             * Cost: 10
             * Memphis
             * New Orleans
             * Mobile
             * Atlanta
             * Nashville
            */

            // 
            DijkstrasNode zero = new DijkstrasNode("0");
            DijkstrasNode one = new DijkstrasNode("1");
            DijkstrasNode two = new DijkstrasNode("2");
            DijkstrasNode three = new DijkstrasNode("3");
            DijkstrasNode four = new DijkstrasNode("4");
            DijkstrasNode five = new DijkstrasNode("5");
            DijkstrasNode six = new DijkstrasNode("6");
            DijkstrasNode seven = new DijkstrasNode("7");
            DijkstrasNode eight = new DijkstrasNode("8");

            zero.AddEdge(one, 4);
            zero.AddEdge(seven, 8);

            one.AddEdge(seven, 11);
            one.AddEdge(two, 8);

            two.AddEdge(three, 7);
            two.AddEdge(eight, 2);
            two.AddEdge(five, 4);

            three.AddEdge(four, 9);
            three.AddEdge(five, 14);

            four.AddEdge(five, 10);

            five.AddEdge(six, 2);

            six.AddEdge(eight, 6);
            six.AddEdge(seven, 1);

            seven.AddEdge(eight, 7);

            Dijkstras findPath = new Dijkstras(zero, four);

            /* Expected Output
             * Cost: 21
             * 0
             * 7
             * 6
             * 5
             * 4
            */
        }
    }

    public class DijkstrasNode
    {
        public string name = "";
        public Dictionary<DijkstrasNode, int> edges = new Dictionary<DijkstrasNode, int>();

        public DijkstrasNode(string n)
        {
            name = n;
        }

        public void AddEdge(DijkstrasNode node, int cost)
        {
            edges.Add(node, cost);
            node.AddSingleEdge(this, cost);
        }

        public void AddSingleEdge(DijkstrasNode node, int cost)
        {
            edges.Add(node, cost);
        }
    }
}