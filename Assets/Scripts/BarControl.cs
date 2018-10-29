using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarControl : MonoBehaviour {

	private Transform t;
	[SerializeField]
	private float startPosition;
	private float speed = 0f;
	private bool play = false;

	// Use this for initialization
	void Start () {
		t = GetComponent<Transform>();
		Transform parent = t.parent.GetComponent<Transform>();
		startPosition = parent.localScale[1];
		play = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (play) {

			speed = t.parent.GetComponent<SongControl>().tempo;
			t.position += speed * Vector3.down * Time.deltaTime;

			if (t.position[1] < 0) {
				Vector3 newpos = t.position;
				newpos[1] = startPosition;
				t.position = newpos;
			}
		}
	}

}
