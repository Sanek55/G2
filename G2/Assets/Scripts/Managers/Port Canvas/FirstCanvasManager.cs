using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject secondCanvasPrefab; // Префаб второго Canvas
    [SerializeField] private GameObject currentCanvas; // Ссылка на текущий Canvas
    [SerializeField] private int portCost = 100; // Стоимость постройки порта

    private MoneyManager moneyManager; // Ссылка на MoneyManager

    private void Start()
    {
        // Получаем ссылку на MoneyManager (предполагается, что он есть в сцене)
        moneyManager = FindObjectOfType<MoneyManager>();
    }

    public void OnBuildPort()
    {
        if (moneyManager.money >= portCost) // Проверяем количество денег в MoneyManager
        {
            // Списываем деньги
            moneyManager.money -= portCost;

            // Скрываем текущий Canvas
            currentCanvas.SetActive(false);

            // Спавним новый Canvas
            Instantiate(secondCanvasPrefab, transform.parent);

            // Удаляем первый Canvas
            Destroy(currentCanvas);
        }
        else
        {
            Debug.Log("Недостаточно денег!");
        }
    }

    public void OnExit()
    {
        // Скрыть Canvas
        currentCanvas.SetActive(false);
    }
}
