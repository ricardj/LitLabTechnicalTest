using TMPro;
using UnityEngine;

public class ResourceAmountPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _resourceName;
    [SerializeField] TextMeshProUGUI _resourceAmount;

    [SerializeField][ReadOnly] ResourceAmount _targetResourceAmount;
    public void Setup(ResourceAmount resourceAmount)
    {
        _targetResourceAmount = resourceAmount;
        _targetResourceAmount.OnResourceAmountUpdated.AddListener(amount => UpdateCurrentAmount());
        UpdateCurrentAmount();

    }

    public void UpdateCurrentAmount()
    {
        UpdateAmount(_targetResourceAmount);
    }

    private void UpdateAmount(ResourceAmount resourceAmount)
    {
        _resourceName.text = resourceAmount.targetResource.GetName();
        _resourceAmount.text = resourceAmount.GetAmount().ToString();
    }
}