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

	Color32[] noteColors = new Color32[5] {
		new Color32(255, 191,   0, 1),
		new Color32(153, 102, 204, 1),
		new Color32(222,  49,  99, 1),
		new Color32( 80, 200, 120, 1),
		new Color32( 66, 134, 244, 1)
	};


	public void SetNoteNumber(int i) {
		this.noteNumber = i;
	}


	void Start () {
		piano = GameObject.Find("/Piano");

		t = GetComponent<Transform>();
		r = GetComponent<MeshRenderer>();

		halfLength = (t.localScale[1] / 2f);

		r.material.color = noteColors[
			Random.Range(0, noteColors.Length - 1)
		];

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
