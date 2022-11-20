using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class CollectionSO<T> : ScriptableObject, ICountable
{

    [Serializable]
    public class CollectionItemEvent : UnityEvent<T> { }


    //[SerializeReference]
    [SerializeField]
    List<T> _collectionList;

    [Header("Events")]
    public CollectionItemEvent OnItemAdded;
    public CollectionItemEvent OnItemRemoved;
    public UnityEvent OnCollectionUpdated;

    public List<T> CollectionList
    {
        get
        {
            CheckNullCollectionList();
            return _collectionList;
        }
        set
        {
            CheckNullCollectionList();
            _collectionList = value;
        }
    }


    private void CheckNullCollectionList()
    {
        if (_collectionList == null)
        {
            _collectionList = new List<T>();
        }
    }

    public void AddItem(T item)
    {
        CollectionList.Add(item);
        OnItemAdded.Invoke(item);
        OnCollectionUpdated.Invoke();
    }

    public void AddItem(List<T> inventorySlots)
    {
        CollectionList.AddRange(inventorySlots);
        OnCollectionUpdated.Invoke();
    }

    public void RemoveItem(T item)
    {
        CollectionList.Remove(item);
        OnItemRemoved.Invoke(item);
        OnCollectionUpdated.Invoke();
    }
    public List<T> GetItems()
    {
        return CollectionList;
    }

    public void Clear()
    {
        CollectionList.Clear();
    }

    public T GetRandomItem()
    {
        if (CollectionList.Count > 0)
        {
            return CollectionList[Random.Range(0, CollectionList.Count)];
        }
        return default(T);
    }

    public int GetCount()
    {
        return CollectionList.Count;
    }
}
