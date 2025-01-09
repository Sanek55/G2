using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddShip : MonoBehaviour
{
    public int smallShipAmount;
    public int smallShipPrice = 200;
    public int averageShipAmount;
    public int averageShipPrice = 500;
    public int largeShipAmount;
    public int largeShipPrice = 1000;
    public int CalculateTotalShipCost()
    {
        int sum = smallShipAmount*smallShipPrice + averageShipAmount*averageShipPrice + largeShipAmount*largeShipPrice;
        return sum;
    }
}
