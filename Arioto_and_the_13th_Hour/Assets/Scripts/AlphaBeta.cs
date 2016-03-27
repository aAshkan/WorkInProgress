using UnityEngine;
using System.Collections;

public class AlphaBeta{
	private bool MaxPlayer = true;
	private GameStateTree tree;
	private int pHealth;
	private int eHealth;
	public int treeDepth;
	public int leaf;


	public AlphaBeta(int _depth){
		treeDepth = _depth;
		tree = new GameStateTree (treeDepth);
	}

	public void FindLeaf(){
		tree.MakeTree ();
		pHealth = tree.root.getPHealth();
		eHealth = tree.root.getEHealth();
		leaf = Iterate (tree.root, tree.depth, -1000000, 100000, MaxPlayer);
		//Debug.Log (leaf);
		//Debug.Log (CreateClone.enemyClones[tree.root.children[leaf].movedIndex].name);
	}

	public int Iterate(GameStateNode node, int depth, int alpha, int beta, bool Player){
		if (depth == 0 /*|| node.IsTerminal()*/){
			return node.GetTotalScore(pHealth, eHealth);
		}
		
		if (Player == MaxPlayer){

			int leaf = -1;
			int value = -100000;
			foreach (GameStateNode child in node.children){
				value = Iterate(child, depth - 1, alpha, beta, !Player);
				if(alpha < value){
					leaf = node.children.IndexOf(child);
				}
				alpha = Mathf.Max (alpha, value);
				if (beta < alpha){
					break;
				}
				/*//////////////
				if(alpha < Iterate(child, depth - 1, alpha, beta, !Player)){
					leaf = node.children.IndexOf(child);
				}
				//////////////
				alpha = Mathf.Max(alpha, Iterate(child, depth - 1, alpha, beta, !Player));
				if (beta < alpha){
					break;
				}
				*/
			}
			if(depth == treeDepth)
				return leaf; 
			return alpha;
		}
		else{
			foreach (GameStateNode child in node.children/*(Player)*/){
				beta = Mathf.Min(beta, Iterate(child, depth - 1, alpha, beta, !Player));
				if (beta < alpha){
					break;
				}
			}
			return beta;
		}
	}

	public string entityName(){
		return CreateClone.enemyClones[tree.root.children[leaf].movedIndex].name;
	}

	public position entityPos(){
		return tree.root.children[leaf].entities.enemies[tree.root.children[leaf].movedIndex].pos;
	}
}