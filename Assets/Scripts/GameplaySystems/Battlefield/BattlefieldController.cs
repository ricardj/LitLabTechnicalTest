using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattlefieldController : MonoBehaviour
{
    [SerializeField] List<BattlefieldDragableSlot> _battlefieldDragableSlots;
    [SerializeField] DragableSlotsCollectionSO _dragableSlots;

    public void Start()
    {
        _dragableSlots.Add(_battlefieldDragableSlots.OfType<IDragableSlot>().ToList());
    }
}