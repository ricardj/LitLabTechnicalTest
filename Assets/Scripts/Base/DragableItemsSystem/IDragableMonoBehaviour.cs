using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDragableMonoBehaviour : MonoBehaviour
{
    [Header("Drag parameters")]
    [SerializeField] LayerMask _raycastLayerMask;
    [Header("Debug values")]
    [SerializeField] Camera _mainCamera;
    //[SerializeField] Vector3 _originalPosition;
    [SerializeField] bool _objectSelected = false;

    [Header("Events")]
    public DragableMonoBehaviourEvent OnStartDragging;
    public DragableMonoBehaviourEvent OnStopDragging;

    void OnMouseDown()
    {
        SelectObject();
    }

    private void SelectObject()
    {
        //_originalPosition = transform.position;
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
        //transform.position = _originalPosition;
        OnStopDragging.Invoke(this);
    }
}


