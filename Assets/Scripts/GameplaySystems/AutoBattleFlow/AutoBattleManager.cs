using System.Collections;
using UnityEngine;

public class AutoBattleManager : MonoBehaviour
{

    [SerializeField] AutoBattleRoundsManager _autoBattleRoundsManager;
    [SerializeField] AutoBattleGUI _autoBattleGUI;

    [ReadOnly]
    [SerializeField] AutoBattlePhase _currentPhase;

    public void Start()
    {
        _autoBattleRoundsManager.OnAutoBattlePhaseStart.AddListener(currentPhase =>
        {
            this._currentPhase = currentPhase;
            this._currentPhase.SetupGUI(_autoBattleGUI);
        });
        _autoBattleRoundsManager.OnRoundStart.AddListener(() =>
        {
            _autoBattleGUI.SetRound(_autoBattleRoundsManager.GetCurrentRound());
        });
    }


    public void StartAutoBattle()
    {
        StartCoroutine(StartAutoBattleSequence());
    }

    public IEnumerator StartAutoBattleSequence()
    {
        yield return _autoBattleRoundsManager.StartRoundsSequence();
    }

    public void Update()
    {
        //DEBUG STUFF
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartAutoBattle();
        }
    }

}
