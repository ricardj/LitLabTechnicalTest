public class CharacterInstance : IInstance, ITagged
{
    public TaggedData _taggedData;
    public TaggedData GetTaggedData()
    {
        return _taggedData;
    }
}
