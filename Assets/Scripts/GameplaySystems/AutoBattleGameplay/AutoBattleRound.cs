using System;
using System.Collections;
using UnityEngine;

public class AutoBattleRound : MonoBehaviour
{
    public AutoBattlePhase preparationPhase;
    public AutoBattlePhase combatPhase;

    public IEnumerator StartRoundSequence()
    {
        yield return preparationPhase.StartCombatPhase();
        yield return combatPhase.StartCombatPhase();
    }
}