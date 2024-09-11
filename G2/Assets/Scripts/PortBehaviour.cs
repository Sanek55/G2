using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PortBehaviour : MonoBehaviour
{
    public bool isShipInPort = false; // ����� �������� �� ��� � �����������
    public int MaxAmountOfSupplies = 10;//�������� ��� ���������
    public int currentAmountOfSupplies = 1; // ����� �������� �� ��� ��� �������
    public int singleSupplyCost = 3;
    public int portSuppliesLevel = 1;
    private int totalSupplyIncrease = 0;
    private GameManager gameManager;
    void OnShipEntrance()
    {
       if (isShipInPort)
        {
            GetTotalSupplyAmount();
            int supplyIncreaseCost = singleSupplyCost * totalSupplyIncrease;
            if (supplyIncreaseCost < gameManager.money){gameManager.money -= supplyIncreaseCost;}
            else { Debug.Log("game over"); }
        }
    }
    public void GetTotalSupplyAmount() 
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
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
