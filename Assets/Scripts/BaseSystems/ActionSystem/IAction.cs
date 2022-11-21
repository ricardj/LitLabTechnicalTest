using System;
using UnityEngine;
using UnityEngine.Events;
public abstract class IAction<T> : MonoBehaviour
{
    [SerializeField] bool _autoAction = true;
    [Header("Optional:")]
    [SerializeField] EmptyEventSO _eventTriggered;


    public void OnEnable()
    {
        if (_eventTriggered != null)
            _eventTriggered.AddListener(ExecuteVoidAction);
    }
    public void OnDisable()
    {
        if (_eventTriggered != null)
            _eventTriggered.RemoveListener(ExecuteVoidAction);
    }

    void Start()
    {
        if (_autoAction)
            ExecuteVoidAction();
    }
    public void ExecuteVoidAction()
    {
        ExecuteAction();
    }

    public abstract void ExecuteAction(T data = default(T), UnityAction onFinish = null);
}
