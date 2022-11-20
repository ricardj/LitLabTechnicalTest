using System;
using System.Collections;
using UnityEngine;

public class CombatBattlePhase : AutoBattlePhase
{
    [Header("Configuration")]
    [SerializeField] float _timeBetweenEnemySpawnAndCombatStart = 0.4f;

    [Header("Broadcasts into")]
    [SerializeField] EmptyEventSO _spawnEnemyTeam;
    [SerializeField] EmptyEventSO _startCombat;

    [Header("Listens to")]
    [SerializeField] EmptyEventSO _combatFinished;

    [Header("Debug values")]
    [SerializeField][ReadOnly] bool _isCombatFinished = false;

    public void OnEnable()
    {
        _combatFinished.AddListener(OnCombatFinished);
    }
    public void OnDisable()
    {
        _combatFinished.RemoveListener(OnCombatFinished);
    }

    private void OnCombatFinished()
    {
        _isCombatFinished = true;
    }

    public override IEnumerator StartCombatPhase()
    {
        _spawnEnemyTeam.RaiseEvent();
        yield return new WaitForSeconds(_timeBetweenEnemySpawnAndCombatStart);
        _startCombat.RaiseEvent();
        _isCombatFinished = false;
        yield return new WaitUntil(() => _isCombatFinished);
    }
}
