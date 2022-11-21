using System;
using UnityEngine;
using UnityEngine.Events;

public class InventoryManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] InventoryCollectionSO _inventoryCollection;

    [Header("Debug values")]
    [SerializeField] InventoryController _inventoryController;


    public void OnEnable()
    {
        _inventoryCollection.OnCollectionUpdated.AddListener(UpdateInventory);
    }


    public void OnDisable()
    {
        _inventoryCollection.OnCollectionUpdated.RemoveListener(UpdateInventory);
    }

    public void UpdateInventory()
    {
        _inventoryController.Setup(_inventoryCollection.GetItems());
    }

    public void Start()
    {
        FetchInventory();
    }


    public void FetchInventory()
    {
        _inventoryController = FindObjectOfType<InventoryController>();
    }
}
