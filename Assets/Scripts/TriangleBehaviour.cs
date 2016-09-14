using UnityEngine;
using System.Collections;



public class TriangleBehaviour : MonoBehaviour {

    public float fTiltAngle = 30.0f;
    public float fStopRange = 0.5f;
    public float fMovementSpeed = 20f;

    RaycastHit hit;
    public Camera m_camera;

	//SpawnDot spawner;
    bool bMovement;
    bool bHit;
    // Use this for initialization
    void Start () {
        bMovement = false;
		bHit = false;
		//spawner = FindObjectOfType<>;
	}
	
	// Update is called once per frame
	void Update () {
        if (bMovement)
        {
            HandleMovementPhase();
        }
        else
        {
            HandleRotationPhase();
        }
    }

    void HandleMovementPhase ()
    {
        transform.position += ZAngleToVector3(transform.rotation.eulerAngles.z) * Time.deltaTime * fMovementSpeed;
        if (!isInSight(GetViewportPoint()))
        {
            Debug.Log("GameOver.");
            bMovement = false;
            return;
        }

		if (hit.transform.gameObject == null || hit.transform.gameObject.transform.position == null || IsInRange(CountDistance(transform.position, hit.transform.gameObject.transform.position), fStopRange))
        {
            bMovement = false;
            Destroy(hit.transform.gameObject);
			//spawner.DeleteDot();
        }
    }

    void HandleRotationPhase ()
    {
        transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * fTiltAngle);

        bool bMouseUsed = false;
        if (Input.GetMouseButtonDown(0))
            bMouseUsed = true;

        if (bMouseUsed || Input.touchCount == 1)
        {
            if (bMouseUsed || Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)
            {
                bMovement = true;
                if (bHit = CastRay())
                {
                    Debug.Log("Raycast hit.");
                }
            }
        }
    }

    bool CastRay ()
    {
        Ray ray = new Ray(transform.position, ZAngleToVector3(transform.rotation.eulerAngles.z));

        Debug.DrawRay(transform.position, ZAngleToVector3(transform.rotation.eulerAngles.z), Color.red);
        return Physics.Raycast(ray, out hit, 10f);
    }

    Vector3 ZAngleToVector3 (float fZAngle)
    {
        float x = Mathf.Sin(Mathf.PI * fZAngle / 180);
        float y = -Mathf.Cos(Mathf.PI * fZAngle / 180);
        return new Vector3(x, y, 0);
    }

    float CountDistance (Vector3 vPos1, Vector3 vPos2)
    {
        return Mathf.Sqrt(Mathf.Pow(vPos1.x - vPos2.x, 2) + Mathf.Pow(vPos1.y - vPos2.y, 2));
    }

    bool IsInRange (float fRadius, float fMaxRange)
    {
        return fRadius <= fMaxRange;
    }

    Vector3 GetScreenPoint()
    {
        return m_camera.WorldToScreenPoint(transform.position);
    }

    Vector3 GetViewportPoint()
    {
        return m_camera.WorldToViewportPoint(transform.position);
    }

    void LogTrianglePosition(Vector3 screenPos)
    {
        Debug.Log("Triangle coordinats: " + screenPos.x + " " + screenPos.y);
    }

    public bool isInSight(Vector3 screenPos)
    {
        return (0 < screenPos.x && screenPos.x < 1 && 0 < screenPos.y && screenPos.y < 1);
    }
}
