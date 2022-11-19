using System;
using UnityEngine;

[CreateAssetMenu(menuName = "CyberMonsters/New Character")]
public class CharacterSO : ModelSO<CharacterInstance>, IVisible, ITagged
{

    [SerializeField] string _defaultCharacterName;
    [SerializeField] Sprite _defaultCharacterSprite;
    [SerializeField] TaggedData _taggedData;
    [SerializeField] ShopPurchaseRequirements _defaultPurchaseRequirements;

    public override CharacterInstance GetInstance()
    {
        return new CharacterInstance(this)
        {
        };
    }

    public Sprite GetSprite()
    {
        return _defaultCharacterSprite;
    }

    public TaggedData GetTaggedData()
    {
        return _taggedData;
    }

    internal ShopPurchaseRequirements GetPurchaseRequirements()
    {
        throw new NotImplementedException();
    }
}
