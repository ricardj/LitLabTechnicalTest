using System;
using UnityEngine;

public class InventorySlot : IDragableSlot
{
    [Header("Configuration")]

    public int inventorySlotId = 0;


    [Header("Debug values")]
    [SerializeField] IInventoryItem _currentInventoryItem;
    [SerializeField] GameObject _currentInventoryPrefabInstance;

    public void Start()
    {

    }



    public void Setup(IInventoryItem inventoryItem)
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

    public IInventoryItem GetCurrentInventoryItem()
    {
        return _currentInventoryItem;
    }
    protected override void OnClearSlot()
    {
        base.OnClearSlot();
        _currentInventoryPrefabInstance = null;
    }



}