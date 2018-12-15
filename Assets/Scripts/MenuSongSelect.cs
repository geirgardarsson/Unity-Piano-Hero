using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;

public class MenuSongSelect : MonoBehaviour {

	[SerializeField]
	private List<string> songnames = new List<string>();
	private Transform content;
	private GameObject button;
	public string selectedSong;

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

	private void AddNamesToMenu() {
		this.button = (GameObject)Resources.Load("SongNameButton", typeof(GameObject));
		this.content = GetComponent<Transform>()
			.GetChild(2).GetComponent<Transform>()
			.GetChild(0).GetComponent<Transform>()
			.GetChild(0).GetComponent<Transform>();

		foreach (string name in songnames) {
			GameObject instance = Instantiate(button, content);
			instance
				.GetComponent<Transform>()
				.GetChild(0)
				.GetComponent<TextMeshProUGUI>().text = name;
		}
	}

	public void SetSelectedSong(string s) {
		this.selectedSong = s;
		Debug.Log("sdasdf");
	}

	void Start () {
		GetSongNames();
		AddNamesToMenu();
	}
	
	void Update () {
		
	}
}
