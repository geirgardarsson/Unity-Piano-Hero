using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongText : MonoBehaviour {


	public void SetText(string n) {
		GetComponent<TextMesh>().text = n;
	}


	public void Activate() {
		GetComponent<TextMesh>().fontStyle = FontStyle.Bold;
	}

	public void DeActivate() {
		GetComponent<TextMesh>().fontStyle = FontStyle.Normal;
	}


	void Start () {
		GetComponent<TextMesh>().color = Color.green;
		GetComponent<TextMesh>().fontSize = 10;
	}
}
