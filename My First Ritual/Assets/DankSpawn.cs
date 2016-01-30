using UnityEngine;
using System.Collections;

public class DankSpawn : MonoBehaviour {

	private GameObject[] dankSpawnpoints;
	public GameObject[] dankObjects;
	public GameObject[] dankRandomObjects;
	bool[] dankAvailableSpawnpoints = new bool[17];
	// Use this for initialization
	void Start () {
		dankSpawnpoints = GameObject.FindGameObjectsWithTag("dankSpawn");
		for(int i = 0; i < dankAvailableSpawnpoints.Length; i++)
		{
			dankAvailableSpawnpoints[i] = true;
		}

		dankPrioritySpawn();
		dankRandomSpawn();
	}

	void dankRandomSpawn()
	{
		int dankRandom = Random.Range(0, dankSpawnpoints.Length);
		int temp = 0;
		for(int i = 0; i < dankRandomObjects.Length; i++)
		{
			if(dankAvailableSpawnpoints[dankRandom] == true)
			{
				dankAvailableSpawnpoints[dankRandom] = false;
				Instantiate(dankRandomObjects[i]);
				dankRandomObjects[i].transform.position = new Vector3(dankSpawnpoints[dankRandom].transform.position.x, dankSpawnpoints[dankRandom].transform.position.y, dankSpawnpoints[dankRandom].transform.position.z);
				dankRandomObjects[i].transform.localScale = new Vector3 (7, 7, 1);
			}

			else
			{
				for(int j = 0; j < dankSpawnpoints.Length; j++)
				{
					if(dankAvailableSpawnpoints[j] == true)
					{
						dankAvailableSpawnpoints[j] = false;
						Instantiate(dankRandomObjects[i]);
						dankRandomObjects[i].transform.position = new Vector3(dankSpawnpoints[j].transform.position.x, dankSpawnpoints[j].transform.position.y, dankSpawnpoints[j].transform.position.z);
						dankRandomObjects[i].transform.localScale = new Vector3 (7, 7, 1);
						break;
					}
				}
			}
		}
	}

	void dankPrioritySpawn()
	{
		Debug.Log(dankRandomObjects.Length);
		int dankRandom = Random.Range(0, dankSpawnpoints.Length);
		int temp = 0;
		for(int i = 0; i < dankObjects.Length; i++)
		{
			if(dankAvailableSpawnpoints[dankRandom] == true)
			{
				dankAvailableSpawnpoints[dankRandom] = false;
				Instantiate(dankObjects[i]);
				dankObjects[i].transform.position = new Vector3(dankSpawnpoints[dankRandom].transform.position.x, dankSpawnpoints[dankRandom].transform.position.y, dankSpawnpoints[dankRandom].transform.position.z);
				dankObjects[i].transform.localScale = new Vector3 (7, 7, 1);
			}

			else
			{
				for(int j = 0; j < dankSpawnpoints.Length; j++)
				{
					if(dankAvailableSpawnpoints[j] == true)
					{
						Debug.Log(j);
						dankAvailableSpawnpoints[j] = false;
						Instantiate(dankObjects[j]);
						dankObjects[j].transform.position = new Vector3(dankSpawnpoints[j].transform.position.x, dankSpawnpoints[j].transform.position.y, dankSpawnpoints[j].transform.position.z);
						dankObjects[j].transform.localScale = new Vector3 (7, 7, 1);
					}
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
