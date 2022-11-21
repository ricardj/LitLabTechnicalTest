using System.Collections;
using UnityEngine;

public abstract class AutoBattlePhase : MonoBehaviour
{
    public abstract IEnumerator StartCombatPhase();
}
