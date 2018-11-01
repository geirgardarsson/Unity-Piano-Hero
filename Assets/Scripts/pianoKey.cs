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


	public void setAudioClip(AudioClip newClip) {
		this.note.clip = newClip;
	}


	public void setPitch(float p) {
		this.note.pitch = p;
	}


	void OnMouseDown() {
		note.Play();
		SignalCamera();
	}
	


	void SignalCamera() {
		float xpos = GetComponent<Transform>().position[0];

		Camera cam = Camera.main;
		cam.GetComponent<CameraController>().Signal(xpos);
	}

}
