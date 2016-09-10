using UnityEngine;
using System.Collections;



public class TriangleBehaviour : MonoBehaviour {

    public float fSmooth = 1.0f;
    public float fTiltAngle = 30.0f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float tiltAroundZ = Input.GetAxis("Horizontal") * fTiltAngle;
        Quaternion target = Quaternion.Euler(0, 0, tiltAroundZ);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * fSmooth);
    }
}
