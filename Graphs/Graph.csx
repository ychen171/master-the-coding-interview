
using System.Globalization;
using System.Collections.Generic;

class Graph
{
    private int numberOfNodes;
    private Dictionary<int, HashSet<int>> adjacentDict;
    public Graph()
    {
        numberOfNodes = 0;
        adjacentDict = new Dictionary<int, HashSet<int>>();
    }

    public void AddVertex(int node)
    {
        if (!adjacentDict.ContainsKey(node)) 
        {
            adjacentDict[node] = new HashSet<int>();
            numberOfNodes++;
        }
        return;
    }

    public void AddEdge(int node1, int node2)
    {
        // undirected graph
        adjacentDict[node1].Add(node2);
        adjacentDict[node2].Add(node1);
        return;
    }

    public void ShowConnections()
    {
        foreach (var kv in adjacentDict)
        {
            var key = kv.Key;
            var valueSet = kv.Value;
            var sb = new StringBuilder();
            sb.Append($"{kv.Key} --> ");
            foreach (var item in valueSet)
                sb.Append($" {item}");
            Console.WriteLine(sb.ToString());
        }
        return;
    }
}

var myGraph = new Graph();
myGraph.AddVertex(0);
myGraph.AddVertex(1);
myGraph.AddVertex(2);
myGraph.AddVertex(3);
myGraph.AddVertex(4);
myGraph.AddVertex(5);
myGraph.AddVertex(6);

myGraph.AddEdge(3, 1);
myGraph.AddEdge(3, 4);
myGraph.AddEdge(4, 2);
myGraph.AddEdge(4, 5);
myGraph.AddEdge(1, 2);
myGraph.AddEdge(1, 0);
myGraph.AddEdge(0, 2);
myGraph.AddEdge(6, 5);

myGraph.ShowConnections();
