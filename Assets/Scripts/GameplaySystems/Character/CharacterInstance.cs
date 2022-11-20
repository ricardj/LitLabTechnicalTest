using System;
using UnityEngine;

[Serializable]
public class CharacterInstance : Instance<CharacterSO>, ITagged, IShopPurchaseable, IInventoryItem
{
    [SerializeField] string _characterName;
    [SerializeField] TaggedData _taggedData;

    public CharacterInstance(CharacterSO model) : base(model)
    {
    }


    public string GetName()
    {
        return _characterName;
    }

    public ShopPurchaseRequirements GetPurchaseRequirements()
    {
        return GetModel().GetPurchaseRequirements();
    }

    public Sprite GetSprite()
    {
        return GetModel().GetSprite();
    }

    public TaggedData GetTaggedData()
    {
        return _taggedData;
    }

    public GameObject GetSpawnPrefab()
    {
        return GetModel().GetSpawnPrefab();
    }

 
}
