using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using JetBrains.Annotations;

public class RoutesEditor : MonoBehaviour
{
    private RoutesEditorButton routesEditorButton;

    public GameObject port;
    
    void Start()
    {
        routesEditorButton = FindObjectOfType<RoutesEditorButton>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPortClick()
    {
        if(routesEditorButton.isRoutesEditorOn == true)
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    //Задать Порт как стартовую точку для маршрута
                }
            }
            if (Input.GetMouseButtonDown(1)) 
            { 
                // та я низнаю
            }
        }
    }
}
