using Inventory;
using UnityEngine;

public class ItemsDropManager : SaiSingleton<ItemsDropManager>
{
    [SerializeField] protected ItemsDropSpawner spawner;
    public ItemsDropSpawner Spawn => spawner;

    float spawnHeight = 1.0f;//chieu cao de item spawn ra
    float forceAmount = 5.0f;//luc day len cac huong ngau nhien

    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
    }

    protected virtual void LoadSpawner()
    {
        if (spawner != null) return;
        this.spawner = GetComponent<ItemsDropSpawner>();
        
        Debug.Log(transform.name + " :LoadSpawner ",gameObject);
    }
    
    public virtual void DropMany(ItemCode itemCode, int dropCount, Vector3 dropPosition)//khi quai die se hien bn vang
    {
        for (int i = 0; i < dropCount; i++)
        {
            this.Drop(itemCode, 1, dropPosition);
        }
    }
    public virtual void Drop(ItemCode itemCode, int dropCount, Vector3 dropPosition)
    {
        Vector3 spawnPosition = dropPosition + new Vector3(Random.Range(-2,2), spawnHeight, Random.Range(-2, 2)); //vector huong de spawn
        ItemDropCtrl itemPrefabs = this.spawner.PoolPrefabs.GetByName(itemCode.ToString());
        if (itemPrefabs == null) itemPrefabs = this.spawner.PoolPrefabs.GetByName("DefaultDrop");
        
        ItemDropCtrl newItem = this.spawner.Spawn(itemPrefabs, spawnPosition);
        newItem.SetValue(itemCode, dropCount, InvCodeName.Currency);//gold vao monies
        
        newItem.gameObject.SetActive(true);
        
        Vector3 ramdomDirection  = Random.onUnitSphere;
        ramdomDirection.y = Mathf.Abs(ramdomDirection.y);
        newItem.Rigi.AddForce(ramdomDirection * forceAmount, ForceMode.Impulse);
    }
}
