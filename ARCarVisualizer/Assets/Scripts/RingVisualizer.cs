using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class RingVisualizer : MonoBehaviour
{
    public GameObject ringObject;
    public ARRaycastManager raycastManager;
    Vector2 screenPoint;
    [HideInInspector] public Vector3 hitPoint;
     
    // Start is called before the first frame update
    void Start()
    {
        screenPoint = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
        ringObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        List<ARRaycastHit> planeHits = new List<ARRaycastHit>();
        if (raycastManager.Raycast(screenPoint, planeHits, TrackableType.Planes))
        {
            ringObject.transform.position = planeHits[0].pose.position;
            ringObject.SetActive(true);
            hitPoint = planeHits[0].pose.position;        
        }
    }
}
 