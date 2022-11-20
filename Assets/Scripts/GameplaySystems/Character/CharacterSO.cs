﻿using System;
using UnityEngine;

[CreateAssetMenu(menuName = "CyberMonsters/New Character")]
public class CharacterSO : ModelSO<CharacterInstance>, IVisible, ITagged, IShopPurchaseable
{

    [SerializeField] string _defaultCharacterName;
    [SerializeField] Sprite _defaultCharacterSprite;
    [SerializeField] TaggedData _taggedData;
    [SerializeField] ShopPurchaseRequirements _defaultPurchaseRequirements;

    public override CharacterInstance GetInstance()
    {
        return new CharacterInstance(this);
    }

    public string GetName()
    {
        return _defaultCharacterName;
    }

    public Sprite GetSprite()
    {
        return _defaultCharacterSprite;
    }

    public TaggedData GetTaggedData()
    {
        return _taggedData;
    }

    public ShopPurchaseRequirements GetPurchaseRequirements()
    {
        return _defaultPurchaseRequirements;
    }


}
