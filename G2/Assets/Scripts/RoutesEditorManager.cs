using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using JetBrains.Annotations;
using Dreamteck.Splines;
using Dreamteck;

public class RoutesEditorManager : MonoBehaviour
{
    private RoutesEditorButton routesEditorButton;
    private SplineComputer spline;
    public GameObject port;
    private SplinePoint point;
    int splinePointIndex = 0;

    void Start()
    {
        spline = FindObjectOfType<SplineComputer>();
        routesEditorButton = FindObjectOfType<RoutesEditorButton>();
 

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { Debug.Log("Mouse pressed"); }
        OnPortClick();
    }
    public void OnPortClick()
    {
        if(routesEditorButton.RoutesEditorIsEnabled && Input.GetMouseButtonDown(0))
        {
            
                Debug.Log("Mouse pressed");


                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    Debug.Log("Raycast hitted the port");

                    spline.SetPoint(splinePointIndex, point);
                    splinePointIndex++;
                
            }
            
        }
    }
}
