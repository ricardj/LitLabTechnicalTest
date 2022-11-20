using UnityEngine;

public interface IShopPurchaseable : IRepresentable
{
    ShopPurchaseRequirements GetPurchaseRequirements();
}
