using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteModel : MonoBehaviour {

	private Transform t;

	private GameObject control;
	private Vector3 startScale = new Vector3(0.8f, 3f, 1f);
	private float startTime;
	private float speed;

	void Start () {
		t = GetComponent<Transform>();
		startTime = Time.time;

		t.localScale = startScale;

		control = GameObject.Find("SongBoard");
		speed = control.GetComponent<SongControl>().tempo / 4f;
	}
	
	void Update () {

		speed = control.GetComponent<SongControl>().tempo / 4f;
		t.position += speed * Vector3.down * Time.deltaTime;

		if (t.position[1] < 0) {
			Destroy(this.gameObject);
		}

	}
}
