using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishRouteCreationButton : MonoBehaviour
{
    public GameObject BasicCanvas;
    public GameObject RoutesEditor;
    public bool BasicCanvasIsEnabled = true;
    //public Image buttonImage;
    //public Sprite enableIcon;
    //public Sprite disableIcon;
    bool isRoutesEditorOn = false;
    public void ButtonClicked()
    {
        BasicCanvasIsEnabled = !BasicCanvasIsEnabled;
        isRoutesEditorOn = !BasicCanvasIsEnabled;
        BasicCanvas.SetActive(BasicCanvasIsEnabled);
        RoutesEditor.SetActive(!BasicCanvasIsEnabled);

        /*if (BasicCanvasIsEnabled)
        {
            buttonImage.sprite = enableIcon;
        }
        else 
        {
            buttonImage.sprite = disableIcon;
        }*/
        GameObject[] points = GameObject.FindGameObjectsWithTag("point");
        for (int i = 0; i < points.Length; i++) 
        {
            if (points[i] != null)
            {
                points[i].SetActive(false);
            }
        } 

    }  
        void Start()
    {
        
    }
    void Update()
    {
        
    }
}
