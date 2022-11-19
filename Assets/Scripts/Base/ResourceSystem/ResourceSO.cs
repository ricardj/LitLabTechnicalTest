using UnityEngine;

[CreateAssetMenu(menuName = "CyberMonsters/New Resource")]
public class ResourceSO : ScriptableObject, IRepresentable
{
    [SerializeField] string _resourceName;
    [SerializeField] Sprite _resourceSprite;

    public string GetName()    
    {
        return _resourceName;
    }

    public Sprite GetSprite()
    {
        return _resourceSprite;
    }
}
