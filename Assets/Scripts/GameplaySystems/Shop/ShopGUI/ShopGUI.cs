using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopGUI : MonoBehaviour
{

    [SerializeField] ShopPurchaseableSection _purchaseablesSection;
    [SerializeField] Button _refreshButton;
    [SerializeField] Button _upgradeLevelButton;

    [Header("Events")]
    public UnityEvent OnRefreshSelected;
    public UnityEvent OnUpgradeSelected;
    public ShopPurchaseableEvent OnPurchaseableSelected;

    public void Start()
    {
        SetupEvents();
    }



    private void SetupEvents()
    {
        _refreshButton.onClick.AddListener(OnRefreshSelected.Invoke);
        _upgradeLevelButton.onClick.AddListener(OnUpgradeSelected.Invoke);
        _purchaseablesSection.OnShopPurchaseableSelected.AddListener(OnPurchaseableSelected.Invoke);
    }

    public void SetPurchaseables(List<IShopPurchaseable> purchaseables)
    {
        _purchaseablesSection.Setup(purchaseables);
    }

    public void SetNewPurchaseable(IShopPurchaseable oldPurchaseable, IShopPurchaseable newShopPurchaseable)
    {
        _purchaseablesSection.SetupNewPurchaseable(oldPurchaseable, newShopPurchaseable);
    }
}
