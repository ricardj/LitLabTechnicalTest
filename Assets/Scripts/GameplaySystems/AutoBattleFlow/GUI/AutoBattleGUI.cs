using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoBattleGUI : MonoBehaviour
{
    [SerializeField] AutoBattleGUICounter _counter;
    [SerializeField] AutoBattleGUIRounds _rounsdGUI;

    public void ShowPreparation()
    {

    }

    public void UpdateCounter(float time)
    {
        _counter.UpdateCounter(time.ToString("0."));
    }

    public void ShowFight()
    {
        _counter.UpdateCounter("FIGHT!");
    }

    public void SetRound(int round)
    {
        _rounsdGUI.ShowRound(round);
    }
}


