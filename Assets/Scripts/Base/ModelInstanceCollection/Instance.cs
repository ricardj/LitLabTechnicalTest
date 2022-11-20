using System;
using UnityEngine;

[Serializable]
public class Instance<T> : IInstance<T>
{

    [SerializeField] T _model;

    public Instance()
    {

    }

    public Instance(T model)
    {
        _model = model;
    }

    public T GetModel()
    {
        return _model;
    }

    public void SetModel(T model)
    {
        this._model = model;
    }
}