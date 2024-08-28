using System.Collections.Generic;

public interface IGraphRepository
{
    IEnumerable<Node> GetNodes();
    Node GetNodeById(int id);
    void AddNode(Node node);
    void UpdateNode(Node node);
    void DeleteNode(int id);

    IEnumerable<Edge> GetEdges();
    Edge GetEdgeById(int id);
    void AddEdge(Edge edge);
    void UpdateEdge(Edge edge);
    void DeleteEdge(int id);
}