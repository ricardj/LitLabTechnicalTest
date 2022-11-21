using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoBattleRound : MonoBehaviour
{
    [SerializeField] List<AutoBattlePhase> _autoBattlePhase;
    public AutoBattlePhaseEvent OnAutoBattlePhaseStart;
    public void Awake()
    {
        _autoBattlePhase.ForEach(phase => phase.OnAutoBattlePhaseStart.AddListener(OnAutoBattlePhaseStart.Invoke));
    }

    public IEnumerator StartRoundSequence()
    {
        for (int i = 0; i < _autoBattlePhase.Count; i++)
        {
            AutoBattlePhase autoBattlePhase = _autoBattlePhase[i];
            yield return autoBattlePhase.StartAutoBattlePhase();
        }

    }
}