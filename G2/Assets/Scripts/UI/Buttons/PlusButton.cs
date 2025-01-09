using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlusButton : MonoBehaviour
{
    public int shipType;
    AddShip addShipScript;
    void Awake()
    {
        addShipScript = (GameObject.Find("AddShipPanel")).GetComponent<AddShip>();
    }
    private void OnButtonClick()
    {
        switch (shipType) 
        {
            case 0:
                addShipScript.smallShipAmount++;
                break;
            case 1:
                addShipScript.averageShipAmount++;
                break;
            case 2: 
                addShipScript.largeShipAmount++;
                break;
        }
    }
}
