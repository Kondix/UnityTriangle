using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnDot : MonoBehaviour {

	public GameObject Dots;

	List<GameObject> lDots;


	// Use this for initialization
	void Start ()
	{
		lDots = new List<GameObject>();
		Spawn ();
	}
	// Update is called once per frame
	void Update () 
	{

	}

	public void DeleteDot (int iIdx = 0)
	{
		Destroy (lDots [iIdx]);
	}

	void Spawn()
	{
		Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0,Screen.width), Random.Range(0,Screen.height), 10)); // heheh z = -10
		Instantiate (Dots, screenPosition, Quaternion.identity); 

	}
}
	
