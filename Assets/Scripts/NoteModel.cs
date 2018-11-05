using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteModel : MonoBehaviour {

	private Transform t;
	private MeshRenderer r;

	private GameObject control;
	private Vector3 startScale = new Vector3(0.8f, 3f, 1f);
	private float startTime;
	private float speed;

	Color32[] noteColors = new Color32[5] {
		new Color32(255, 191,   0, 1),
		new Color32(153, 102, 204, 1),
		new Color32(222,  49,  99, 1),
		new Color32( 80, 200, 120, 1),
		new Color32( 66, 134, 244, 1)
	};

	void Start () {
		t = GetComponent<Transform>();
		r = GetComponent<MeshRenderer>();

		r.material.color = noteColors[
			Random.Range(0, noteColors.Length - 1)
		];

		startTime = Time.time;

		t.position += new Vector3(0f, t.localScale[1]/2f, 0f);

		control = GameObject.Find("SongBoard");
		speed = control.GetComponent<SongControl>().tempo / 4f;
	}
	
	void Update () {

		speed = control.GetComponent<SongControl>().tempo / 4f;
		t.position += speed * Vector3.down * Time.deltaTime;

		if (t.position[1] + (t.localScale[1] / 2) < 0) {
			Destroy(this.gameObject);
		}

	}
}
