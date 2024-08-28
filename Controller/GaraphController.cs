using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class GraphController : ControllerBase
{
    private readonly IGraphRepository _graphRepository;

    public GraphController(IGraphRepository graphRepository)
    {
        _graphRepository = graphRepository;
    }

    [HttpGet("nodes")]
    public IActionResult GetNodes()
    {
        return Ok(_graphRepository.GetNodes());
    }

    [HttpGet("nodes/{id}")]
    public IActionResult GetNode(int id)
    {
        var node = _graphRepository.GetNodeById(id);
        if (node == null)
        {
            return NotFound();
        }
        return Ok(node);
    }

    [HttpPost("nodes")]
    public IActionResult AddNode([FromBody] Node node)
    {
        _graphRepository.AddNode(node);
        return CreatedAtAction(nameof(GetNode), new { id = node.Id }, node);
    }

    [HttpPut("nodes/{id}")]
    public IActionResult UpdateNode(int id, [FromBody] Node node)
    {
        if (id != node.Id)
        {
            return BadRequest();
        }

        var existingNode = _graphRepository.GetNodeById(id);
        if (existingNode == null)
        {
            return NotFound();
        }

        _graphRepository.UpdateNode(node);
        return NoContent();
    }

    [HttpDelete("nodes/{id}")]
    public IActionResult DeleteNode(int id)
    {
        var node = _graphRepository.GetNodeById(id);
        if (node == null)
        {
            return NotFound();
        }

        _graphRepository.DeleteNode(id);
        return NoContent();
    }

    [HttpGet("edges")]
    public IActionResult GetEdges()
    {
        return Ok(_graphRepository.GetEdges());
    }

    [HttpGet("edges/{id}")]
    public IActionResult GetEdge(int id)
    {
        var edge = _graphRepository.GetEdgeById(id);
        if (edge == null)
        {
            return NotFound();
        }
        return Ok(edge);
    }

    [HttpPost("edges")]
    public IActionResult AddEdge([FromBody] Edge edge)
    {
        _graphRepository.AddEdge(edge);
        return CreatedAtAction(nameof(GetEdge), new { id = edge.Id }, edge);
    }

    [HttpPut("edges/{id}")]
    public IActionResult UpdateEdge(int id, [FromBody] Edge edge)
    {
        if (id != edge.Id)
        {
            return BadRequest();
        }

        var existingEdge = _graphRepository.GetEdgeById(id);
        if (existingEdge == null)
        {
            return NotFound();
        }

        _graphRepository.UpdateEdge(edge);
        return NoContent();
    }

    [HttpDelete("edges/{id}")]
    public IActionResult DeleteEdge(int id)
    {
        var edge = _graphRepository.GetEdgeById(id);
        if (edge == null)
        {
            return NotFound();
        }

        _graphRepository.DeleteEdge(id);
        return NoContent();
    }
}