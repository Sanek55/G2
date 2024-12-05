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
using UnityEditor.Experimental.GraphView;
using System.Net;
using UnityEngine.AI;

public class SplineManager : MonoBehaviour
{
    private RoutesEditorButton routesEditorButton;
    private Utilities utilities;

    public List<GameObject> ports = new List<GameObject>();
    public SplinePoint[] points = new SplinePoint[1];
    bool firstClick = true;

    public GameObject splineManager;



    SplineComputer spline;
    SplineRenderer splineRenderer;

    GameObject selectedObject;
    GameObject port;



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
        if (routesEditorButton.RoutesEditorIsEnabled && Input.GetMouseButtonDown(0) && PortCheck())
        {
            ports.Add(port);

            if (firstClick)
            {
                spline = splineManager.AddComponent<SplineComputer>();
                splineRenderer = splineManager.AddComponent<SplineRenderer>();
                splineRenderer.spline = spline;
                PointsAddition(spline);
                firstClick = false;
            }
            else
            {
                PointsAddition(spline);
            }
        }

    }
    public bool PortCheck()
    {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                selectedObject = hit.collider.gameObject;
                Transform parentTransform = selectedObject.transform.parent;
                port = parentTransform.gameObject;

                if (parentTransform.CompareTag("port"))
                {
                    return true;
                }
            }
       
        return false;
    }
    public void PointsAddition (SplineComputer spline)
    {
        spline.space = SplineComputer.Space.World;
        if (firstClick)
        {
            PointAddition(points, 0, ports[ports.Count-1].transform.position);
        }
        else 
        {
            int oldPointsLength = points.Length;

            utilities.PointsArrayResize(points, (ports.Count-1)*3+1);
            Vector3 secondQuartile = (ports[ports.Count - 1].transform.position + ports[ports.Count - 2].transform.position)/2;
            Vector3 firstQuartile = (ports[ports.Count - 2].transform.position + secondQuartile)/2;
            Vector3 thirdQuartile = (secondQuartile + ports[ports.Count-1].transform.position)/2;

            for (int i = oldPointsLength; i < points.Length; i++)
            {
                switch (i % 3)
                {
                    case 0:

                        int portNumber = i / 3;

                        PointAddition(points, i, ports[portNumber].transform.position);

                        break;

                    case 1:

                        PointAddition(points, i, firstQuartile);

                        break;

                    case 2:

                        PointAddition(points, i, thirdQuartile);

                        break;
                }
                   
            }

        }
        spline.SetPoints(points);

        SplinePoint PointAddition(SplinePoint[] splinePoints, int splinePointNumber, Vector3 pointCords)
        {
            Debug.Log(splinePoints.Length);
            Debug.Log(splinePointNumber);
            Debug.Log(splinePoints.Length > splinePointNumber);
            if (splinePoints[splinePointNumber] == null)
            {
                splinePoints[splinePointNumber] = new SplinePoint();
            }

            splinePoints[splinePointNumber].position = pointCords;
            splinePoints[splinePointNumber].normal = Vector3.zero;
            splinePoints[splinePointNumber].size = 1f;
            splinePoints[splinePointNumber].color = Color.white;

            return splinePoints[splinePointNumber];
        }

    }
}
