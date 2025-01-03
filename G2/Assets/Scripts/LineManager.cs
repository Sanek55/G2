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
using Dreamteck.Utilities;

public class LineManager : MonoBehaviour
{
    //ссылки------------------------------------------------------------------

    private RoutesEditorButton routesEditorButton;
    public Utilities utilities;
    public GameObject lineManager;
    public LineRendererSmoother lrSmoother;
    public LineRendererSmoother lrSmootherEditor;
    public LineRenderer lineRenderer;
    public BezierCurve bezierCurve;
    PointBehaviour pointBehaviour;

    //объекты-----------------------------------------------------------------

    GameObject selectedObject;
    GameObject port;
    public GameObject pointPrefab;

    //переменные--------------------------------------------------------------
   
    public List<GameObject> ports = new List<GameObject>();
    public Vector3[] points = new Vector3[4];
    bool firstPortSelected = true;
    public int repetitionsCounter;

    //------------------------------------------------------------------------

    public void Awake()
    {
        points = bezierCurve.Points;
        routesEditorButton = FindObjectOfType<RoutesEditorButton>();
    }
    void Update()
    {
        OnEditorMode();
        LinePositionsSet();
    }
    public void OnEditorMode()
    {
        if (routesEditorButton.RoutesEditorIsEnabled && Input.GetMouseButtonDown(0))
        {
            if (PortCheck())
            {
                ports.Add(port);

                if (firstPortSelected)
                {
                    lineRenderer = lineManager.AddComponent<LineRenderer>();
                    lrSmoother = lineManager.AddComponent<LineRendererSmoother>();
                    lrSmoother.Line = lineRenderer;
                    PointsAddition();
                    firstPortSelected = false;
                }
                else
                {
                    PointsAddition();
                }
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
                if (parentTransform != null)
                {
                    if (parentTransform.CompareTag("port"))
                    {
                        port = parentTransform.gameObject;
                        return true;
                    }
                }
            }
        return false;
    }
    public void PointsAddition()
    {
        int arrayFillNumber = 0;

        if (firstPortSelected)
        {
            PointAddition(points, 0, ports[ports.Count-1].transform.position);
        }
        else 
        {
            if (repetitionsCounter > 0)
            {
                int oldPointsLength = points.Length;
                points = utilities.PointsArrayResize(points, (ports.Count - 1) * 3 + 1);
                PointPositionSet(oldPointsLength, points, ports);
            }
            else 
            {
                PointPositionSet(0, points, ports);
            }

            for (int i = 0; i < points.Length; i++)
            {

                if (points[i] == null) 
                { 
                    continue; 
                }
                else 
                { 
                    arrayFillNumber++; 
                }
            }

            LinePositionsSet();

            if (arrayFillNumber == points.Length) 
            { 
                repetitionsCounter++; 
            }
        }
        Vector3[] PointPositionSet(int amountOfAssignedPoints, Vector3[] points, List<GameObject> ports)
        {
            Vector3 secondQuartile = (ports[ports.Count - 1].transform.position + ports[ports.Count - 2].transform.position) / 2;
            Vector3 firstQuartile = (ports[ports.Count - 2].transform.position + secondQuartile) / 2;
            Vector3 thirdQuartile = (secondQuartile + ports[ports.Count - 1].transform.position) / 2;

            for (int i = amountOfAssignedPoints; i < points.Length; i++)
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
            return points;
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
    void PointObjectCreation()
    {
        for (int i = 0; i < points.Length; i++)
        {
            GameObject point = Instantiate(pointPrefab, points[i], Quaternion.identity);
            pointBehaviour = point.GetComponent<PointBehaviour>();
            pointBehaviour.pointID = i;
        }
    }
    void LinePositionsSet()
    {
        lineRenderer.positionCount = points.Length;
        lineRenderer.SetPositions(points);
        PointObjectCreation();
    }
}
