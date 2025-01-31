using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class FinishRouteCreationButton : MonoBehaviour
{
    public GameObject BasicCanvas;
    public GameObject RoutesEditor;
    public AddShip addShip;
    public bool BasicCanvasIsEnabled = true;
    public GameObject smallShipPrefab;
    public GameObject averfgeShipPrefab;
    public GameObject largeShipPrefab;
    //public Image buttonImage;
    //public Sprite enableIcon;
    //public Sprite disableIcon;
    bool isRoutesEditorOn = false;
    private void Awake()
    {
        addShip = GameObject.Find("AddShipPanel").GetComponent<AddShip>();
    }
    public void ButtonClicked()
    {
        BasicCanvasIsEnabled = !BasicCanvasIsEnabled;
        BasicCanvas.SetActive(BasicCanvasIsEnabled);
        RoutesEditor.SetActive(!BasicCanvasIsEnabled);
        GameObject[] points = GameObject.FindGameObjectsWithTag("point");
        for (int i = 0; i < points.Length; i++)
        {
            if (points[i] != null)
            {
                points[i].SetActive(false);
            }
        }

    }
    public void ShipsInstantiation()
    {
        for (int i = 0; i < addShip.smallShipAmount; i++) 
        {
            Instantiate(smallShipPrefab);
        }
    }
}
