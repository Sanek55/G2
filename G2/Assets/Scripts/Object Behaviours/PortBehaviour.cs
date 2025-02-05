using Dreamteck.Splines;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum ProductType { Gold, Iron, Weapons, Fur, Dyes, Opium, Porcelain, Silk, Spices }
public enum OperationType { Sell, Unload, Load, NoValue}
public class PortBehaviour : MonoBehaviour
{
    //�������� �����
    public string portName;
    public int portID;
    public Region localRegion;
    // ���������
    public int MaxAmountOfSupplies = 10;//�������� ��� ���������
    public int currentAmountOfSupplies = 1; // ����� �������� �� ��� ��� �������
    public int singleSupplyCost = 3;
    public int portSuppliesLevel = 1;
    public int portProductionLevel = 0;
    private int totalSupplyIncrease = 0;
    // ������������
    public float productionCooldown = 60f;
    public int resourseCounter = 0; // Replace later
    // Operations
    public Dictionary<ProductType, OperationType> _tradeRules = new();
    public Dictionary<ProductType, int> _warehouse;
    public OperationType currentOperation;
    public OperationCanvas operationCanvas;
   

    void Start()
    {
        DetectRegion();
        
    }

    void Update()
    {
        PortProduction();
    }
    public void GetTotalSupplyIncrease()
    {
        int difference = MaxAmountOfSupplies - currentAmountOfSupplies;
        if (difference < portSuppliesLevel)
        {
            totalSupplyIncrease = difference;
            currentAmountOfSupplies = MaxAmountOfSupplies;
        }
        else
        {
            totalSupplyIncrease = portSuppliesLevel;
            currentAmountOfSupplies += totalSupplyIncrease;
        }
    }
    void PortProduction()
    {
        productionCooldown -= Time.deltaTime;
        if (portProductionLevel >= 1)
        {
            if (productionCooldown <= 0)
            {
                resourseCounter += portProductionLevel;
                productionCooldown = 60;
            }
        }
    }
    void DetectRegion()
    {
        Collider portCollider = GetComponent<Collider>();
        Region[] regions = FindObjectsOfType<Region>();

        foreach (Region region in regions)
        {
            Collider regionCollider = region.GetComponent<Collider>();

            if (regionCollider != null && portCollider.bounds.Intersects(regionCollider.bounds))
            {
                localRegion = region;
            }
        }
    }
    public void SetTradeRule(OperationType operationType, ProductType product)
    {
        _tradeRules[product] = operationType;
    }
}
