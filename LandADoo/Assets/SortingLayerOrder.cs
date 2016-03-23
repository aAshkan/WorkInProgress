using UnityEngine;
using System.Collections;

public class SortingLayerOrder : MonoBehaviour {
	
	[SerializeField]
	private int order;
	[SerializeField]
	private string layerName;

	// Use this for initialization
	void Start () {
		GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = layerName;
		GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingOrder = order;
	}
}

