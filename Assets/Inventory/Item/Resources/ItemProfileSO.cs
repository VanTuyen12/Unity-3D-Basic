using Inventory;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "ItemProfile", menuName = "ScriptableObjects/ItemProfile", order = 1)]//tao ScriptableObjects
public class ItemProfileSO : ScriptableObject
{
    public InvCodeName invCodeName;
    public ItemCode itemCode;
    public string itemName;//ten vat pham
    public bool isStackable = false;//co gap chung dc hay k

   
}
