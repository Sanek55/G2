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
