using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PortBehaviour : MonoBehaviour
{
    public bool isShipInPort = false; // Потом поменять на код с коллайдером
    // Снабжение
    public int MaxAmountOfSupplies = 10;//Значение дял изменения
    public int currentAmountOfSupplies = 1; // Потом поменять на код для корабля
    public int singleSupplyCost = 3;
    public int portSuppliesLevel = 1;
    public int portProductionLevel = 0;
    private int totalSupplyIncrease = 0;
    // Производство
    public float productionCooldown = 60f;
    public int resourseCounter = 0; // Replace later

    private GameManager gameManager;
    private RoutesEditor routesEditor;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        routesEditor = FindObjectOfType<RoutesEditor>();
    }

    // Update is called once per frame
    void Update()
    {
        PortProduction();
        OnShipEntrance();
        //routesEditor.OnPortClick();



    }
    void OnShipEntrance()
    {
        if (isShipInPort)
        {
            GetTotalSupplyIncrease();
            int supplyIncreaseCost = singleSupplyCost * totalSupplyIncrease;
            if (supplyIncreaseCost < gameManager.money) { gameManager.money -= supplyIncreaseCost; }
            else { Debug.Log("game over"); }
        }
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
                resourseCounter +=portProductionLevel;
                productionCooldown = 60; 
            }
        }
    }
   
}
