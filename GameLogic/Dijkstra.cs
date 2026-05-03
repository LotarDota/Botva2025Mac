using System.Collections.Generic;

namespace Botva2025;

public class Dijkstra
{
	private Graph graph;

	private List<GraphVertexInfo> infos;

	public Dijkstra(Graph graph)
	{
		this.graph = graph;
	}

	private void InitInfo()
	{
		infos = new List<GraphVertexInfo>();
		foreach (GraphVertex vertex in graph.Vertices)
		{
			infos.Add(new GraphVertexInfo(vertex));
		}
	}

	private GraphVertexInfo GetVertexInfo(GraphVertex v)
	{
		foreach (GraphVertexInfo info in infos)
		{
			if (info.Vertex.Equals(v))
			{
				return info;
			}
		}
		return null;
	}

	public GraphVertexInfo FindUnvisitedVertexWithMinSum()
	{
		int num = int.MaxValue;
		GraphVertexInfo result = null;
		foreach (GraphVertexInfo info in infos)
		{
			if (info.IsUnvisited && info.EdgesWeightSum < num)
			{
				result = info;
				num = info.EdgesWeightSum;
			}
		}
		return result;
	}

	public string FindShortestPath(string startName, string finishName)
	{
		return FindShortestPath(graph.FindVertex(startName), graph.FindVertex(finishName));
	}

	public string FindShortestPath(GraphVertex startVertex, GraphVertex finishVertex)
	{
		InitInfo();
		GraphVertexInfo vertexInfo = GetVertexInfo(startVertex);
		if (vertexInfo != null)
		{
			vertexInfo.EdgesWeightSum = 0;
			while (true)
			{
				GraphVertexInfo graphVertexInfo = FindUnvisitedVertexWithMinSum();
				if (graphVertexInfo == null)
				{
					break;
				}
				SetSumToNextVertex(graphVertexInfo);
			}
		}
		return GetPath(startVertex, finishVertex);
	}

	private void SetSumToNextVertex(GraphVertexInfo info)
	{
		info.IsUnvisited = false;
		foreach (GraphEdge edge in info.Vertex.Edges)
		{
			GraphVertexInfo vertexInfo = GetVertexInfo(edge.ConnectedVertex);
			int num = info.EdgesWeightSum + edge.EdgeWeight;
			if (num < vertexInfo.EdgesWeightSum)
			{
				vertexInfo.EdgesWeightSum = num;
				vertexInfo.PreviousVertex = info.Vertex;
			}
		}
	}

	private string GetPath(GraphVertex startVertex, GraphVertex endVertex)
	{
		string text = endVertex.ToString();
		while (startVertex != endVertex)
		{
			endVertex = GetVertexInfo(endVertex).PreviousVertex;
			if (endVertex == null)
			{
				return "Path not found";
			}
			text = endVertex.ToString() + "," + text;
		}
		return text;
	}
}
