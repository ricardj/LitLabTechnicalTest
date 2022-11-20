using UnityEngine;

public class ICombatAttacker : MonoBehaviour, ITagged, IResourceBank
{
    [SerializeField] ResourceData _resourceData;
    [SerializeField] TaggedData _taggedData;

    public ResourceData GetResourceData()
    {
        return _resourceData;
    }

    public TaggedData GetTaggedData()
    {
        return _taggedData;
    }
}
