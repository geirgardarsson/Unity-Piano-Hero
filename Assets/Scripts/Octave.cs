using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octave : MonoBehaviour {

	private List<GameObject> keys = new List<GameObject>();
	private AudioClip soundFile;

	private float pitchOffset;
	private float twRootOf2 = Mathf.Pow(2, 1f / 12f);
	private float pitch;


	void InitKeys() {
		soundFile = GetComponent<AudioSource>().clip;

		int numKeys = this.transform.childCount;

		pitch = this.pitchOffset;

		for (int i = 0; i < numKeys; i++) {
			keys.Add(this.gameObject.transform.GetChild(i).gameObject);

			keys[i].GetComponent<pianoKey>().setPitch(pitch);
			keys[i].GetComponent<pianoKey>().setAudioClip(soundFile);
			pitch *= twRootOf2;
		}
	}


	public void SetPitchOffset(float i) {
		this.pitchOffset = i;
	}


	void Start() {
		InitKeys();
	}

}
