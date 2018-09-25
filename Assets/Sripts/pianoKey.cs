using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class pianoKey : MonoBehaviour {


	AudioSource note;
	float interval = 1;
	
	// Twelfth root of two, the 'correct' interval between notes
	private float twRootOf2 = Mathf.Pow(2, 1f /12f);

	// Use this for initialization
	void Start () {

		if (this.gameObject.tag == "KeyBlack") {
			this.gameObject.GetComponent<Renderer>().material.color = Color.black;
		}
		note = GetComponent<AudioSource>();
		Debug.Log("x: " + twRootOf2);
	}

	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown() {
		Debug.Log(note.pitch);
		note.pitch *= twRootOf2;
		note.Play();
	}

}
