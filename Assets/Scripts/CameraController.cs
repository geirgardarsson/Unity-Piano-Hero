using UnityEngine;

public class CameraController : MonoBehaviour {

	private Transform t; 
	[SerializeField]
	private float activex;

	[SerializeField]
	private bool followUser;
	
	[SerializeField]
	[Range(5f, 50f)]
	private float sensitivity = 20f;

	[SerializeField]
	private float velocity;

	private const float minX = -1f;
	private const float maxX = 43.5f;

	void Awake () {
		t = GetComponent<Transform>();
		activex = t.position[0];
		followUser = false;
	}

	void Update () {
		float pos = t.position[0] + 5f;

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

		if (activex < pos && followUser) {

			velocity = 1f - (pos / (pos + (pos - activex)));
			if (velocity < 0f) velocity = 0f;

		Vector3 move = new Vector3(-sensitivity * velocity, 0f, 0f);
			t.Translate(move * Time.deltaTime);
		}
		else if (activex > pos && followUser) {
			
			velocity = 1f - (pos / (pos + (activex - pos)));

			Vector3 move = new Vector3(sensitivity * velocity, 0f, 0f);
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
		activex = x + 5f;
		followUser = true;
	}
}
