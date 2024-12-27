using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneyManager : MonoBehaviour
{
    public int money = 500;

    public void SpendMoney(int amount)
    {
        if (money >= amount)
        {
            money -= amount;
        }
        else
        {
            Debug.Log("недостаточно монет!");
        }
    }

    public bool HasEnoughtMoney(int amount)
    {
        return money < amount;
    }

}