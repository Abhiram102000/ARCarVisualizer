using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public Slider rotationSlider;
    Vector3 carRot;
    float yRot;
    public RectTransform drop;
    public bool isOpen;
    public Animator anim;
    void Start()
    {
        drop = transform.Find("Drop").GetComponent<RectTransform>();
        anim = GetComponent<Animator>();
    }
    public void Open()
    {
        if (isOpen)
        {
            Vector3 scale = drop.localScale;
            scale.y = Mathf.Lerp(scale.y, 1, Time.deltaTime * 12);
            drop.localScale = scale;
        }
        else
        {
            Vector3 scale = drop.localScale;
            scale.y = Mathf.Lerp(scale.y, 0, Time.deltaTime * 12);
            drop.localScale = scale;
        }
    }
    public void OnClickdrop()
    {
        if (!isOpen)
        {
            anim.SetTrigger("Dropdown");
            isOpen = true;
        }
        else
        {
            anim.SetTrigger("Dropclose");
            isOpen = false;
        }
    }


    private void OnEnable()
    {
        CarManager.CarSelected += GetCarRotation;
       
    }

    public void OnSlide(float value)
    {
        if (CarManager.Instance.selectedCar)
        {
            yRot = carRot.y;
            yRot += value;
            CarManager.Instance.selectedCar.transform.localEulerAngles = new Vector3(carRot.x, yRot, carRot.z);
        }
    }
    void GetCarRotation(GameObject go)
    {
        carRot = go.transform.localEulerAngles;
        rotationSlider.value = 0f; 
    }
    public void UnselectObject()
    {
        if (CarManager.Instance.selectedCar != null)
        {
            CarManager.Instance.selectedCar = null;
            
        }
    }
    public void CarColor(Image image)
    {
        if (CarManager.Instance.selectedCar != null)
        {
            MeshRenderer[] meshRenderers = CarManager.Instance.selectedCar.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer mr in meshRenderers)
            {
                Material[] materials = mr.materials;
                foreach (Material mat in materials)
                {
                    if (mat.name == "Body (Instance)")
                    {
                        mat.color = image.color;
                    }
                }
            }
        }
    }

}
