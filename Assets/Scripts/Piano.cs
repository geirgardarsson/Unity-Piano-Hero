using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;


public class Piano : MonoBehaviour {

	private List<GameObject> octaves = new List<GameObject>();
	public Dictionary<string, float> pitchOffsets = new Dictionary<string, float>();
	private string[] notes = new string[12] {
		"C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"
	};


	private void initOffsets() {

		float i = 0;

		foreach (string note in notes) {

			float offset = 1 * Mathf.Pow(2, i / 12f);
			this.pitchOffsets.Add(note, offset);
			i -= 1f;
		}
	}


	private void initOctives() {

		int numOctaves = this.transform.childCount;

		for (int i = 0; i < numOctaves; i++) {
			octaves.Add(this.gameObject.transform.GetChild(i).gameObject);

			string filename = octaves[i].GetComponent<AudioSource>().clip.name;
			string notename = TrimName(filename);

			float offset = pitchOffsets[notename];

			if (i == 6) {
				offset *= 2f;
			}

			octaves[i].GetComponent<Octave>().SetPitchOffset(offset);
		}
	}

	private string TrimName(string filename) {
		char[] delimimiters = { ' ' };
		Regex r = new Regex(@"\d+");
		string[] m = r.Split(filename);
		string s = m[0].Split(delimimiters)[3];

		return s;
	}

	void Awake() {
		initOffsets();
		initOctives();
	}

	void Start () {
		
	}
	
	void Update () {
		
	}
}
