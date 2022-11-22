using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        for (int i = 0; i <= currentEnemies && i < _enemiesTargetSlots.Count; i++)
        {
            CharacterSO newCharacter = _usableEnemyModels.GetRandomItem();
            CharacterInstance newCharaccterInstance = newCharacter.GetInstance();
            _currentEnemiesCollection.AddItem(newCharaccterInstance);
            GameObject newSpawnPrefab = newCharaccterInstance.GetSpawnPrefab();
            GameObject newSpawnPrefabInstance = Instantiate(newSpawnPrefab);

            PutIntoBattlefield(newSpawnPrefabInstance);

            ConfigureAsCombatEnemy(newSpawnPrefabInstance);
        }
    }

    private static void ConfigureAsCombatEnemy(GameObject newSpawnPrefabInstance)
    {
        //Configure as enemy team pieces
        List<ICombatCharacter> combatCharacters = newSpawnPrefabInstance.GetComponentsInChildren<ICombatCharacter>().ToList();
        combatCharacters.ForEach(combatCharacter => combatCharacter.SetTeamID(1));
    }

    private void PutIntoBattlefield(GameObject newSpawnPrefabInstance)
    {
        //Put into the battlefield
        IDragableMonoBehaviour dragableMonoBehaviour = newSpawnPrefabInstance.GetComponentInChildren<IDragableMonoBehaviour>();
        if (dragableMonoBehaviour != null)
        {
            List<BattlefieldDragableSlot> notFilledDragableSlots = _enemiesTargetSlots.FindAll(slot => !slot.IsFilled());
            if (notFilledDragableSlots.Count > 0)
            {

                BattlefieldDragableSlot randomSlot = notFilledDragableSlots[Random.Range(0, notFilledDragableSlots.Count)];
                dragableMonoBehaviour.SetupOnSlot(randomSlot);
                dragableMonoBehaviour.Deactivate();
            }
        }
    }
}
