using UnityEngine;

public class linkscript : MonoBehaviour
{
	public int tipe;

	private void Start()
	{
	}

	private void OnMouseDown()
	{
		if (tipe == 0)
		{
			Application.LoadLevel(1);
		}
		if (tipe == 1)
		{
			Application.OpenURL("https://play.google.com/store/apps/details?id=com.mine.fivecraft");
		}
	}

	private void Update()
	{
	}
}
