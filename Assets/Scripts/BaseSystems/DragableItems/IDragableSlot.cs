using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.Events;

public class IDragableSlot : MonoBehaviour
{
    [Header("Debug configuration")]
    [SerializeField] Color _targetDebugColor = Color.red;
    [SerializeField] float _inventorySlotRadius = 2f;
    [SerializeField] protected float _slotSnapDistance = 4;

    [Header("Debug value")]
    [SerializeField] protected IDragableMonoBehaviour _currentDragable;

    [Header("Events")]
    public DragableMonoBehaviourEvent OnDragableItemPositioned;
    public DragableMonoBehaviourEvent OnDragableItemCleared;
    public DragableMonoBehaviourPairEvent OnDragableItemSwap;

    public void Setup(GameObject targetGameObject)
    {


    }

    public void Swap(IDragableMonoBehaviour targetDragable)
    {
        if (_currentDragable != null)
            OnDragableItemSwap.Invoke(_currentDragable, targetDragable);
        Clear();
        Setup(targetDragable);
    }

    public void Setup(IDragableMonoBehaviour dragableMonobehaviour)
    {
        _currentDragable = dragableMonobehaviour;
        OnDragableItemPositioned.Invoke(dragableMonobehaviour);
    }


    public void Clear()
    {
        OnDragableItemCleared.Invoke(_currentDragable);
        _currentDragable = null;
    }


    public bool IsFilled()
    {
        return _currentDragable != null;
    }

    public IDragableMonoBehaviour GetFill()
    {
        return _currentDragable;
    }

    public bool IsTargetInRange(Transform targetTransform)
    {
        return Vector3.Distance(targetTransform.position, transform.position) <= _slotSnapDistance;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = _targetDebugColor;
        Gizmos.DrawSphere(transform.position, _inventorySlotRadius);
        Gizmos.DrawWireSphere(transform.position, _slotSnapDistance);
    }
}
