using StartApp;
using UnityEngine;

public class endingscript : MonoBehaviour
{
	public int endingtipe = 1;

	public Texture2D googleplay;

	public Texture2D androidqr2;

	public bool freeversion = true;

	public bool isSamsung;

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
		if (GUI.Button(new Rect(30f, Screen.height - 90, Screen.width / 3, 60f), "Try again"))
		{
			Application.LoadLevel(1);
		}
		if (GUI.Button(new Rect(Screen.width - Screen.width / 3 - 30, Screen.height - 90, Screen.width / 3, 60f), "Quit"))
		{
			if (Random.Range(0, 3) == 0)
			{
				//AdColony.ShowVideoAd("vz4500490c16af4e1488");
			}
			else
			{
			//	AppLovin.InitializeSdk();
			//	AppLovin.ShowInterstitial();
			}
			Application.LoadLevel(0);
		}
		if (endingtipe == 1)
		{
			GUI.Label(new Rect(100f, Screen.height / 2, Screen.width, 60f), "Pages not completed, please try again");
		}
		if (endingtipe == 2)
		{
			GUI.Label(new Rect(100f, Screen.height / 2, Screen.width, 60f), "All pages found, but you cannot hide!");
		}
		if (endingtipe == 3)
		{
			GUI.Label(new Rect(100f, Screen.height / 2, Screen.width, 60f), "You are escaped, congratulations");
		}
	}

	private void Start()
	{
		StartAppWrapper.showAd();
		StartAppWrapper.loadAd();
		if (Random.Range(0, 3) == 0)
		{
			//AdColony.ShowVideoAd("vz4500490c16af4e1488");
		}
		else
		{
		//	AppLovin.InitializeSdk();
		//	AppLovin.ShowInterstitial();
		}
		Screen.lockCursor = false;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
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
	}
}
