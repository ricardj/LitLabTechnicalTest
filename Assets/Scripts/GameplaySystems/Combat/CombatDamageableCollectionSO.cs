using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "CyberMonsters/New Combat Damageable Collection")]
public class CombatDamageableCollectionSO : CollectionSO<ICombatDamageable>
{
    public ICombatDamageable GetRandomItemFromDifferentTeam(ICombatCharacter combatAttacker)
    {
        List<ICombatDamageable> combatDamageables = GetItems().FindAll(damageable => damageable.GetTeamID() != combatAttacker.GetTeamID());

        if (combatDamageables.Count > 0)
        {
            return combatDamageables[Random.Range(0, combatDamageables.Count)];
        }

        return null;
    }
}
