using System.Collections.Generic;
using UnityEngine;

public class randomNotePlacement : MonoBehaviour
{
	public List<GameObject> spawnspot = new List<GameObject>();

	public List<GameObject> deathnote = new List<GameObject>();

	private int[] note_assign = new int[20];

	private void Start()
	{
		int num = spawnspot.Count;
		for (int i = 0; i < spawnspot.Count; i++)
		{
			note_assign[i] = i;
		}
		for (int j = 0; j < 8; j++)
		{
			int num2 = Random.Range(0, num - 1);
			deathnote[j].transform.position = spawnspot[note_assign[num2]].transform.position;
			deathnote[j].transform.rotation = spawnspot[note_assign[num2]].transform.rotation;
			note_assign[num2] = note_assign[num - 1];
			num--;
		}
	}

	private void Update()
	{
	}
}
