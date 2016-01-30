using UnityEngine;
using System.Collections;

public class DankSpawn : MonoBehaviour {

	private GameObject[] dankSpawnpoints;
	public GameObject[] dankObjects;

	// Use this for initialization
	void Start () {
		dankSpawnpoints = GameObject.FindGameObjectsWithTag("dankSpawn");
		bool[] dankAvailableSpawnpoints = new bool[dankSpawnpoints.Length];
		for(int i = 0; i < dankAvailableSpawnpoints.Length; i++)
		{
			dankAvailableSpawnpoints[i] = true;
		}

		dankSpawn();
	}

	void dankSpawn()
	{
		int dankRandom = Random.Range(0, dankSpawnpoints.Length);
		for(int i = 0; i < dankObjects.Length; i++)
		{
			Instantiate(dankObjects[i]);
			dankObjects[i].transform.position = dankSpawnpoints[dankRandom].transform.position;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
