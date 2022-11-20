using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[Serializable]
public class Instance<T> : IUniqueIdentified, IInstance<T>
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

public class IUniqueIdentified
{

    [SerializeField] string uid = "0";
    public string UID
    {
        get
        {
            if (uid == "0")
            {
                uid = Guid.NewGuid().ToString();
            }
            return uid;
        }
    }
}