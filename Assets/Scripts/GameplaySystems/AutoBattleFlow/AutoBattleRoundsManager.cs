using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AutoBattleRoundsManager : MonoBehaviour
{

    [SerializeField] List<AutoBattleRound> _autoBattleRounds;

    [SerializeField] int _currentRound = 0;
    public AutoBattlePhaseEvent OnAutoBattlePhaseStart;
    public UnityEvent OnRoundStart;


    public void Awake()
    {
        _autoBattleRounds.ForEach(round => round.OnAutoBattlePhaseStart.AddListener(OnAutoBattlePhaseStart.Invoke));
    }

    public IEnumerator StartRoundsSequence()
    {
        for (int i = 0; i < _autoBattleRounds.Count; i++)
        {
            _currentRound = i + 1;
            OnRoundStart.Invoke();
            AutoBattleRound autoBattleRound = _autoBattleRounds[i];
            yield return autoBattleRound.StartRoundSequence();
        }
    }

  
    public int GetCurrentRound()
    {
        return _currentRound;
    }

    
}