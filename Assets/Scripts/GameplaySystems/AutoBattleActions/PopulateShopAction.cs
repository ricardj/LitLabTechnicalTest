using UnityEngine;
using UnityEngine.Events;

public class PopulateShopAction : MonoBehaviour, IAction
{
    [SerializeField] ShopPurchaseableCollectionSO _shopPurchaseables;
    [SerializeField] CharacterCollectionSO _shopableCharacters;

    public void ExecuteAction(UnityAction onFinish = null)
    {
        _shopPurchaseables.Clear();
        _shopableCharacters.GetItems().ForEach(character =>
        {
            _shopPurchaseables.AddItem(character);
        });
    }

}
