using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] ShopGUI _shopGUI;
    [SerializeField] ShopPurchaseableCollectionSO _purchaseablesCollection;
    [SerializeField] PlayerManager _playerManager;
    [SerializeField] AddPurchaseToInventory _addPurchaseToInventoryAction;

    [Header("Configuration")]
    public int _maxPurchaseablesInShop = 5;


    public void Start()
    {
        PopulateShop();

        _shopGUI.OnRefreshSelected.AddListener(() =>
        {
            PopulateShop();
        });

        _shopGUI.OnPurchaseableSelected.AddListener(newPurchaseable =>
        {
            ShopPurchaseRequirements shopPurchaseRequirements = newPurchaseable.GetPurchaseRequirements();
            List<ResourceAmount> costs = shopPurchaseRequirements.GetCosts();
            bool playerHasEnouhg = _playerManager.PlayerHasEnough(costs);
            if (playerHasEnouhg)
            {
                _playerManager.SubstractResource(costs);
                _addPurchaseToInventoryAction.ExecuteAction(newPurchaseable);
                _shopGUI.SetNewPurchaseable(newPurchaseable, _purchaseablesCollection.GetRandomItem());
            }

        });
    }

    public void PopulateShop()
    {
        List<IShopPurchaseable> shopPurchaseables = new List<IShopPurchaseable>();
        for (int i = 0; i < _maxPurchaseablesInShop; i++)
        {
            IShopPurchaseable purchaseable = _purchaseablesCollection.GetRandomItem();
            shopPurchaseables.Add(purchaseable);
        }
        _shopGUI.SetPurchaseables(shopPurchaseables);
    }

}
