using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // ���������� ��� ������������� 11 ������
using TMPro; //���������� ������� ��������� ����������� TextMeshProUGUI

public class GameManager : MonoBehaviour
{
    public int money = 1000; // ���������� ����� |�� ����� ����������� ��� �� � �� ������) |��� ����� ������� ��� ����)

    public TextMeshProUGUI moneyText; 

   

    void Start()
    {
      
    }

   
    void Update()
    {
        UpdateMoneyText();
    }

    public void UpdateMoneyText()
    {
        if (moneyText != null)
        {
            moneyText.text = "������" + money; // ���������� ������ � ����������� ����� 
        }
    }
}
