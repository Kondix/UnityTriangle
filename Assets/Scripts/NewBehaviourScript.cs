using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	public Transform[] SpawnPoints;
	public float SpawnTime = 0.5f;

	public GameObject Dots;
	// pozniej zrobimy public GameObject[] Dots;

	// Use this for initialization
	void Start () 
	{
		InvokeRepeating ("Spawn", SpawnTime, 5); // 5 trzeba zamienic z ilością kolizji, najlepiej jakaś tablica
	}

	// Update is called once per frame
	void Update () {

	}


	void Spawn()
	{
		int spawnIndex = Random.Range (0, SpawnPoints.Length); //w zaleznosci ile spawnpointow, od razu robi random
		Instantiate (Dots, SpawnPoints[spawnIndex].position, SpawnPoints[spawnIndex].rotation);

	}
}
