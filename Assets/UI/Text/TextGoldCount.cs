

public class TextGoldCount : TextAbstract
{
    protected virtual void FixedUpdate()
    {
        this.LoadCount();
    }
    
    protected virtual void LoadCount()
    {
        ItemInventory item = InventoryManager.Instance.Monies().FindItem(ItemCode.Gold);
        string count;

        if (item == null) count = "0";
        else count = item.itemCount.ToString();
        
        this.textPro.text = count;
    }
    
}