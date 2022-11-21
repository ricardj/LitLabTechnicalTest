using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICombatDamageable : MonoBehaviour, ITagged, IResourceBank
{
    [SerializeField] ResourceData _resourceData;
    [SerializeField] TaggedData _taggedData;


    public ResourceData GetResourceData()
    {
        return _resourceData;
    }

    public TaggedData GetTaggedData()
    {
        return _taggedData;
    }
}
