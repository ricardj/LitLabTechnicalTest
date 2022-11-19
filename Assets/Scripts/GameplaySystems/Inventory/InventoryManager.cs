using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] InventoryCollectionSO _inventoryCollection;

    [Header("Debug values")]
    [SerializeField] InventoryController inventoryController;
    

    public void FetchInventory()
    {
        inventoryController = FindObjectOfType<InventoryController>();
    }
}
