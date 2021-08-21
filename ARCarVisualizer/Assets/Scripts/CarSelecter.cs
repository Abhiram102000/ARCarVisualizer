using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarSelecter : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {

            if (CarManager.Instance != null)
            {
                CarManager.Instance.SelectCar(this.gameObject);
            }
        }
    }
}
