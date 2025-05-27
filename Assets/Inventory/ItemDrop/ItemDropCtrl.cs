using Inventory;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody))]
public class ItemDropCtrl : PoolObj
{
    [SerializeField]protected Rigidbody _rigi;
    public Rigidbody Rigidbody => _rigi;
    
    [SerializeField]protected ItemCode itemCode;
    public ItemCode ItemCode => itemCode;
    
    [SerializeField]protected int itemCount = 1;
    public int ItemCount => itemCount;
    public override string GetName()
    {
        return "ItemDrop";
    }

    public virtual void SetValue(ItemCode itemCode, int itemCount)
    {
        this.itemCode = itemCode;
        this.itemCount = itemCount;
    }
    
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigidbody();
       
    }

    protected virtual void LoadRigidbody()
    {
        if(this._rigi != null) return;
        this._rigi = this.GetComponent<Rigidbody>();
        Debug.Log(transform.name + " :LoadRigidbody",gameObject);
    }
}
