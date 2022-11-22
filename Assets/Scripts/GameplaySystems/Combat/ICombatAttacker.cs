using DG.Tweening;
using System;
using UnityEngine;

public class ICombatAttacker : MonoBehaviour, ITagged, IResourceBank, ICombatCharacter
{
    [SerializeField] int _teamID = 0;
    [SerializeField] ResourceData _resourceData;
    [SerializeField] TaggedData _taggedData;
    [SerializeField] CombatDamageableCollectionSO _combatDamageables;


    public ResourceData GetResourceData()
    {
        return _resourceData;
    }

    public TaggedData GetTaggedData()
    {
        return _taggedData;
    }

    public void AttackRandomTarget(CombatDamageableCollectionSO _combatDamageables)
    {
        ICombatDamageable combatDamageable = _combatDamageables.GetRandomItemFromDifferentTeam(this);
        if (combatDamageable != null)
        {
            AttackTarget(combatDamageable);
        }
    }

    public void AttackTarget(ICombatDamageable combatDamageable)
    {
        //Simple trick to make them find themselves in the middle
        Vector3 direction = (combatDamageable.transform.position - transform.position)/2f;
        transform.DOJump(transform.position + direction, 1, 1, 1f).SetEase(Ease.Linear);
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
