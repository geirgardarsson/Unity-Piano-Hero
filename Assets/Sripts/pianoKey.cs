using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class pianoKey : MonoBehaviour {


	private AudioSource note;
	

	void Awake() {
		note = GetComponent<AudioSource>();
	}


	void Update () {

	}


	public void setPitch(float p) {
		this.note.pitch = p;
	}


	void OnMouseDown() {
		note.Play();
	}

}
