using System;
using UnityEngine;

public class InventorySlot : IDragableSlot
{
    [Header("Configuration")]

    public int inventorySlotId = 0;


    [Header("Debug values")]
    [SerializeField] IInventoryItem _currentInventoryItem;
    [SerializeField] GameObject _currentInventoryPrefabInstance;


 

    public void Setup(IInventoryItem inventoryItem)
    {
        if (this._currentInventoryItem != inventoryItem)
        {
            if (_currentInventoryPrefabInstance != null)
            {
                Destroy(_currentInventoryPrefabInstance.gameObject);
            }

            this._currentInventoryItem = inventoryItem;
            GameObject dragablePrefab = inventoryItem.GetSpawnPrefab();
            GameObject newInstance = Instantiate(dragablePrefab);
            _currentInventoryPrefabInstance = newInstance;
            IDragableMonoBehaviour dragableMonoBehaviour = _currentInventoryPrefabInstance.GetComponentInChildren<IDragableMonoBehaviour>();
            if (dragableMonoBehaviour != null)
            {
                dragableMonoBehaviour.SetupOnSlot(this);
            }


        }

    }




}