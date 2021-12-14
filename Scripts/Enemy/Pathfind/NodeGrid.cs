using System.Collections.Generic;
using UnityEngine;

public class NodeGrid : MonoBehaviour
{
    public Vector2 gridWorldSize;
    public float nodeRadius;

    Node[,] grid;
    public List<Node> FinalPath;


    private float nodeDiameter;
    private int gridSizeX, gridSizeY;

    private void Start()
    {
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);

        GenerateGrid();
    }

    private void GenerateGrid()
    {
        grid = new Node[gridSizeX, gridSizeY];

        Vector2 firstNodePos = transform.position 
            - Vector3.right * gridWorldSize.x / 2 
            - Vector3.up * gridWorldSize.y / 2;
        
        for(int x = 0; x < gridSizeX; x++)
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector2 newNodeWorldPos = firstNodePos
                    + Vector2.right * (x * nodeDiameter + nodeRadius)
                    + Vector2.up * (y * nodeDiameter + nodeRadius);

                bool nodeIsWall = Physics2D.OverlapCircle(newNodeWorldPos, nodeRadius, LayerMask.GetMask("Wall"));

                grid[x, y] = new Node(nodeIsWall, newNodeWorldPos, x, y);
            }
    }

    public Node GetNodeFromWorldPos(Vector2 pos)
    {
        float xPoint = Mathf.Clamp01((pos.x + gridWorldSize.x / 2) / gridWorldSize.x);
        float yPoint = Mathf.Clamp01((pos.y + gridWorldSize.y / 2) / gridWorldSize.y);

        int x = Mathf.RoundToInt((gridSizeX - 1) * xPoint);
        int y = Mathf.RoundToInt((gridSizeY - 1) * yPoint);

        return grid[x, y];
    }

    public List<Node> GetNeighboringNodes(Node node)
    {
        List<Node> NeighboringNodes = new List<Node>();
        
        for(int x = -1; x <= 1; x++)
            for(int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0) continue;

                int checkX = node.gridPosX + x;
                int checkY = node.gridPosY + y;

                if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                    NeighboringNodes.Add(grid[checkX, checkY]);
            }

        return NeighboringNodes;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, new Vector2(gridWorldSize.x, gridWorldSize.y));

        if (grid != null)
        {
            foreach (Node node in grid)
            {
                if (node.isWall) Gizmos.color = Color.blue;
                else Gizmos.color = Color.green;

                if (FinalPath != null && FinalPath.Contains(node)) Gizmos.color = Color.red;

                Gizmos.DrawWireCube(node.worldPos, Vector2.one * (nodeDiameter - 0.05f));
            }
        }
    }

    public void SetFinalPaht(List<Node> finalPath)
    {
        FinalPath = null;
        FinalPath = finalPath;
    }
}
