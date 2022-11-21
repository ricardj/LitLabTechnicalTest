using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnEnemyTeam : IAction<VoidAction>
{
    [SerializeField] CharacterModelCollectionSO _usableEnemyModels;
    [SerializeField] CharacterInstanceCollectionSO _currentEnemiesCollection;
    [SerializeField] List<BattlefieldDragableSlot> _enemiesTargetSlots;

    [SerializeField] public int minEnemies = 4;
    [SerializeField] public int maxEnemies = 10;


    public override void ExecuteAction(VoidAction data = null, UnityAction onFinish = null)
    {
        _currentEnemiesCollection.Clear();
        int currentEnemies = Random.Range(minEnemies, maxEnemies);
        for (int i = 0; i < currentEnemies && i < _enemiesTargetSlots.Count; i++)
        {
            CharacterSO newCharacter = _usableEnemyModels.GetRandomItem();
            CharacterInstance newCharaccterInstance = newCharacter.GetInstance();
            GameObject newSpawnPrefab = newCharaccterInstance.GetSpawnPrefab();
            GameObject newSpawnPrefabInstance = Instantiate(newSpawnPrefab);
            IDragableMonoBehaviour dragableMonoBehaviour = newSpawnPrefabInstance.GetComponentInChildren<IDragableMonoBehaviour>();
            if (dragableMonoBehaviour != null)
            {
                BattlefieldDragableSlot randomSlot = _enemiesTargetSlots[Random.Range(0, _enemiesTargetSlots.Count)];
                dragableMonoBehaviour.SetupOnSlot(randomSlot);
                dragableMonoBehaviour.Deactivate();
            }
        }
    }
}
