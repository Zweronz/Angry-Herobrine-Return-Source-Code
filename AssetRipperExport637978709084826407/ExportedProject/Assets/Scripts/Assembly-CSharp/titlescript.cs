using UnityEngine;

public class titlescript : MonoBehaviour
{
	public Texture2D title;

	public Texture2D androidqr1;

	public Texture2D androidqr2;

	private bool viewloading;

	private int posqr;

	public bool freeversion = true;

	public bool isSamsung;

	public bool isWebPlayer;

	public bool isHerobrine;

	public static bool splash = true;

	private void Start()
	{
		Screen.lockCursor = false;
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		viewloading = false;
		if (splash)
		{
			Application.LoadLevel(5);
		}
	}

	private void callMoreAds()
	{
	}

	private void OnGUI()
	{
		GUIStyle label = GUI.skin.label;
		int num = 20;
		GUI.skin.button.fontSize = num;
		num = num;
		GUI.skin.box.fontSize = num;
		label.fontSize = num;
		if (isWebPlayer)
		{
			GUI.Label(new Rect(30f, Screen.height - 200, Screen.width, 50f), "Control : WASD - move  Mouse Move - Look   ESC  Quit");
			if (GUI.Button(new Rect((Screen.width - Screen.width / 3 + 30) / 2, Screen.height - 30 - androidqr1.height, androidqr1.width, androidqr1.height), androidqr1))
			{
				if (false)
				{
					Application.ExternalEval("window.open('https://play.google.com/store/apps/details?id=com.shayort.herobrine3','new title')");
				}
				else
				{
					Application.OpenURL("https://play.google.com/store/apps/details?id=com.shayort.greatherobrinefree");
				}
			}
			if (GUI.Button(new Rect(Screen.width - Screen.width / 3, Screen.height - 30 - androidqr2.height, androidqr2.width, androidqr2.height), androidqr2))
			{
				if (false)
				{
					Application.ExternalEval("https://itunes.apple.com/us/artist/hadi-pintarto/id550426413','new title')");
				}
				else
				{
					Application.OpenURL("https://itunes.apple.com/us/artist/hadi-pintarto/id550426413");
				}
			}
		}
		else if (!isSamsung)
		{
			if (GUI.Button(new Rect((Screen.width - Screen.width / 3 + 30) / 2, Screen.height - 90, Screen.width / 3 - 30, 60f), "Rate Us"))
			{
				Application.OpenURL("https://play.google.com/store/apps/details?id=com.shayort.greatherobrinefree");
			}
			if (GUI.Button(new Rect(Screen.width - Screen.width / 3, Screen.height - 90, Screen.width / 3, 60f), "REMOVE ADS"))
			{
				Application.OpenURL("https://play.google.com/store/apps/details?id=com.shayort.greatherobrine");
			}
		}
		if (posqr == 1)
		{
			GUI.Label(new Rect((Screen.width - Screen.width / 3 + 30) / 2, Screen.height - 100 - androidqr1.height, androidqr1.width, androidqr1.height), androidqr1);
		}
		if (posqr == 2)
		{
			GUI.Label(new Rect(Screen.width - Screen.width / 3, Screen.height - 100 - androidqr2.height, androidqr2.width, androidqr2.height), androidqr2);
		}
		if (viewloading)
		{
			GUI.Label(new Rect(30f, Screen.height - 150, Screen.width, 50f), "Loading the game, please wait");
		}
		if (GUI.Button(new Rect(10f, Screen.height - 90, Screen.width / 3, 60f), "Play the Game"))
		{
			viewloading = true;
			if (isHerobrine)
			{
				Application.LoadLevel(1);
			}
			else
			{
				Application.LoadLevel(5);
			}
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}
