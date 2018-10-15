using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octave : MonoBehaviour {

	private List<GameObject> keys = new List<GameObject>();

	private float interval;
	private float twRootOf2 = Mathf.Pow(2, 1f / 12f);
	private float pitch = 1 / Mathf.Pow(2, 2f / 12f);

	void initKeys() {
		int numKeys = this.transform.childCount;

		pitch *= this.interval;

		for (int i = 0; i < numKeys; i++) {
			keys.Add(this.gameObject.transform.GetChild(i).gameObject);

			keys[i].GetComponent<pianoKey>().setPitch(pitch);
			pitch *= twRootOf2;
		}
	}


	public void setInterval(float i) {
		this.interval = i;
	}


	void Start() {
		initKeys();
	}


	void Update () {
		
	}
}
