using Dreamteck.Splines.Editor;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public ShipStats stats;
    public Product[] cargoHold;
    public float supplies;
    private void Start()
    {
        cargoHold = new Product[stats.loadCapacity];
        supplies = stats.supplyLimit;
    }
    private void Update()
    {
        InvokeRepeating("SupplyDecrease", 1, 0.1f);
    }
    private void SupplyDecrease()
    {
        supplies -= 0.1f;
    }
}

