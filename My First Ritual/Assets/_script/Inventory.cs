using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

	public GameObject player;
	public int kay = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.I))
		{
			if(kay > 0)
			{
				this.transform.position = new Vector2(100f, -2);
				kay = 0;
			}
			else
			{
				this.transform.position = new Vector2(player.transform.position.x - 15f, player.transform.position.y - 1.48f);
				kay++;
			}
		}
	}
}
