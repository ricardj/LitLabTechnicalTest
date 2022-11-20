using System.Collections.Generic;
using UnityEngine;

public class ShopPurchaseableSection : MonoBehaviour
{
    [SerializeField] List<ShopPurchaseablePanel> _shopPurchaseablePanels;
    public ShopPurchaseableEvent OnShopPurchaseableSelected;

    public void Start()
    {
        _shopPurchaseablePanels.ForEach(shopPurchaseablePanel =>
        {
            shopPurchaseablePanel.OnShopPurchaseableSelected.AddListener(OnShopPurchaseableSelected.Invoke);
        });
    }

    public void Setup(List<IShopPurchaseable> shopPurchaseables)
    {
        for (int i = 0; i < shopPurchaseables.Count && i < _shopPurchaseablePanels.Count; i++)
        {
            ShopPurchaseablePanel shopPurchaseablePanel = _shopPurchaseablePanels[i];
            IShopPurchaseable shopPurchaseable = shopPurchaseables[i];

            shopPurchaseablePanel.Setup(shopPurchaseable);
        }
    }

    public void SetupNewPurchaseable(IShopPurchaseable oldPurchaseable, IShopPurchaseable newShopPurchaseable)
    {
        ShopPurchaseablePanel panelWithOldPurchaseable = _shopPurchaseablePanels.Find(panel => panel.GetCurrentPurchaseable() == oldPurchaseable);
        panelWithOldPurchaseable.Setup(newShopPurchaseable);
    }

}