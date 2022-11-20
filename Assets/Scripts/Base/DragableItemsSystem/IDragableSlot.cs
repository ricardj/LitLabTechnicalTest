using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.Events;

public class IDragableSlot : MonoBehaviour
{
    [SerializeField] protected IDragableMonoBehaviour _currentDragable;
    [SerializeField] protected float _slotSnapDistance = 4;

    [Header("Events")]
    public DragableMonoBehaviourEvent OnItemStartDragging;
    public DragableMonoBehaviourEvent OnItemStopDragging;

    public void Setup(GameObject targetGameObject)
    {
        
        IDragableMonoBehaviour dragableMonoBehaviour = targetGameObject.GetComponentInChildren<IDragableMonoBehaviour>();
        if (dragableMonoBehaviour != null)
            Setup(dragableMonoBehaviour);
    }

    public void Setup(IDragableMonoBehaviour dragableMonobehaviour)
    {
        _currentDragable = dragableMonobehaviour;
        _currentDragable.OnStartDragging.AddListener(OnStartDragging);
        _currentDragable.OnStopDragging.AddListener(OnStopDragging);
        SetToPosition(dragableMonobehaviour);
    }

    private void SetToPosition(IDragableMonoBehaviour dragableMonobehaviour)
    {

        //dragableMonobehaviour.transform.position = transform.position;
        dragableMonobehaviour.transform.DOMove(transform.position, 0.3f);
    }

    public void Clear()
    {
        _currentDragable.OnStartDragging.RemoveListener(OnStartDragging);
        _currentDragable.OnStopDragging.RemoveListener(OnStopDragging);
        _currentDragable = null;
    }
    private void OnStopDragging(IDragableMonoBehaviour dragableMonoBehaviour)
    {
        OnItemStartDragging.Invoke(dragableMonoBehaviour);
    }

    private void OnStartDragging(IDragableMonoBehaviour dragableMonoBehaviour)
    {
        OnItemStopDragging.Invoke(dragableMonoBehaviour);
    }

    public bool IsFilled()
    {
        return _currentDragable != null;
    }

    public IDragableMonoBehaviour GetFill()
    {
        return _currentDragable;
    }


}