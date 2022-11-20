using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

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

    public T GetRandomItem()
    {
        if (_collectionList.Count > 0)
        {
            return _collectionList[Random.Range(0, _collectionList.Count)];
        }
        return default(T);
    }

}
