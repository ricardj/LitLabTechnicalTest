using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public int inventorySlotId = 0;

    [SerializeField] float _inventorySlotRadius = 2f;

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, _inventorySlotRadius);
    }

}