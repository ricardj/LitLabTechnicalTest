using UnityEngine;
using UnityEngine.Events;

public class RestartInventory : IAction<VoidAction>
{

    [SerializeField] InventoryManager _inventoryManager;

    public override void ExecuteAction(VoidAction data = null, UnityAction onFinish = null)
    {
        _inventoryManager.UpdateInventory();
    }
}