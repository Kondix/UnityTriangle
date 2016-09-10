using UnityEngine;
using System.Collections;



public class TriangleBehaviour : MonoBehaviour {

    public float fTiltAngle = 30.0f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * fTiltAngle);
    }
}
