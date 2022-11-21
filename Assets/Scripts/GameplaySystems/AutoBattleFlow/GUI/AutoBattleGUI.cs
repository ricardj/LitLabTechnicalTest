using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoBattleGUI : MonoBehaviour
{
    [SerializeField] AutoBattleGUICounter _counter;

    public void ShowPreparation()
    {
        
    }

    public void UpdateCounter(float time)
    {
        _counter.UpdateCounter(time.ToString("0.") + "s");
    }

    public void ShowFight()
    {
        _counter.UpdateCounter("FIGHT!");
    }
}


