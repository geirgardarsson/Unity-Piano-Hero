using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SongControl : MonoBehaviour {

	[SerializeField]
	[Range(30f, 240f)]
	public float tempo = 120f;
	private string filePath;
	
	[SerializeField]
	private Song song;

	private Dictionary<int, float> noteNumberToX = new Dictionary<int, float>();

	private GameObject note;
	private GameObject bar;

	private float actiontime = 0f;

	[Serializable]
	public class Note {

		public int notenumber;
		public int start;
		public int end;

		public Note(int n, int s, int e) {
			notenumber = n;
			start = s;
			end = e;
		}
	}


	[Serializable]
	public class Track {

		[SerializeField]
		public Note[] notes;

		public Track(Note[] n) {
			notes = n;
		}
	}


	[Serializable]
	private class Song {

		public string name;
		public int[] tempo;
		[SerializeField]
		public Track[] tracks;

		public Song(string n, int[] te, Track[] tr) {
			name = n;
			tempo = te;
			tracks = tr;
		}
  }


	private float RateFromTempo(float t) {
		return 60f / t;
	}


	private void initNoteNumbers() {

		float xcoord = -5f;
		int firstnote = 24;
		int lastnote = 107;

		for (int i = firstnote; i < lastnote; i += 1) {
			this.noteNumberToX.Add(i, xcoord);

			/*
			 * On every 5th and 12th note there is a big gap, 1.1,
			 * otherwise a small gap 0.55
			 */
			if ((i - firstnote) % 12 == 4 || ((i - firstnote) % 12 == 11)) {
				xcoord += 1.1f;
			} else {
				xcoord += 0.55f;
			}
		}
	}


	void Awake() {
		initNoteNumbers();

		filePath = Application.dataPath + "/Resources/Json/";

		string songName = "Colosso.json";
		string json = File.ReadAllText(filePath + songName);

		this.song = JsonUtility.FromJson<Song>(json);

		this.bar = (GameObject)Resources.Load("Bar", typeof(GameObject));
		this.note = (GameObject)Resources.Load("Note", typeof(GameObject));
	}




	void Update () {

		if (Time.time > actiontime) {
			actiontime += RateFromTempo(tempo);

			//Instantiate(bar);

			Instantiate(
				note,
				new Vector3(UnityEngine.Random.Range(10f,40f),60f, 0.38f),
				new Quaternion(0f,0f,0f,0f)
			);
		}
	}

}
