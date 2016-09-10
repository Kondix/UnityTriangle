using UnityEngine;
using System.Collections;



public class TriangleBehaviour : MonoBehaviour {

    public float fTiltAngle = 30.0f;
    RaycastHit hit;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * fTiltAngle);
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)
            //if (Input.GetMouseButtonDown(0))
            {
                if (CastRay())
                {
                    Debug.Log("Raycast hit.");
                    MoveToNewPosition();
                }
                else
                {
                    //gameover
                }
            }
        }
    }

    bool CastRay ()
    {
        float x = Mathf.Sin(Mathf.PI * transform.rotation.eulerAngles.z / 180);
        float y = -Mathf.Cos(Mathf.PI * transform.rotation.eulerAngles.z / 180);
        Ray ray = new Ray(transform.position, new Vector3(x, y, 0));

        Debug.DrawRay(transform.position, new Vector3(x, y), Color.red);
        return Physics.Raycast(ray, out hit, 10f);
    }

    void MoveToNewPosition ()
    {
        transform.position = hit.transform.gameObject.transform.position;
        Destroy (hit.transform.gameObject);
    }
}
