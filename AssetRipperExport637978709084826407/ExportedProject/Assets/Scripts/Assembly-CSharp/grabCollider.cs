using StartApp;
using UnityEngine;

public class grabCollider : MonoBehaviour
{
	public bool freeversion = true;

	public bool isSamsung;

	private bool touched;

	public bool usecar;

	private int text_y;

	private GameObject collideobj;

	private int note_count;

	private bool display_note_count;

	private bool display_opening = true;

	private bool gameovered;

	public Camera camera;

	public GameObject target;

	public Texture2D fuzzytv;

	private int counterdisplay;

	public AudioSource getpage;

	public AudioSource found_sound;

	public AudioSource nearby_sound;

	public AudioSource backtocar_sound;

	private bool nearby_played;

	private int counternearby;

	private void LateUpdate()
	{
		if (gameovered)
		{
			Vector3 vector = new Vector3(target.transform.position.x, 2.5f, target.transform.position.z);
			Quaternion to = Quaternion.LookRotation(vector - camera.transform.position);
			camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, to, Time.deltaTime * 2f);
		}
	}

	private void distanceSlenderman()
	{
		if (Vector3.Distance(target.transform.position, base.transform.position) < 55f)
		{
			if (!nearby_played)
			{
				nearby_played = true;
				nearby_sound.Play();
			}
		}
		else if (nearby_played)
		{
			nearby_played = false;
			nearby_sound.Stop();
		}
	}

	private void gotoGameOver()
	{
		if (note_count < 8)
		{
			Application.LoadLevel(2);
		}
		else
		{
			Application.LoadLevel(3);
		}
	}

	public void gameover()
	{
		Debug.Log("gameover");
		if (!gameovered)
		{
			found_sound.Play();
			if ((bool)camera.GetComponent<Rigidbody>())
			{
				camera.GetComponent<Rigidbody>().freezeRotation = true;
			}
			gameovered = true;
			Invoke("gotoGameOver", 5f);
		}
	}

	private void hidenotecount()
	{
		display_note_count = false;
	}

	private void hidenoteopening()
	{
		display_opening = false;
	}

	private void AddNoteCount()
	{
		note_count++;
		if (note_count == 8)
		{
			backtocar_sound.Play();
		}
		display_note_count = true;
		Invoke("hidenotecount", 3f);
	}

	private void Start()
	{
		Screen.lockCursor = true;
		text_y = Screen.height / 2;
		display_note_count = false;
		note_count = 0;
		Invoke("hidenoteopening", 5f);
		StartAppWrapper.init();
		StartAppWrapper.loadAd();
		StartAppWrapper.showAd();
		StartAppWrapper.loadAd();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("note"))
		{
			collideobj = other.gameObject;
			touched = true;
		}
		if (other.gameObject.CompareTag("car") && note_count == 8)
		{
			Application.LoadLevel(4);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("note"))
		{
			touched = false;
		}
	}

	private void OnGUI()
	{
		GUIStyle label = GUI.skin.label;
		int num = 20;
		GUI.skin.button.fontSize = num;
		num = num;
		GUI.skin.box.fontSize = num;
		label.fontSize = num;
		if (gameovered)
		{
			counterdisplay++;
			if (counterdisplay % 3 == 1)
			{
				GUI.Label(new Rect((Screen.width - fuzzytv.width) / 2, (Screen.height - fuzzytv.height) / 2, fuzzytv.width, fuzzytv.height), fuzzytv);
			}
		}
		if (touched)
		{
			GUI.Button(new Rect(25f, text_y - 40, 200f, 50f), "Grab Note");
			getpage.Play();
			Object.DestroyObject(collideobj);
			AddNoteCount();
			touched = false;
		}
		if (display_opening)
		{
			GUI.Label(new Rect(80f, text_y, 300f, 30f), "NIGHT 1: Find all eight pages");
		}
		if (display_note_count)
		{
			GUI.Label(new Rect(25f, text_y, 200f, 30f), "Notes " + note_count + "/8");
		}
		if (usecar && note_count == 8)
		{
			GUI.Label(new Rect(45f, text_y + 30, 500f, 30f), "All notes found, back to your car");
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			StartAppWrapper.showAd();
			StartAppWrapper.loadAd();
			if (Random.Range(0, 3) == 0)
			{
			//	AdColony.ShowVideoAd("vz4500490c16af4e1488");
			}
			else
			{
			//	AppLovin.InitializeSdk();
			//	AppLovin.ShowInterstitial();
			}
			Application.LoadLevel(0);
		}
		counternearby++;
		if (counternearby % 9 == 1)
		{
			distanceSlenderman();
		}
	}
}
