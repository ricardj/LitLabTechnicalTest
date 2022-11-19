using UnityEngine;

public interface IShopPurchaseable
{
    public string GetName();
    public Sprite GetAppearance();
    public ShopPurchaseRequirements GetPurchaseRequirements();
}
