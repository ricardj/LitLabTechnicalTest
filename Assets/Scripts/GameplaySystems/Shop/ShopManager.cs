using System;
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
    [SerializeField] int _maxPurchaseablesInShop = 5;
    [SerializeField] ResourceAmount _refreshCost;
    [SerializeField] ResourceAmount _upgradeCost;



    public void Start()
    {
        PopulateShop();

        _shopGUI.OnRefreshSelected.AddListener(() =>
        {
            TryPopulateShop();
        });

        _shopGUI.OnPurchaseableSelected.AddListener(newPurchaseable =>
        {
            TryPurchase(newPurchaseable);
        });

        _shopGUI.OnUpgradeSelected.AddListener(() =>
        {
            TryUpgrade();
        });
    }



    private void TryPurchase(IShopPurchaseable newPurchaseable)
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
    }

    private void TryUpgrade()
    {
        bool playerHasEnough = _playerManager.PlayerHasEnough(_upgradeCost);
        if (playerHasEnough)
        {
            _playerManager.SubstractResource(_upgradeCost);
            _playerManager.UpgradeLevel();
        }
    }


    public void TryPopulateShop()
    {
        bool playerHasEnough = _playerManager.PlayerHasEnough(_refreshCost);
        if (playerHasEnough)
        {
            _playerManager.SubstractResource(_refreshCost);
            PopulateShop();
        }
    }

    private void PopulateShop()
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
