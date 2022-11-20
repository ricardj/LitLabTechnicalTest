using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoBattleRound : MonoBehaviour
{
    [SerializeField] List<AutoBattlePhase> _autoBattlePhase;

    public IEnumerator StartRoundSequence()
    {
        for (int i = 0; i < _autoBattlePhase.Count; i++)
        {
            AutoBattlePhase autoBattlePhase = _autoBattlePhase[i];
            yield return autoBattlePhase.StartCombatPhase();
        }

    }
}