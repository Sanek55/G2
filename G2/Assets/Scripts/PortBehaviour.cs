using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PortBehaviour : MonoBehaviour
{
    public bool isShipInPort = false; // Потом поменять на код с коллайдером
    public int MaxAmountOfSupplies = 10;//Значение дял изменения
    public int currentAmountOfSupplies = 1; // Потом поменять на код для корабля
    public int singleSupplyCost = 3;
    public int portSuppliesLevel = 1;
    private GameManager gameManager;
    void OnShipEntrance()
    {
       if (isShipInPort)
        {
            int totalSupplyCost = 0000;
           
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
