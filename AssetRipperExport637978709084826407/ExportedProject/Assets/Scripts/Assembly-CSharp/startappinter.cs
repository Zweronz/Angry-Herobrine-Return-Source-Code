using StartApp;
using UnityEngine;

public class startappinter : MonoBehaviour
{
	private void Start()
	{
		StartAppWrapper.loadAd();
		StartAppWrapper.showAd();
		StartAppWrapper.loadAd();
	}

	private void Update()
	{
	}
}
