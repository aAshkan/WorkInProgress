using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour {

	[SerializeField]
	private float scrollSpeed = 0.5f;
	//public float tileSizeZ;

	//private Vector3 startPosition;

	void Start ()
	{
		//startPosition = transform.position;
	}

	void Update ()
	{
		Vector2 offset = new Vector2 (Time.time * scrollSpeed, 0);

		GetComponent<Renderer>().material.mainTextureOffset = offset;﻿

		//float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
		//transform.position = startPosition + Vector3.forward * newPosition;
	}
}
