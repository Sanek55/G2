using Dreamteck.Splines;
using Unity.VisualScripting;
using UnityEngine;

public enum ProductType { Gold, Iron, Weapons, Fur, Dyes, Opium, Porcelain, Silk, Spices }
public enum OperationType { Sell, Unload, Load }
public class PortBehaviour : MonoBehaviour
{
    //�������� �����
    public string portName;
    public int portID;
    // Temporary 
    public bool isShipInPort = false; // ����� �������� �� ��� � �����������
    // ���������
    public int MaxAmountOfSupplies = 10;//�������� ��� ���������
    public int currentAmountOfSupplies = 1; // ����� �������� �� ��� ��� �������
    public int singleSupplyCost = 3;
    public int portSuppliesLevel = 1;
    public int portProductionLevel = 0;
    private int totalSupplyIncrease = 0;
    // ������������
    public float productionCooldown = 60f;
    public int resourseCounter = 0; // Replace later
    // Operations
    public bool[] operationsChoosed = new bool[3]; // 1 - Sell, 2 - Unload, 3 - Load.
    public bool[] productsTypesToSell = new bool[7];
    public bool[] productsTypesToUnload = new bool[7];
    public bool[] productsTypesToLoad = new bool[7];
    private GameManager gameManager;
    //public GameObject splineManager;
    private LineManager routesEditorManager; // = new RoutesEditor();

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        DetectRegion();
    }

    void Update()
    {
        PortProduction();
        OnShipEntrance();
       
        //routesEditorManager.OnPortClickEditorMode();



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
                resourseCounter += portProductionLevel;
                productionCooldown = 60;
            }
        }
    }
    void DetectRegion()
    {
        Collider portCollider = GetComponent<Collider>();
        Region[] regions = FindObjectsOfType<Region>();

        foreach (Region region in regions)
        {
            Collider regionCollider = region.GetComponent<Collider>();

            if (regionCollider != null && portCollider.bounds.Intersects(regionCollider.bounds))
            {
                localRegion = region;
            }
        }
    }
}
