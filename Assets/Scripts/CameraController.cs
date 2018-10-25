using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private Transform t; 
	[SerializeField]
	private float activex;

	[SerializeField]
	private bool followUser;
	
	[SerializeField]
	[Range(5f, 50f)]
	private float acceleration = 20f;
	
	private const float minX = -1f;
	private const float maxX = 43.5f;

	void Awake () {
		t = GetComponent<Transform>();
		activex = t.position[0];
		followUser = false;
	}

	void Update () {
		if (Input.GetButton("Horizontal")) {
			followUser = false;

			float newpos = Input.GetAxisRaw("Horizontal");

			if (newpos > 0) {
				Vector3 move = new Vector3(10f, 0f, 0f);
				t.Translate(move * Time.deltaTime);
			} 
			
			else if (newpos < 0) {
				Vector3 move = new Vector3(-10f, 0f, 0f);
				t.Translate(move * Time.deltaTime);
			}
		}	

		if (activex < t.position[0] && followUser) {

			float velocity = 1f - (activex / t.position[0]);
			if (velocity < 0f) velocity = 0f;

			Vector3 move = new Vector3(-acceleration * velocity, 0f, 0f);
			t.Translate(move * Time.deltaTime);
		}
		else if (activex > t.position[0] && followUser) {
			
			float velocity = 1f - (t.position[0] / activex);
			Vector3 move = new Vector3(acceleration * velocity, 0f, 0f);
			t.Translate(move * Time.deltaTime);
		}

		if (t.position[0] < minX) {
			Vector3 newpos = t.position;
			newpos[0] = minX;
			t.position = newpos;
			followUser = false;
		}

		if (t.position[0] > maxX) {
			Vector3 newpos = t.position;
			newpos[0] = maxX;
			t.position = newpos;
			followUser = false;
		}

	}

	public void Signal(float x) {
		activex = x;
		followUser = true;
	}
}
