using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // библиотека для использования 11 строки
using TMPro; //библиотека которая позволяет испоьзовать TextMeshProUGUI

public class GameManager : MonoBehaviour
{
    public int money = 1000; // количество монет

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
            moneyText.text = "Монеты" + money; // обновления текста с количеством монет 
        }
    }
}
