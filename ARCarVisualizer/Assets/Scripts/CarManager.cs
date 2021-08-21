using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CarManager : MonoBehaviour
{
    public static event Action<GameObject> CarSelected;
    public RingVisualizer ringVisualizer;
    public GameObject selectedCar;
    //public static GameObject selectedCar ;
    public static CarManager Instance;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    // Start is called before the first frame update


    private void Update()
    {
        if (selectedCar != null)
        {
            selectedCar.transform.localPosition = Vector3.Lerp(selectedCar.transform.localPosition, ringVisualizer.hitPoint, Time.deltaTime * 2);
        }
    }


    public void SelectCar(GameObject obj)
    {

        selectedCar = obj;
        selectedCar.SetActive(true);

        Vector3 camForward = Camera.main.transform.forward;
        camForward = new Vector3(camForward.x, 0, camForward.z).normalized;

        Quaternion carRot = Quaternion.LookRotation(-camForward);
        selectedCar.transform.rotation = carRot;
        
        if (CarSelected != null)
        {
            CarSelected.Invoke(selectedCar);
        }
    }
}
