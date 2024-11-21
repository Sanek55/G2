using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using JetBrains.Annotations;
using Dreamteck.Splines;
using Dreamteck;
using System;
using UnityEngine.U2D;

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
        if (routesEditorButton.RoutesEditorIsEnabled && Input.GetMouseButtonDown(0))
        {
            bool firstPortClick = true;
          //  Debug.Log("Mouse pressed");


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity) && gameObject != null && firstPortClick)
            {

                //Debug.Log("Raycast Succes");
                //Debug.Log(" gameObject Succes");

                

                SplineComputer spline = gameObject.AddComponent<SplineComputer>();
                SplineRenderer splineRenderer = gameObject.AddComponent<SplineRenderer>();
                Debug.Log(splineRenderer);
                splineRenderer.spline = spline;
                bool componentIsAdded = true;
                firstPortClick = false;

                PointsAddition(spline, firstPortClick);
            }
            else { }

        }
    }
    public void PointsAddition (SplineComputer spline, bool firstPortClick)
    {
        SplinePoint[] points = new SplinePoint[5];
        //if (points != null) { Debug.Log("points is created"); }
        if (Input.GetMouseButtonDown(0) && firstPortClick == false)
        {
            for (int i = 0; i < points.Length; i++)
            {
                if (i == 0)
                {
                    points[i] = new SplinePoint();
                    //Debug.Log(points[i]);
                    
                    points[i].position = port.transform.position;
                    //Debug.Log(points[i].position);
                    
                    points[i].normal = Vector3.up;
                   // Debug.Log(points[i].normal);
                    
                    points[i].size = 1f;
                    //Debug.Log(points[i].size);
                    
                    points[i].color = Color.white;
                    //Debug.Log(points[i].color);
                }
                else 
                {
                    points[i] = new SplinePoint();
                   // Debug.Log(points[i]);

                    points[i].position = Input.mousePosition;
                   // Debug.Log(points[i].position);

                    points[i].normal = Vector3.zero;
                   // Debug.Log(points[i].normal);

                    points[i].size = 1f;
                    //Debug.Log(points[i].size);

                    points[i].color = Color.white;
                    //Debug.Log(points[i].color);
                }
                
            }

            spline.SetPoints(points);
        }
       
    }
}
