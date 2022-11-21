using System.Collections;
using UnityEngine;

public class PreparationBattlePhase : AutoBattlePhase
{
    [SerializeField] float _phaseDuration = 20f;

    [ReadOnly]
    [SerializeField] int _secondsCounter = 0;

    protected override IEnumerator AutoBattlePhaseSequence()
    {
        while (_secondsCounter < _phaseDuration)
        {
            _secondsCounter++;
            yield return new WaitForSeconds(1f);
        }
    }

    public override void SetupGUI(AutoBattleGUI autoBattleGUI)
    {
        StartCoroutine(PreparationPhaseSequence(autoBattleGUI));
    }

    IEnumerator PreparationPhaseSequence(AutoBattleGUI battleGUI)
    {
        battleGUI.ShowPreparation();
        while (this.IsPhaseActive())
        {
            battleGUI.UpdateCounter(_phaseDuration - _secondsCounter);
            yield return null;
        }
    }
}
