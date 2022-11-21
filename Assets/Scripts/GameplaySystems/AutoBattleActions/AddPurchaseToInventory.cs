using UnityEngine.Events;

public class AddPurchaseToInventory : IAction<IShopPurchaseable>
{
    public InventoryCollectionSO inventoryCollection;

    public override void ExecuteAction(IShopPurchaseable data = null, UnityAction onFinish = null)
    {
        if (data is CharacterSO)
        {
            CharacterInstance newCharacterInstance = ((CharacterSO)data).GetInstance();
            IInventoryItem inventoryItem = (IInventoryItem)newCharacterInstance;
            inventoryCollection.AddItem(inventoryItem);
        }
    }
}
