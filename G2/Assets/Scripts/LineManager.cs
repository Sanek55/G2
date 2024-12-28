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
using Dreamteck.Splines.Editor;

public class LineManager : MonoBehaviour
{
    //ссылки------------------------------------------------------------------

    private RoutesEditorButton routesEditorButton;
    private Utilities utilities;
    public GameObject lineManager;
    public LineRendererSmoother lrSmoother;
    public LineRenderer lineRenderer;
    public BezierCurve bezierCurve;



    //объекты-----------------------------------------------------------------

    GameObject selectedObject;
    GameObject port;

    //переменные-----------------------------------------------------------------
    public List<GameObject> ports = new List<GameObject>();
    public Vector3[] points = new Vector3[4];
    bool firstClick = true;


    public void Awake()
    {
        Debug.Log($"Before assignment: points length = {points.Length}");
        points = bezierCurve.Points;
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
                lineRenderer = lineManager.AddComponent<LineRenderer>();
                lrSmoother = lineManager.AddComponent<LineRendererSmoother>();
                lrSmoother.Line = lineRenderer;
                PointsAddition(); 
                firstClick = false;
            }
            else
            {
                PointsAddition();
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
    public void PointsAddition ()
    {
        if (firstClick)
        {
            PointAddition(points, 0, ports[ports.Count-1].transform.position); 
        }
        else 
        {
            //int oldPointsLength = points.Length;
           // utilities.PointsArrayResize(points, (ports.Count-1)*3+1);
            Vector3 secondQuartile = (ports[ports.Count - 1].transform.position + ports[ports.Count - 2].transform.position)/2;
            Vector3 firstQuartile = (ports[ports.Count - 2].transform.position + secondQuartile)/2;
            Vector3 thirdQuartile = (secondQuartile + ports[ports.Count-1].transform.position)/2;

            for (int i = /*oldPointsLength*/ 0; i < points.Length; i++)
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
            lineRenderer.positionCount = points.Length;
            lineRenderer.SetPositions(points);

        }

        Vector3 PointAddition(Vector3[] linePoints, int linePointNumber, Vector3 pointCords) //подкорректировать
        {

            if (linePoints[linePointNumber] == null)
            {
                linePoints[linePointNumber] = new Vector3();
                linePoints[linePointNumber] = pointCords;
            }
            else
            {
                linePoints[linePointNumber] = pointCords;
            }
            return linePoints[linePointNumber];
        }

    }
   
}
