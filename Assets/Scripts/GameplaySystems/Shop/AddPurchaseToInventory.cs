using UnityEngine.Events;

public class AddPurchaseToInventory : IAction<IShopPurchaseable>
{
    public InventoryCollectionSO inventoryCollection;

    public override void ExecuteAction(IShopPurchaseable data = null, UnityAction onFinish = null)
    {
        if (data is IInventoryItem)
        {
            IInventoryItem inventoryItem = (IInventoryItem)data;
            inventoryCollection.AddItem(inventoryItem);
        }
    }
}
