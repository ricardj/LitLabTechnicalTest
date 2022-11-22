using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattlefieldController : MonoBehaviour
{
    [SerializeField] List<BattlefieldDragableSlot> _battlefieldDragableSlots;
    [SerializeField] DragableSlotsCollectionSO _dragableSlots;
    [SerializeField] CombatDamageableCollectionSO _combatDamageables;
    [SerializeField] CombatAttackerCollectionSO _combatAttackers;

    public void Start()
    {
        ClearCombatCollections();

        _dragableSlots.AddItem(_battlefieldDragableSlots.OfType<IDragableSlot>().ToList());

        _battlefieldDragableSlots.ForEach(slot =>
        {
            slot.OnDragableItemPositioned.AddListener(dragableAdded =>
            {
                AddToCombatCollections(dragableAdded);

            });
            slot.OnDragableItemCleared.AddListener(dragableRemoved =>
            {
                RemoveFromCombatCollections(dragableRemoved);
            });
        });
    }

    private void ClearCombatCollections()
    {
        _combatAttackers.Clear();
        _combatAttackers.Clear();
    }

    private void RemoveFromCombatCollections(IDragableMonoBehaviour dragableRemoved)
    {
        ICombatDamageable damageable = dragableRemoved.GetComponentInChildren<ICombatDamageable>();
        if (damageable != null)
        {
            _combatDamageables.RemoveItem(damageable);
        }

        ICombatAttacker attacker = dragableRemoved.GetComponentInChildren<ICombatAttacker>();
        if (attacker != null)
        {
            _combatAttackers.RemoveItem(attacker);
        }
    }

    private void AddToCombatCollections(IDragableMonoBehaviour dragableAdded)
    {
        ICombatDamageable damageable = dragableAdded.GetComponentInChildren<ICombatDamageable>();
        if (damageable != null)
            _combatDamageables.AddItem(damageable);

        ICombatAttacker attacker = dragableAdded.GetComponentInChildren<ICombatAttacker>();
        if (attacker != null)
        {
            _combatAttackers.AddItem(attacker);
        }
    }
}