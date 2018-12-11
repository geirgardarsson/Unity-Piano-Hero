using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class SongSelect : MonoBehaviour {

	[SerializeField]
	private List<string> songnames = new List<string>();
	[SerializeField]
	private List<GameObject> nameobjects = new List<GameObject>();
	private GameObject songtext;
	private Transform t;
	private int selectedSong = 0;

	private void GetSongNames() {
		string path = Application.dataPath + "/Resources/Json";
		DirectoryInfo dir = new DirectoryInfo(path);
		FileInfo[] info = dir.GetFiles();
		Regex r = new Regex(@"^.*\.(json)$");

		foreach (FileInfo f in info) {
			string name = f.ToString();
			
			if (r.IsMatch(name)) {
				Regex splt = new Regex(@"\/");
				string[] s = splt.Split(name);
				name = s[s.Length-1].Split('.')[0];

				this.songnames.Add(name);
			}
		}
	}


	private void InitiateSongText() {

		float y = 0f;

		foreach (string name in songnames) {
			GameObject instance = Instantiate(songtext, t);
			instance.GetComponent<SongText>().SetText(name);
			instance.GetComponent<Transform>().Translate(Vector3.right * 10);
			instance.GetComponent<Transform>().Translate(Vector3.down * y);
			y += 1.5f;

			nameobjects.Add(instance);
		}
	}


	void Start () {
		t = GetComponent<Transform>();
		this.songtext = (GameObject)Resources.Load("SongSelectorText", typeof(GameObject));
		GetSongNames();
		InitiateSongText();
		nameobjects[0].GetComponent<SongText>().Activate();
	}


	void Update () {

		if (Input.GetKeyUp("up")) {
			nameobjects[selectedSong].GetComponent<SongText>().DeActivate();
			selectedSong = selectedSong == 0
				? songnames.Count-1
				: selectedSong-1;
			nameobjects[selectedSong].GetComponent<SongText>().Activate();
		}

		if (Input.GetKeyUp("down")) {
			nameobjects[selectedSong].GetComponent<SongText>().DeActivate();
			selectedSong = selectedSong == songnames.Count-1
				? 0
				: selectedSong+1;
			nameobjects[selectedSong].GetComponent<SongText>().Activate();
		}

		if (Input.GetKeyUp("return")) {
			GameObject control = GameObject.Find("SongBoard");
			control.GetComponent<SongControl>().SetSong(songnames[selectedSong]);
			Destroy(this.gameObject);
		}
	}
}
