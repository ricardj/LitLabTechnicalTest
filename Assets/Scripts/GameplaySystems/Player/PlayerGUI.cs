using UnityEngine;

public class PlayerGUI : MonoBehaviour
{
    public ResourceDataGUI _resourceAmountPanel;

    internal void Setup(ResourceData resourceData)
    {
        _resourceAmountPanel.Setup(resourceData);
    }
}