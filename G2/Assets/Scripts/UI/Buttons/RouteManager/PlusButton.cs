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
    public void OnButtonClick()
    {
        switch (shipType) 
        {
            case 0:
                addShipScript.smallShipAmount++;
                break;
            case 1:
                addShipScript.mediumShipAmount++;
                break;
            case 2: 
                addShipScript.largeShipAmount++;
                break;
        }
    }
}
