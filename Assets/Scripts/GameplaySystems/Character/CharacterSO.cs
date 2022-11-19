using UnityEngine;

[CreateAssetMenu(menuName ="CyberMonsters/New Character")]
public class CharacterSO : ModelSO<CharacterInstance>, ITagged
{

    public string characterName;
    public TaggedData taggedData;


    public override CharacterInstance GetInstance()
    {
        return new CharacterInstance()
        {

        };
    }

    public TaggedData GetTaggedData()
    {
        return taggedData;
    }
}
