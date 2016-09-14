using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnDot : MonoBehaviour {

	public GameObject Dots;
    static public bool bSpawned;
    public List<Object> lDots;

	// Use this for initialization
	void Start ()
	{
        lDots = new List<Object>();
        bSpawned = false;
	}

	// Update is called once per frame
	void Update () 
	{
        if (!bSpawned)
        {
            Spawn();
        }
	}

	public void DeleteDot (int iIdx = 0)
	{
        if (lDots.Count != 0)
        {
            Destroy(lDots[iIdx]);
            lDots.RemoveAt(0);
            bSpawned = false;
        }
	}

	void Spawn()
	{
		Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0,Screen.width), Random.Range(0,Screen.height), 10)); // heheh z = -10
		lDots.Add(Instantiate (Dots, screenPosition, Quaternion.identity));
        bSpawned = true;
	}
}
	
