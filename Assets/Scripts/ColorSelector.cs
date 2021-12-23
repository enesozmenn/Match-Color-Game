using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSelector : MonoBehaviour
{
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit))
        {
            if (hit.transform.name == "paint1")
            {
                PlayerPrefs.SetInt("SelectedPaint", 1);
            }
            else if (hit.transform.name == "paint2")
            {
                PlayerPrefs.SetInt("SelectedPaint", 2);
            }
            else if (hit.transform.name == "paint3")
            {
                PlayerPrefs.SetInt("SelectedPaint", 3);
            }
        }
    }
}
