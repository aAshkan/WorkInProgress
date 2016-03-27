using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid {
	public Node[,] grid;
	int gridSizeX;
	int gridSizeY;
	public List<Node> path;

	public Grid(int _gridSizeX, int _gridSizeY) {
		gridSizeX = _gridSizeX;
		gridSizeY = _gridSizeY;
		grid = new Node[gridSizeX,gridSizeY];

		for (int x = 0; x < gridSizeX; ++x) {
			for (int y = 0; y < gridSizeY; ++y) {
				grid[x, y] = new Node(x, y, true);
			}
		}
	}

	public void updateUnwalkableTiles(position pos){
		Node n = this.grid [pos.x, pos.y];
		n.walkable = !n.walkable;
	}

	public List<Node> GetNeighbours(Node node) {
		List<Node> neighbours = new List<Node>();
		
		for (int x = -1; x <= 1; ++x) {
			for (int y = -1; y <= 1; ++y) {
				if (Mathf.Abs(x+y) != 1)
					continue;

				int checkX = node.pos.x + x;
				int checkY = node.pos.y + y;
				
				if (checkX >= 0 && checkX < gridSizeX && 
				    checkY >= 0 && checkY < gridSizeY) {
					neighbours.Add(grid[checkX,checkY]);
				}
			}
		}
		
		return neighbours;
	}

	public void FindPath(position startPos, position targetPos) {
		path = null;
		Node startNode = grid[startPos.x, startPos.y];
		Node targetNode = grid[targetPos.x, targetPos.y];
		
		List<Node> openSet = new List<Node>();
		HashSet<Node> closedSet = new HashSet<Node>();
		openSet.Add(startNode);
		
		while (openSet.Count > 0) {
			Node currentNode = openSet[0];
			for (int i = 1; i < openSet.Count; i ++) {
				if (openSet[i].fCost < currentNode.fCost || 
				    openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost) {
					currentNode = openSet[i];
				}
			}
			
			openSet.Remove(currentNode);
			closedSet.Add(currentNode);
			
			if (currentNode == targetNode) {
				RetracePath(startNode,targetNode);
				return;
			}
			
			foreach (Node neighbour in GetNeighbours(currentNode)) {
				if (!neighbour.walkable || closedSet.Contains(neighbour)) {
					continue;
				}
				
				int newMovementCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbour);
				if (newMovementCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour)) {
					neighbour.gCost = newMovementCostToNeighbour;
					neighbour.hCost = GetDistance(neighbour, targetNode);
					neighbour.parent = currentNode;
					
					if (!openSet.Contains(neighbour))
						openSet.Add(neighbour);
				}
			}
		}
	}
	
	void RetracePath(Node startNode, Node endNode) {
		List<Node> p = new List<Node>();
		Node currentNode = endNode;
		
		while (currentNode != startNode) {
			p.Add(currentNode);
			currentNode = currentNode.parent;
		}
		p.Reverse();
		
		path = p;
	}
	
	int GetDistance(Node nodeA, Node nodeB) {
		int dstX = Mathf.Abs(nodeA.pos.x - nodeB.pos.x);
		int dstY = Mathf.Abs(nodeA.pos.y - nodeB.pos.y);
		
		if (dstX > dstY)
			return (14 * dstY) + (10 * (dstX-dstY));
		return (14 * dstX) + (10 * (dstY-dstX));
	}

	public void printPath(){
		if (path == null)
			return;
		foreach (Node n in path) {
			Debug.Log ("(" + n.pos.x + ", " + n.pos.y + ")");
		}
	}
}

public class Node {
	public bool walkable;
	public position pos;
	
	public int gCost;
	public int hCost;
	public Node parent;
	
	public Node(int x, int y, bool walkable) {
		pos = new position ();
		this.walkable = walkable;
		this.pos.x = x;
		this.pos.y = y;
	}
	
	public int fCost {
		get {
			return gCost + hCost;
		}
	}
}