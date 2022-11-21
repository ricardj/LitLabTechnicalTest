using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CombatManager : MonoBehaviour
{

    [SerializeField] CombatDamageableCollectionSO _combatDamageables;
    [SerializeField] CombatAttackerCollectionSO _combatAttackers;

    [Header("Configuration")]
    [SerializeField][Range(0f, 1f)] float _playerWinProbability = 0.7f;


    [Header("Broadcasts into")]
    public EmptyEventSO OnCombatFinished;
    [Header("Listens to")]
    public EmptyEventSO OnStartCombat;

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
        bool isPlayerWin = Random.value <= _playerWinProbability;
        yield return null;
        ClearCombatCharacters();
        OnCombatFinished.RaiseEvent();
    }

    public void ClearCombatCharacters()
    {
        //We are destroying everyone
        _combatDamageables.GetItems().ForEach(item => Destroy(item.gameObject));
        _combatDamageables.Clear();
        _combatAttackers.Clear();
    }
}
