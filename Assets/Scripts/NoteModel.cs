using UnityEngine;

public class NoteModel : MonoBehaviour {

	private Transform t;
	private MeshRenderer r;

	private GameObject control;
	private GameObject piano;
	private float speed;
	private float halfLength;
	private bool hasHit = false;
	private float hitOffset = 0.5f;
	private int noteNumber;


	public void SetNoteNumber(int i) {
		this.noteNumber = i;
	}


	public void SetColor(Color32 col) {
		GetComponent<MeshRenderer>().material.color = col;
	}


	void Start () {
		piano = GameObject.Find("/Piano");
		t = GetComponent<Transform>();
		halfLength = (t.localScale[1] / 2f);
		t.position += new Vector3(0f, t.localScale[1]/2f, 0f);
		control = GameObject.Find("SongBoard");
		speed = control.GetComponent<SongControl>().tempo / 4f;
	}
	
	void Update () {
		speed = control.GetComponent<SongControl>().tempo / 4f;
		t.position += speed * Vector3.down * Time.deltaTime;

		if (t.position[1] - halfLength + hitOffset < 0 && !hasHit) {
			hasHit = true;
			piano.GetComponent<Piano>().PlayNote(noteNumber);
		}

		if (t.position[1] + halfLength + hitOffset < 0) {
			Destroy(this.gameObject);
		}

	}
}
