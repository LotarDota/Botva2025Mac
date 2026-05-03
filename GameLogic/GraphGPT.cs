using System;
using System.Collections.Generic;

namespace Botva2025;

public class GraphGPT
{
	private Dictionary<string, HashSet<string>> adjList;

	public GraphGPT()
	{
		adjList = new Dictionary<string, HashSet<string>>();
	}

	public void AddVertex(string vertex)
	{
		if (!adjList.ContainsKey(vertex))
		{
			adjList[vertex] = new HashSet<string>();
		}
	}

	public void AddEdge(string from, string to, int weight)
	{
		AddVertex(from);
		AddVertex(to);
		adjList[from].Add(to);
		adjList[to].Add(from);
	}

	public void PrintGraph()
	{
		foreach (KeyValuePair<string, HashSet<string>> adj in adjList)
		{
			Console.Write(adj.Key + ": ");
			foreach (string item in adj.Value)
			{
				Console.Write(item + " ");
			}
		}
	}

	public List<string> FindShortestPath(string start, string end)
	{
		Queue<string> queue = new Queue<string>();
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		queue.Enqueue(start);
		dictionary[start] = null;
		while (queue.Count > 0)
		{
			string text = queue.Dequeue();
			if (text == end)
			{
				List<string> list = new List<string>();
				while (text != null)
				{
					list.Add(text);
					text = dictionary[text];
				}
				list.Reverse();
				return list;
			}
			foreach (string item in adjList[text])
			{
				if (!dictionary.ContainsKey(item))
				{
					queue.Enqueue(item);
					dictionary[item] = text;
				}
			}
		}
		return null;
	}
}
