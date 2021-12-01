using UnityEngine;

public class Node
{
    public int gridPosX { get; private set; }
    public int gridPosY { get; private set; }

    public bool isWall { get; private set; }
    public Vector2 worldPos { get; private set; }

    public Node previuosNode;

    public int gCost;
    public int hCost;

    public int fCost { get { return hCost + gCost; } }

    public Node(bool isWall, Vector2 worldPos, int gridPosX, int gridPosY)
    {
        this.isWall = isWall;
        this.worldPos = worldPos;
        this.gridPosX = gridPosX;
        this.gridPosY = gridPosY;
    }
}
