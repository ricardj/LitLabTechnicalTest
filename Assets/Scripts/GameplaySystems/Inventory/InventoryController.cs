using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] List<InventorySlot> _inventorySlots;
    [SerializeField] DragableSlotsCollectionSO _runtimeDragableSlotsCollection;

    public List<InventorySlot> InventorySlots { get => _inventorySlots; set => _inventorySlots = value; }


    public void Start()
    {
        UpdateInventoryCollection();
        ConfigureSlotReordering();
    }

    private void UpdateInventoryCollection()
    {
        _runtimeDragableSlotsCollection.AddItem(_inventorySlots.OfType<IDragableSlot>().ToList());
    }

    private void ConfigureSlotReordering()
    {
        _inventorySlots.ForEach(inventorySlot =>
        {
            inventorySlot.OnDragableItemSwap.AddListener((oldItem, newItem) =>
            {
                IDragableSlot lastDragableSlot = newItem.GetLastDragableSlot();
                if (lastDragableSlot != null)
                {
                    oldItem.SetupOnSlot(lastDragableSlot);

                }
                else
                {
                    IDragableSlot emptySlot = FindEmptySlot();
                    if (emptySlot != null)
                    {
                        oldItem.SetupOnSlot(emptySlot);
                    }

                }
            });

        });
    }



    public void Setup(List<IInventoryItem> inventoryItems)
    {
        inventoryItems.ForEach(inventoryItem =>
        {
            InventorySlot oldInventorySlot = InventorySlots.Find(slot => slot.GetCurrentInventoryItem() == inventoryItem);
            if (oldInventorySlot == null)
            {
                InventorySlot emptyInventorySlot = FindEmptySlot();
                if (emptyInventorySlot != null)
                {
                    emptyInventorySlot.Setup(inventoryItem);
                }
            }
            else
            {
                if (!oldInventorySlot.IsFilled())
                {
                    oldInventorySlot.Setup(inventoryItem);
                }
            }
        });

        //for (int i = 0; i < inventoryItems.Count && i < inventoryItems.Count; i++)
        //{
        //    InventorySlot currentSlot = InventorySlots[i];
        //    currentSlot.Setup(inventoryItems[i]);
        //}
    }

    private InventorySlot FindEmptySlot()
    {
        return _inventorySlots.Find(inventorySlot => !inventorySlot.IsFilled());
    }
}
