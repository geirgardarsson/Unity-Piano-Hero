using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar: MonoBehaviour {

	private Transform t;

	private Vector3 startPosition = new Vector3(21.45f, 60f, 0.2f);
	private Vector3 startScale = new Vector3(53.8f, 1f, 0.2f);

	private float speed;
	private bool play = false;

	private GameObject control;

	private float startTime;


	void Start () {
		t = GetComponent<Transform>();
		startTime = Time.time;

		t.position = startPosition;
		t.localScale = startScale;

		control = GameObject.Find("SongBoard");
		speed = control.GetComponent<SongControl>().tempo / 4f;

		play = true;
	}
	
	void Update () {

		if (play) {
			
			speed = control.GetComponent<SongControl>().tempo / 4f;
			t.position += speed * Vector3.down * Time.deltaTime;

			if (t.position[1] < 0) {
				Destroy(this.gameObject);
			}
		}
	}

}
