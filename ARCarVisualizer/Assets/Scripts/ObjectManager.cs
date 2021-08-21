using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ObjectManager : MonoBehaviour
{

    public RingVisualizer ringVisualizer;
    public static GameObject selectedObject;

    // Start is called before the first frame update


    private void Update()
    {
        if (selectedObject != null)
        {
            selectedObject.transform.position = Vector3.Lerp(selectedObject.transform.position, ringVisualizer.ringObject.transform.position, Time.deltaTime * 2);
        }
    }

    public void UnselectObject()
    {
        if (selectedObject != null)
        {
            selectedObject = null;
        }
    }

    public void SelectObject(GameObject obj)
    {
        UnselectObject();

        selectedObject = obj;
        selectedObject.SetActive(true);
    }
}