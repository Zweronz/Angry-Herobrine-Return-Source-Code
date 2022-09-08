using UnityEngine;

public class gotogameplayscript : MonoBehaviour
{
	private void gotogameplay()
	{
		Application.LoadLevel(1);
	}

	private void Start()
	{
		Invoke("gotogameplay", 3f);
	}

	private void Update()
	{
	}
}
