using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] List<InventorySlot> _inventorySlots;

    public List<InventorySlot> InventorySlots { get => _inventorySlots; set => _inventorySlots = value; }


    public void Start()
    {
        _inventorySlots.ForEach(inventorySlot =>
        {
            inventorySlot.OnItemStopDragging.AddListener(currentDraggingItem =>
            {
                InventorySlot snapInventorySlot = _inventorySlots.Find(slot => slot.IsTargetInRange(currentDraggingItem.transform));

                if (snapInventorySlot != null)
                {
                    if (snapInventorySlot.IsFilled())
                    {

                        if (snapInventorySlot.GetFill() == currentDraggingItem)
                        {
                            inventorySlot.Clear();
                            inventorySlot.Setup(currentDraggingItem);
                        }
                        else
                        {
                            //swap places
                            inventorySlot.Clear();
                            inventorySlot.Setup(snapInventorySlot.GetFill());
                            snapInventorySlot.Clear();
                            snapInventorySlot.Setup(currentDraggingItem);
                        }
                    }
                    else
                    {
                        inventorySlot.Clear();
                        snapInventorySlot.Setup(currentDraggingItem);
                    }
                }
                else
                {
                    inventorySlot.Clear();
                }
            });

        });
    }



    public void Setup(List<IInventoryItem> inventoryItems)
    {
        for (int i = 0; i < inventoryItems.Count && i < inventoryItems.Count; i++)
        {
            InventorySlot currentSlot = InventorySlots[i];
            currentSlot.Setup(inventoryItems[i]);
        }
    }
}
