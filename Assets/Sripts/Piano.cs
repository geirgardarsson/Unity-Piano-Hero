using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano : MonoBehaviour {

	private List<GameObject> octaves = new List<GameObject>();
	private float[] intervals = new float[7] {
		0.125f, 0.25f, 0.5f, 1f, 2f, 4f, 8f
	};

	void initOctives() {
		int numOctaves = this.transform.childCount;

		for (int i = 0; i < numOctaves; i++) {
			octaves.Add(this.gameObject.transform.GetChild(i).gameObject);
			octaves[i].GetComponent<Octave>().setInterval(intervals[i]);
		}
	}

	void Awake() {
		initOctives();
	}

	void Start () {
		
	}
	
	void Update () {
		
	}
}
