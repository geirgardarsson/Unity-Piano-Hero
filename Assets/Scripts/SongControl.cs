using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SongControl : MonoBehaviour {

	[SerializeField]
	[Range(5f, 80f)]
	public float tempo = 20f;
	private string filePath;


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


	void Awake() {
		filePath = Application.dataPath + "/Resources/Json/";

		string songName = "Colosso.json";
		string json = File.ReadAllText(filePath + songName);

		Song song = JsonUtility.FromJson<Song>(json);

	}


	void Update () {

	}

}
