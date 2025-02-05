using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Operations : MonoBehaviour
{
    public Ship ship;
    public PortBehaviour PortBehaviour;
    public float[] localprices;
    private void Awake()
    {
       ship = GetComponent<Ship>();
       PortBehaviour = ship.portBehaviour;
    }
    public void Sell()
    {
        localprices = ship.portBehaviour.localRegion.prices;
        List<ProductType> products = ship.GetFittingProduct(OperationType.Sell);
        foreach (ProductType product in products)
        {
            ship._cargoHold[product] = 0;
        }
    }
    public void Load()
    {
        
        localprices = ship.portBehaviour.localRegion.prices;
        List<ProductType> products = ship.GetFittingProduct(OperationType.Load);
        foreach (ProductType product in products)
        {
            if(ship.portBehaviour._warehouse.ContainsKey(product) && ship.IsCargoLoadable())
            {
                int availableAmount = ship.portBehaviour._warehouse[product];
                int availableSpace = ship.stats.loadCapacity - ship.GetCurrentLoad();
                for (int i = 0; i < availableSpace; i++)
                {
                    if (availableAmount > 0)
                    {
                        ship._cargoHold[product]++;
                        ship.portBehaviour._warehouse[product]--;
                    }
                    else
                    {
                        ship._cargoHold[product]++; // change to moneyManagerInteraction
                    }
                }
            }
        }
    }
    public void Unload()
    {
        localprices = ship.portBehaviour.localRegion.prices;
        List<ProductType> products = ship.GetFittingProduct(OperationType.Unload);
        foreach (ProductType product in products)
        {
            if (ship._cargoHold.ContainsKey(product))
            {
                int availableAmount = ship._cargoHold[product];
                if (availableAmount > 0)
                {
                    ship.portBehaviour._warehouse[product] += availableAmount;
                    ship._cargoHold[product] = 0; 
                }
            }
        }
    }
}
