using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDragableMonoBehaviour : MonoBehaviour
{
    [Header("Drag parameters")]
    [SerializeField] LayerMask _raycastLayerMask;
    [SerializeField] DragableSlotsCollectionSO _targetSlots;

    [Header("Debug values")]
    [SerializeField][ReadOnly] Camera _mainCamera;
    [SerializeField][ReadOnly] bool _objectSelected = false;
    [SerializeField][ReadOnly] IDragableSlot _currentDragableSlot;
    [SerializeField][ReadOnly] IDragableSlot _lastDragableSlot;
    [SerializeField][ReadOnly] bool _isDraggingEnabled = true;

    [Header("Events")]
    public DragableMonoBehaviourEvent OnStartDragging;
    public DragableMonoBehaviourEvent OnStopDragging;

    void OnMouseDown()
    {
        if (_isDraggingEnabled)
            SelectObject();
    }

    private void SelectObject()
    {
        //_originalPosition = transform.position;
        if (_currentDragableSlot != null)
        {
            _lastDragableSlot = _currentDragableSlot;
            _currentDragableSlot.Clear();
            _currentDragableSlot = null;
        }
        _objectSelected = true;
        OnStartDragging.Invoke(this);
    }

    public void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (_objectSelected)
            {
                UnselectObject();
            }
        }

        if (_objectSelected)
        {
            DragObject();
        }
    }

    private void DragObject()
    {
        if (_mainCamera == null)
        {
            _mainCamera = Camera.main;
        }
        Vector3 mousePOsition = Input.mousePosition;
        mousePOsition.z = 10;
        Ray newRay = _mainCamera.ScreenPointToRay(mousePOsition);
        RaycastHit hit;
        if (Physics.Raycast(newRay, out hit, 100f, _raycastLayerMask))
        {
            transform.position = hit.point;
        }
    }

    private void UnselectObject()
    {
        _objectSelected = false;

        IDragableSlot dragableSlot = _targetSlots.GetItems().Find(targetSlot => targetSlot.IsTargetInRange(transform));
        SetupOnSlot(dragableSlot);


        //transform.position = _originalPosition;
        OnStopDragging.Invoke(this);
    }

    public void SetupOnSlot(IDragableSlot dragableSlot)
    {
        if (dragableSlot != null)
        {
            if (dragableSlot.IsFilled())
            {
                dragableSlot.Swap(this);
            }
            else
            {
                dragableSlot.Setup(this);
            }
        }
        _currentDragableSlot = dragableSlot;

        SetupCurrentSlotPosition();
    }

    private void SetupCurrentSlotPosition()
    {
        if (_currentDragableSlot != null)
            transform.DOMove(_currentDragableSlot.transform.position, 0.3f);
    }

    public IDragableSlot GetLastDragableSlot()
    {
        return _lastDragableSlot;
    }
    public IDragableSlot GetCurrentDragableSlot()
    {
        return _currentDragableSlot;
    }

    public void Deactivate()
    {
        _isDraggingEnabled = false;
    }

    public void Activate()
    {
        _isDraggingEnabled = true;
    }
}


