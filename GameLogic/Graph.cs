using System.Collections.Generic;

namespace Botva2025;

public class Graph
{
	public List<GraphVertex> Vertices { get; }

	public Graph()
	{
		Vertices = new List<GraphVertex>();
	}

	public void AddVertex(string vertexName)
	{
		Vertices.Add(new GraphVertex(vertexName));
	}

	public GraphVertex FindVertex(string vertexName)
	{
		foreach (GraphVertex vertex in Vertices)
		{
			if (vertex.Name.Equals(vertexName))
			{
				return vertex;
			}
		}
		return null;
	}

	public void AddEdge(string firstName, string secondName, int weight)
	{
		GraphVertex graphVertex = FindVertex(firstName);
		GraphVertex graphVertex2 = FindVertex(secondName);
		if (graphVertex2 != null && graphVertex != null)
		{
			graphVertex.AddEdge(graphVertex2, weight);
			graphVertex2.AddEdge(graphVertex, weight);
		}
	}
}
