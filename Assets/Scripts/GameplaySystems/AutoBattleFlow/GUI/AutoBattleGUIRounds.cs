using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AutoBattleGUIRounds : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _autoBattleGUIRounds;

    public void ShowRound(int round)
    {
        _autoBattleGUIRounds.text = string.Format("Round {0}", round);
    }

}
