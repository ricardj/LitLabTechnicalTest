using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICombatDamageable : MonoBehaviour, ITagged, IResourceBank, ICombatCharacter
{
    [SerializeField] int _teamID = 0;
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

    public int GetTeamID()
    {
        return _teamID;
    }

    public void SetTeamID(int teamID)
    {
        this._teamID = teamID;
    }
}
