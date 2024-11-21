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
        spline.space = SplineComputer.Space.World;
        if (Input.GetMouseButtonDown(0) && firstPortClick == false) 
        {
            for (int i = 0; i < points.Length; i++)
            {
                if (i == 0)
                {
                    points[i] = new SplinePoint();
                    points[i].position = port.transform.position;
                    points[i].normal = Vector3.up;
                    points[i].size = 1f;
                    points[i].color = Color.white;
                    /*Õ-------------------------------ÏÐÅÄÈÄÓÙÈÉ-ÂÀÐÈÀÍÒ-ÊÎÄÀ------------------------------------Õ
                    points[i] = new SplinePoint();

                    // Ðîäèòåëüñêèé îáúåêò ñïëàéíà
                    Transform splineParent = port.transform;

                    // Âû÷èñëÿåì ïîçèöèþ
                    Vector3 portWorldPosition = port.transform.position;
                    Vector3 portLocalPosition = splineParent != null
                        ? splineParent.transform.InverseTransformPoint(portWorldPosition)
                        : portWorldPosition;

                    // Ïðèñâàèâàåì ïîçèöèþ
                    points[i].position = portLocalPosition;

                    points[i].normal = Vector3.up;
                    points[i].size = 1f;
                    points[i].color = Color.white;
                    spline.space = SplineComputer.Space.World;
                    // Îòëàäêà
                    Debug.Log($"Port World Position: {portWorldPosition}");
                    Debug.Log($"Assigned SplinePoint Position: {points[i].position}");
                    Õ-------------------------------ÏÐÅÄÈÄÓÙÈÉ-ÂÀÐÈÀÍÒ-ÊÎÄÀ------------------------------------Õ*/
                }
                else 
                {
                    points[i] = new SplinePoint();
                    points[i].position = Input.mousePosition;
                    points[i].normal = Vector3.zero;
                    points[i].size = 1f;
                    points[i].color = Color.white;
                }
                
            }

            spline.SetPoints(points);
        }
       
    }
}
