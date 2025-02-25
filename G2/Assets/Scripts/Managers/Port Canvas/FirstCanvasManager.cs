using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject secondCanvasPrefab; // ������ ������� Canvas
    [SerializeField] private GameObject currentCanvas; // ������ �� ������� Canvas
    [SerializeField] private int portCost = 100; // ��������� ��������� �����

    private MoneyManager moneyManager; // ������ �� MoneyManager

    private void Start()
    {
        // �������� ������ �� MoneyManager (��������������, ��� �� ���� � �����)
        moneyManager = FindObjectOfType<MoneyManager>();
    }

    public void OnBuildPort()
    {
        if (moneyManager.money >= portCost) // ��������� ���������� ����� � MoneyManager
        {
            // ��������� ������
            moneyManager.money -= portCost;

            // �������� ������� Canvas
            currentCanvas.SetActive(false);

            // ������� ����� Canvas
            Instantiate(secondCanvasPrefab, transform.parent);

            // ������� ������ Canvas
            Destroy(currentCanvas);
        }
        else
        {
            Debug.Log("������������ �����!");
        }
    }

    public void OnExit()
    {
        // ������ Canvas
        currentCanvas.SetActive(false);
    }
}
