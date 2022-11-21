using System;
using System.Collections;
using UnityEngine;

public abstract class AutoBattlePhase : MonoBehaviour
{
    public AutoBattlePhaseEvent OnAutoBattlePhaseStart;

    [ReadOnly][SerializeField] bool _isPhaseActive = false;
    public IEnumerator StartAutoBattlePhase()
    {
        _isPhaseActive = true;
        OnAutoBattlePhaseStart.Invoke(this);
        yield return null;
        yield return AutoBattlePhaseSequence();
        _isPhaseActive = false;
        yield return null;

    }

    public bool IsPhaseActive()
    {
        return _isPhaseActive;
    }

    protected abstract IEnumerator AutoBattlePhaseSequence();
    public abstract void SetupGUI(AutoBattleGUI autoBattleGUI);
}
