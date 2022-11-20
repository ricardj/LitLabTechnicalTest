using UnityEngine;

public class CombatDamageableCollectionManager : MonoBehaviour
{
    [SerializeField] CombatDamageableCollectionSO _combatDamageableCollection;
    public void Awake()
    {
        _combatDamageableCollection.Clear();
    }
}