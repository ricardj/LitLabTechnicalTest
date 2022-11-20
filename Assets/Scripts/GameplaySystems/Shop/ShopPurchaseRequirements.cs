using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ShopPurchaseRequirements
{
    [SerializeField] List<ResourceAmount> _costs;

    public List<ResourceAmount> GetCosts()
    {
        return _costs;
    }
}
