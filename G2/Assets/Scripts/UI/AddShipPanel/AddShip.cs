using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddShip : MonoBehaviour
{
    public int smallShipAmount;
    public int smallShipPrice = 200;
    public int averageShipAmount;
    public int averageShipPrice = 500;
    public int largeShipAmount;
    public int largeShipPrice = 1000;
    private TextMeshProUGUI textMeshProUGUI;
    public int CalculateTotalCost()
    {
        int totalCost = smallShipAmount*smallShipPrice + averageShipAmount*averageShipPrice + largeShipAmount*largeShipPrice;
        return totalCost;
    }
    private void Update()
    {
        textMeshProUGUI = (GameObject.Find("TotalCost")).GetComponent<TextMeshProUGUI>();
    }
}
