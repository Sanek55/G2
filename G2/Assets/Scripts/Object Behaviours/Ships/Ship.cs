using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public ShipStats stats;
    public Operations operations;
    public Dictionary<ProductType, int> _cargoHold = new();
    public Dictionary<ProductType, OperationType> _tradeRules;
    public float supplies;
    private void Start()
    {
        supplies = stats.supplyLimit;
    }
    private void Update()
    {
        InvokeRepeating("SupplyDecrease", 1, 50f);
    }
    private void SupplyDecrease()
    {
        supplies -= 0.0001f;
        SupplyLimits();
    }
    public void SupplyLimits()
    {
        if (supplies < 0)
        {
            Destroy(this.gameObject);
        }
        else if (supplies > stats.supplyLimit)
        {
            supplies = stats.supplyLimit;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("port"))
        {
            PortBehaviour portBehaviour = other.gameObject.GetComponent<PortBehaviour>();
            supplies += portBehaviour.portSuppliesLevel;
            _tradeRules = portBehaviour._tradeRules;
        }
    }
    public void TradeInteraction()
    {

    }
}

