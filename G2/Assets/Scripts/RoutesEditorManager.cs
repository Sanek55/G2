using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using JetBrains.Annotations;
using Dreamteck.Splines;
using Dreamteck;
using System;

public class RoutesEditorManager : MonoBehaviour
{
    private RoutesEditorButton routesEditorButton;

    public GameObject port;



    void Start()
    {

        routesEditorButton = FindObjectOfType<RoutesEditorButton>();
 

    }
    void Update()
    {

        OnPortClickEditorMode();
    }
    public void OnPortClickEditorMode()
    {
        if(routesEditorButton.RoutesEditorIsEnabled && Input.GetMouseButtonDown(0))
        {
            bool firstPortClick = true;
            Debug.Log("Mouse pressed");


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity) && gameObject != null /*&& firstPortClick*/)
            {
                
                Debug.Log("Raycast Succes");
                Debug.Log(" gameObject Succes");
                firstPortClick = false;
                SplineComputer spline = gameObject.AddComponent<SplineComputer>(); 
                SplinePoint[] points = new SplinePoint[12];
                points[0] = new SplinePoint();
                points[0].position = Vector3.forward * 0;
                points[0].normal = Vector3.up;
                points[0].size = 1 ;
                points[0].color = Color.white;
            }
            else { Debug.Log("gameObject is null"); }
            
        }
    }
}
