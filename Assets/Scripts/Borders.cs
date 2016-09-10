using UnityEngine;
using System.Collections;

public class Borders : MonoBehaviour {

    public GameObject m_target;
    public Camera m_camera;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update ()
    {
        LogTrianglePosition(GetViewportPoint());
        Debug.Log("Is triangle in sight: " + isInSight(GetViewportPoint()));
    }

    Vector3 GetScreenPoint ()
    {
        return m_camera.WorldToScreenPoint(m_target.transform.position);
    }

    Vector3 GetViewportPoint ()
    {
        return m_camera.WorldToViewportPoint(m_target.transform.position);
    }

    void LogTrianglePosition (Vector3 screenPos)
    {
        Debug.Log("Triangle coordinats: " + screenPos.x + " " + screenPos.y);
    }

    public bool isInSight(Vector3 screenPos)
    {
        return (0 < screenPos.x && screenPos.x < 1 && 0 < screenPos.y && screenPos.y < 1);
    }


}
