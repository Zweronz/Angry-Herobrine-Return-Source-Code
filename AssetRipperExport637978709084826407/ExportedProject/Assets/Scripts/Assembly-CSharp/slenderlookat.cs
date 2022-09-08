using UnityEngine;

public class slenderlookat : MonoBehaviour
{
	public GameObject target;

	private void SlenderChaseYou()
	{
		if (Vector3.Distance(target.transform.position, base.transform.position) > 4f)
		{
			base.transform.Translate(Vector3.forward * 2.3f);
		}
	}

	private void Start()
	{
		InvokeRepeating("SlenderChaseYou", 1f, 1f);
	}

	private void Update()
	{
		Vector3 worldPosition = new Vector3(target.transform.position.x, base.transform.position.y, target.transform.position.z);
		base.transform.LookAt(worldPosition);
	}
}
