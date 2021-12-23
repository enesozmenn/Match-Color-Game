using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{
    public GameObject DrawPrefab;
    GameObject theTrail;
    public GameObject brush;
    Plane planeObj;
    Vector3 startPos;
    //
    public Material[] materials;
    void Start()
    {
        planeObj = new Plane(Camera.main.transform.forward * -1 ,this.transform.position);
    }
    private void ColorChecker(TrailRenderer trail)
    {
        switch (PlayerPrefs.GetInt("SelectedPaint"))
        {
            case 1:
                trail.material = materials[0];
                break;
            case 2:
                trail.material = materials[1];
                break;
            case 3:
                trail.material = materials[2];
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0))
        {
            theTrail = (GameObject)Instantiate(DrawPrefab, this.transform.position, Quaternion.identity);
            ColorChecker(theTrail.GetComponent<TrailRenderer>());
            theTrail.AddComponent<ColorAdjuster>().materials=materials;

            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            float _dis;

            if(planeObj.Raycast(mouseRay, out _dis))
            {
                startPos = mouseRay.GetPoint(_dis);
            }
        }
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetMouseButton(0))
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            float _dis;

            if (planeObj.Raycast(mouseRay, out _dis))
            {
                theTrail.transform.position = mouseRay.GetPoint(_dis);
                brush.transform.position = mouseRay.GetPoint(_dis);
            }
        }
    }
}
