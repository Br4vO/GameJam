using UnityEngine;
using System.Collections;

public class playerControl : MonoBehaviour {

	public float speed = 10f;
	public GameObject eButton;
	public static GameObject[] objects;
	private float relativePoint;
	public static bool isClose = false;
	public static int objectInteger;

	/// <summary>
	/// INVENTORY SHIT COMES HERE
	/// </summary>
	public GameObject inventory;
	private int inventoryCounter = 0;
	private int linecounter = 1;
	private float radcounter = 0;

	private Vector3 move;
	// Use this for initialization
	void Start () {
		objects = GameObject.FindGameObjectsWithTag("dankObject");
		Debug.Log(objects.Length);

		eButton.transform.position = new Vector2(100, 0.2f);
	}
	
	// Update is called once per frame
	void Update () {
		move = new Vector3(Input.GetAxis("Horizontal"), 0);
		transform.position += move * speed * Time.deltaTime;

		isClose = detectShit();
		if(isClose == false)
		{
			eButton.transform.position = new Vector2(100, 0.2f);
		}

		else{
			eButton.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 2);
		}

		if(Input.GetKeyDown(KeyCode.E))
		{
			if(isClose == true)
			{
				if(inventoryCounter < 24)
				{
					objects[objectInteger].transform.parent = inventory.transform;
					inventoryCounter++;
					placeItems();
				}
			}
		}
	}

	private bool detectShit()
	{
		for(int i = 0; i < objects.Length; i++)
		{
			relativePoint = Vector3.Distance(this.transform.position, objects[i].transform.position);
			if(relativePoint <= 1.5)
			{
				objectInteger = i;
				return true;
			}
		}
		return false;	
	}

	void placeItems()
	{
		if(linecounter < 5)
		{
			if(linecounter == 1)
			{
				objects[objectInteger].transform.position = new Vector3(inventory.transform.position.x - 3.45f, inventory.transform.position.y + (4.5f - radcounter), inventory.transform.position.z - 1);
				linecounter++;
			}

			else if(linecounter == 2)
			{
				objects[objectInteger].transform.position = new Vector3(inventory.transform.position.x - 1f, inventory.transform.position.y + (4.5f - radcounter), inventory.transform.position.z - 1);
				linecounter++;
			}

			else if(linecounter == 3)
			{
				objects[objectInteger].transform.position = new Vector3(inventory.transform.position.x + 1f, inventory.transform.position.y + (4.5f - radcounter), inventory.transform.position.z - 1);
				linecounter++;
			}

			else if(linecounter == 4)
			{
				objects[objectInteger].transform.position = new Vector3(inventory.transform.position.x + 3.5f, inventory.transform.position.y + (4.5f - radcounter), inventory.transform.position.z - 1);
				linecounter++;
			}

			if(linecounter >= 5)
			{
				linecounter = 1;
				radcounter += 2f;
			}
		}
	}
}
