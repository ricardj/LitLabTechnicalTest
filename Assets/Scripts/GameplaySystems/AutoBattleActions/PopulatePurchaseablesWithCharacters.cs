using UnityEngine;
using UnityEngine.Events;

public class PopulatePurchaseablesWithCharacters : IAction<VoidAction>
{
    [SerializeField] CharacterModelCollectionSO _characterCollection;
    [SerializeField] ShopPurchaseableCollectionSO _shopPurchaseables;

    public override void ExecuteAction(VoidAction data = null, UnityAction onFinish = null)
    {
        _shopPurchaseables.Clear();
        _characterCollection.GetItems().ForEach(character =>
        {
            _shopPurchaseables.AddItem(character);
        });
    }
}
