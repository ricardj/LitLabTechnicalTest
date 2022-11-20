using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoBattleRoundsManager : MonoBehaviour
{
    [SerializeField] List<AutoBattleRound> _autoBattleRounds;

    public IEnumerator StartRoundsSequence()
    {
        for (int i = 0; i < _autoBattleRounds.Count; i++)
        {
            AutoBattleRound autoBattleRound = _autoBattleRounds[i];
            yield return autoBattleRound.StartRoundSequence();
        }
    }
}