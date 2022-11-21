using UnityEngine;

public class ResourceDataGUI : MonoBehaviour
{
    public ResourceData _targetResourceData;

    [SerializeField] ResourceAmountPanel _resourceAmountPanelPrefab;
    [SerializeField] Transform _targetParent;

    public void Setup(ResourceData resourceData)
    {
        _targetResourceData = resourceData;

        ClearParentTransform();
        _targetResourceData.GetResourceAmounts().ForEach(resourceAmount =>
        {
            ResourceAmountPanel newPanel = Instantiate(_resourceAmountPanelPrefab, _targetParent);
            newPanel.Setup(resourceAmount);
        });


    }

    private void ClearParentTransform()
    {
        foreach (Transform child in _targetParent)
        {
            Destroy(child.gameObject);
        }
    }
}
