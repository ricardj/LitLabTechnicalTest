using System;
using UnityEngine;
using UnityEngine.Events;
public abstract class IAction<T> : MonoBehaviour
{
    [SerializeField] bool _autoAction = true;

    void Start()
    {
        if (_autoAction)
            ExecuteAction();
    }

    public abstract void ExecuteAction(T data = default(T), UnityAction onFinish = null);
}
