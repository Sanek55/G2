using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrueFalseButton : MonoBehaviour
{
    public GameObject BasicCanvas;
    public GameObject RoutesEditor;
    public bool BasicCanvasIsEnabled = true;
    //public bool RoutesEditorIsEnabled = false;
    public Image buttonImage;
    public Sprite enableIcon;
    public Sprite disableIcon;

    public void ButtonClicked()
    {
        BasicCanvasIsEnabled = !BasicCanvasIsEnabled;
        BasicCanvas.SetActive(BasicCanvasIsEnabled);
        RoutesEditor.SetActive(!BasicCanvasIsEnabled);

        if (BasicCanvasIsEnabled)
        {
            buttonImage.sprite = enableIcon;
        }
        else 
        {
            buttonImage.sprite = disableIcon;
        }
    }
       
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
