using StartApp;
using UnityEngine;

public class StartAppBackPlugin : MonoBehaviour
{
	private void Start()
	{
		StartAppWrapper.loadAd();
	}

	private void Update()
	{
		if (Input.GetKeyUp(KeyCode.Escape) && !StartAppWrapper.onBackPressed(base.gameObject.name))
		{
			exit();
		}
	}

	private void exit()
	{
		Application.Quit();
	}
}
