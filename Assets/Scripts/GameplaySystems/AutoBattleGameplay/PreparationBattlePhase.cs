using System.Collections;
using UnityEngine;

public class PreparationBattlePhase : AutoBattlePhase
{
    [SerializeField] float _phaseDuration = 20f;

    public override IEnumerator StartCombatPhase()
    {
        yield return new WaitForSeconds(_phaseDuration);
    }
}
