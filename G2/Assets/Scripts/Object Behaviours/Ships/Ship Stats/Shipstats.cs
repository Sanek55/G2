using UnityEngine;

[CreateAssetMenu(fileName = "New Ship Stats", menuName = "Ship Stats")]
public class ShipStats : ScriptableObject
{
    public string Name;
    public int shipType;
    public int LoadCapacity;
    public int Price;
    public float Speed;
    public float SupplyAmount;
}
