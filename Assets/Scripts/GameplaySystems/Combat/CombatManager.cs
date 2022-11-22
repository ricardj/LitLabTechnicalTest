using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class CombatManager : MonoBehaviour
{

    [SerializeField] CombatDamageableCollectionSO _combatDamageables;
    [SerializeField] CombatAttackerCollectionSO _combatAttackers;
    [SerializeField] AuttoBattleGUICombat _autoBattleGUICombat;

    [Header("Configuration")]
    [SerializeField][Range(0f, 1f)] float _playerWinProbability = 0.7f;


    [Header("Broadcasts into")]
    public EmptyEventSO OnCombatFinished;
    [Header("Listens to")]
    public EmptyEventSO OnStartCombat;
    [Header("More events")]
    public UnityEvent OnCombatWin;
    public UnityEvent OnCombatLoose;

    public void OnEnable()
    {
        OnStartCombat.AddListener(StartCombat);
    }
    public void OnDisable()
    {
        OnStartCombat.RemoveListener(StartCombat);
    }

    private void StartCombat()
    {
        StartCoroutine(StartCombatSequence());
    }

    IEnumerator StartCombatSequence()
    {
        _combatAttackers.GetItems().ForEach(combatAttacker => combatAttacker.AttackRandomTarget(_combatDamageables));
        
        yield return new WaitForSeconds(1f);
        
        CheckWinLoose();
        
        ClearCombatCharacters();
        OnCombatFinished.RaiseEvent();
    }

    private void CheckWinLoose()
    {
        bool isPlayerWin = Random.value <= _playerWinProbability;
        if (isPlayerWin)
        {
            _autoBattleGUICombat.ShowWin();
            OnCombatWin.Invoke();
        }
        else
        {
            _autoBattleGUICombat.ShowLoose();
            OnCombatLoose.Invoke();
        }
    }

    public void ClearCombatCharacters()
    {
        //We are destroying everyone
        _combatDamageables.GetItems().ForEach(item => Destroy(item.gameObject));
        _combatAttackers.GetItems().ForEach(item => Destroy(item.gameObject));
        _combatDamageables.Clear();
        _combatAttackers.Clear();
    }
}
