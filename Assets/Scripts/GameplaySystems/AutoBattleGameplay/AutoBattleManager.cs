using System.Collections;
using UnityEngine;

public class AutoBattleManager : MonoBehaviour
{

    [SerializeField] AutoBattleRoundsManager _autoBattleRoundsManager;



    public void StartBattle()
    {
        StartCoroutine(StartBattleSequence());
    }

    public IEnumerator StartBattleSequence()
    {
        yield return _autoBattleRoundsManager.StartRoundsSequence();
       
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartBattle();
        }
    }

}
