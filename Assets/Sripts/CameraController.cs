using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private Transform t; 
	Vector3 vec;

	void Awake () {
		t = GetComponent<Transform>();
	}

	void Update () {
		if (Input.GetButton("Horizontal")) {

			float pos = Input.GetAxisRaw("Horizontal");

			if (pos > 0) {
				vec = new Vector3(10f, 0f, 0f);
				t.Translate(vec * Time.deltaTime);
			} 
			
			else if (pos < 0) {
				vec = new Vector3(-10f, 0f, 0f);
				t.Translate(vec * Time.deltaTime);
			}
		}		
	}
}
