using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShipPrice : MonoBehaviour
{
    AddShip addShipScript;
    TextMeshProUGUI textPanel;
    GameObject textPanelObject;

    public void Awake()
    {
        addShipScript = GetComponent<AddShip>();

    }
    private void TextPanelSetup(string textPanelName, int shipType)
    {
        int shipPrice = 0;
        textPanelObject = GameObject.Find(textPanelName);
        switch (shipType)
        {
            case 0:
                shipPrice = addShipScript.smallShipPrice;
                break;
            case 1:
                shipPrice = addShipScript.averageShipPrice;
                break;
            case 2:
                shipPrice = addShipScript.largeShipPrice; 
                break;
        }
        textPanel = textPanelObject.GetComponent<TextMeshProUGUI>();
        textPanel.text = "Small ship price: " + shipPrice;
    }
}
