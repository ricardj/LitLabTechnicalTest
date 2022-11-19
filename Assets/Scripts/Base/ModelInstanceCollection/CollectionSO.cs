using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectionSO<T> : ScriptableObject
{

    [Serializable]
    public class CollectionItemEvent : UnityEvent<T> { }


    [SerializeReference] List<T> _collectionList;

    [Header("Events")]
    public CollectionItemEvent OnItemAdded;

    public void AddItem(T item)
    {
        _collectionList.Add(item);
        OnItemAdded.Invoke(item);
    }
    public List<T> GetItems()
    {
        return _collectionList;
    }

    public void Clear()
    {
        _collectionList.Clear();
    }

}
