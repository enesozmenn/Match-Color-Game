using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorAdjuster : MonoBehaviour
{
    public Material[] materials;
    public TrailRenderer trail;
    private void Start()
    {
        trail = this.gameObject.GetComponent<TrailRenderer>();
    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.GetComponent<TrailRenderer>().material==materials[0] || hit.transform.gameObject.GetComponent<MeshRenderer>().material==materials[0])
            {
                PlayerPrefs.SetInt("SelectedPaint", 3);
            }
            else if (hit.transform.gameObject.GetComponent<TrailRenderer>().material == materials[1] || hit.transform.gameObject.GetComponent<MeshRenderer>().material == materials[1])
            {
                PlayerPrefs.SetInt("SelectedPaint", 3);
            }
            else if (hit.transform.gameObject.GetComponent<TrailRenderer>().material == materials[2] || hit.transform.gameObject.GetComponent<MeshRenderer>().material == materials[2])
            {
                PlayerPrefs.SetInt("SelectedPaint", 3);
            }
        }


        switch (PlayerPrefs.GetInt("SelectedPaint"))
        {
            case 1: trail.material = materials[0];
                break;
            case 2: trail.material = materials[1];
                break;
            case 3: trail.material = materials[2];
                break;
        }
    }
}
