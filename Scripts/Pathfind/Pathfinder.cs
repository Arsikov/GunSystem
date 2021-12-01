using System.Collections.Generic;
using UnityEngine;

public class CustomPathfinder
{
    public NodeGrid nodeGrid { get; private set; }
    public List<Node> FinalPath { get; private set; }

    public CustomPathfinder()
    {
        nodeGrid = GameObject.FindObjectOfType<NodeGrid>();
        FinalPath = new List<Node>();
    }

    public void FindPath(Vector2 startPos, Vector2 targetPos)
    {
        Node nodeA = nodeGrid.GetNodeFromWorldPos(startPos);
        Node nodeB = nodeGrid.GetNodeFromWorldPos(targetPos);

        List<Node> openList = new List<Node>();
        HashSet<Node> closedList = new HashSet<Node>();

        openList.Add(nodeA);

        while (openList.Count > 0)
        {
            Node currentNode = openList[0];
            for(int i = 1; i < openList.Count; i++)
            {
                if(openList[i].fCost <= currentNode.fCost && openList[i].hCost < currentNode.hCost)
                {
                    currentNode = openList[i];
                }
            }

            openList.Remove(currentNode);
            closedList.Add(currentNode);

            if(currentNode == nodeB)
            {
                GetFinalPath(nodeA, nodeB);
                return;
            }

            foreach(Node neighborNode in nodeGrid.GetNeighboringNodes(currentNode))
            {
                if(neighborNode.isWall || closedList.Contains(neighborNode)) continue;

                int moveCost = currentNode.gCost + GetManhatenDistance(currentNode, neighborNode);

                if(moveCost < neighborNode.gCost || !openList.Contains(neighborNode))
                {
                    neighborNode.gCost = moveCost;
                    neighborNode.hCost = GetManhatenDistance(neighborNode, nodeB);
                    neighborNode.previuosNode = currentNode;

                    if (!openList.Contains(neighborNode))openList.Add(neighborNode);
                }
            }
        }
    }

    private void GetFinalPath(Node nodeA, Node nodeB)
    {
        Node currentNode = nodeB;

        while (currentNode != nodeA)
        {
            FinalPath.Add(currentNode);
            currentNode = currentNode.previuosNode;
        }

        FinalPath.Reverse();
        nodeGrid.SetFinalPaht(FinalPath);
    }

    private int GetManhatenDistance(Node nodeA, Node nodeB)
    {
        int x = Mathf.Abs(nodeA.gridPosX - nodeB.gridPosX);
        int y = Mathf.Abs(nodeA.gridPosY - nodeB.gridPosY);

        return x + y;
    }
}
