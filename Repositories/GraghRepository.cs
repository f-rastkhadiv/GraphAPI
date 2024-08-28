using System.Collections.Generic;
using System.Linq;

public class GraphRepository : IGraphRepository
{
    private List<Node> Nodes = new List<Node>();

    private List<Edge> Edges = new List<Edge>();

    public IEnumerable<Node> GetNodes()
    {
        return Nodes;
    }

    public Node GetNodeById(int id)
    {
        return Nodes.FirstOrDefault(n => n.Id == id);
    }

    public void AddNode(Node node)
    {
        node.Id = Nodes.Count + 1;
        Nodes.Add(node);
    }

    public void UpdateNode(Node node)
    {
        var existingNode = GetNodeById(node.Id);
        if (existingNode != null)
        {
            existingNode.Name = node.Name;
        }
    }

    public void DeleteNode(int id)
    {
        var node = GetNodeById(id);
        if (node != null)
        {
            Nodes.Remove(node);
        }
    }

    public IEnumerable<Edge> GetEdges()
    {
        return Edges;
    }

    public Edge GetEdgeById(int id)
    {
        return Edges.FirstOrDefault(e => e.Id == id);
    }

    public void AddEdge(Edge edge)
    {
        edge.Id = Edges.Count + 1;
        Edges.Add(edge);
    }

    public void UpdateEdge(Edge edge)
    {
        var existingEdge = GetEdgeById(edge.Id);
        if (existingEdge != null)
        {
            existingEdge.FromNodeId = edge.FromNodeId;
            existingEdge.ToNodeId = edge.ToNodeId;
            existingEdge.Weight = edge.Weight;
        }
    }

    public void DeleteEdge(int id)
    {
        var edge = GetEdgeById(id);
        if (edge !=  null)
        {
            Edges.Remove(edge);
        }
    }
}