using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattlefieldController : MonoBehaviour
{
    [SerializeField] List<BattlefieldDragableSlot> _battlefieldDragableSlots;
    [SerializeField] DragableSlotsCollectionSO _dragableSlots;
    [SerializeField] CombatDamageableCollectionSO _combatDamageables;

    public void Start()
    {
        _dragableSlots.AddItem(_battlefieldDragableSlots.OfType<IDragableSlot>().ToList());

        _battlefieldDragableSlots.ForEach(slot =>
        {
            slot.OnDragableItemPositioned.AddListener(dragableAdded =>
            {
                ICombatDamageable damageable = dragableAdded.GetComponentInChildren<ICombatDamageable>();
                if (damageable != null)
                    _combatDamageables.AddItem(damageable);
            });
            slot.OnDragableItemCleared.AddListener(dragableRemoved =>
            {
                ICombatDamageable damageable = dragableRemoved.GetComponentInChildren<ICombatDamageable>();
                if (damageable != null)
                {
                    _combatDamageables.RemoveItem(damageable);
                }
            });
        });
    }
}