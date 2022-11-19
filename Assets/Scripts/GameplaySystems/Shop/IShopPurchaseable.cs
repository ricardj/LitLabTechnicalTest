using UnityEngine;

public interface IShopPurchaseable : IRepresentable
{

    public ShopPurchaseRequirements GetPurchaseRequirements();
}
