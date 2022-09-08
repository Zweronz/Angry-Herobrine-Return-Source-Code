using UnityEngine;

public class playercollideslenderScript : MonoBehaviour
{
	public GameObject other1;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("slenderman"))
		{
			grabCollider component = other1.GetComponent<grabCollider>();
			component.gameover();
		}
	}

	private void Start()
	{
	}

	private void Update()
	{
	}
}
