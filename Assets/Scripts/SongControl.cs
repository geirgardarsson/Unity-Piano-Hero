using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongControl : MonoBehaviour {

	[SerializeField]
	[Range(5f, 700f)]
	public float tempo = 20f;

	private Transform transform;
	private List<GameObject> bars = new List<GameObject>();

	void Awake() {
		transform = GetComponent<Transform>();
	}
	
	void Update () {

	}

}
