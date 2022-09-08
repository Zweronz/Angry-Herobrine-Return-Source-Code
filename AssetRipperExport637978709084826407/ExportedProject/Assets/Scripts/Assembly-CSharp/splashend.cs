using StartApp;
using UnityEngine;

public class splashend : MonoBehaviour
{
	private void splash()
	{
		Application.LoadLevel(0);
	}

	private void Start()
	{
	//	AppLovin.InitializeSdk();
	//	AdColony.Configure("1.0", "app9b94c021b41440c8b5", "vz4500490c16af4e1488");
		StartAppWrapper.init();
		titlescript.splash = false;
		Invoke("splash", 1.5f);
	}

	private void OnGUI()
	{
		StartAppWrapper.showSplash();
	}

	private void Update()
	{
	}
}
