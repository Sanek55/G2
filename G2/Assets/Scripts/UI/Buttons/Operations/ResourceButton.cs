using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ResourceButton : MonoBehaviour
{
    public int ProductID;
    public PortBehaviour port;
    public bool isValueSet = false;
    public OperationType tradeRule = OperationType.NoValue;
    public bool isChoosed = false;
    Transform current;
    private void Awake()
    {
        Transform current = transform;
        for (int i = 0; i < 3; i++) 
        {
            if (current.parent != null)
            {
                current = current.parent;
            }
        }
        port = current.GetComponent<PortBehaviour>();
    }
    public void OnButtonClick()
    {
        if (tradeRule == port.currentOperation || tradeRule == OperationType.NoValue)
        {
            isChoosed = !isChoosed;

            if (isChoosed && !isValueSet)
            {
                tradeRule = port.currentOperation;
                port.SetTradeRule(port.currentOperation, (ProductType)ProductID);
            }
            else
            {
                // ��������� ��� ����������� ��������� ������
            }
        }
    }
}
