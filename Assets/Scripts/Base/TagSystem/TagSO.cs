using UnityEngine;

[CreateAssetMenu(menuName = "CyberMonsters/New Tag")]
public class TagSO : ScriptableObject, INameable
{
    [SerializeField] string _tagName;

    public string GetName()
    {
        return _tagName;
    }

}
