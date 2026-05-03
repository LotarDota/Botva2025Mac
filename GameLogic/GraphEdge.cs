namespace Botva2025;

public class GraphEdge
{
	public GraphVertex ConnectedVertex { get; }

	public int EdgeWeight { get; }

	public GraphEdge(GraphVertex connectedVertex, int weight)
	{
		ConnectedVertex = connectedVertex;
		EdgeWeight = weight;
	}
}
