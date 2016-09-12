using UnityEngine;
using System.Collections;

public class DotDestroy : MonoBehaviour {

	public float destroyTime = 5.0f;  //zastosowałem timer, nie mam warunków destroya

	// Use this for initialization
	void Start () 
	{
		Destroy (gameObject, destroyTime);
	}

}
