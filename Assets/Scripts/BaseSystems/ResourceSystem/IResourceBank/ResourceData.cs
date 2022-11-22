using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ResourceData
{

    [SerializeField] List<ResourceAmount> _resourceAmounts;
    public ResourceData()
    {
        _resourceAmounts = new List<ResourceAmount>();
    }
    public ResourceData(List<ResourceAmount> resourceAmounts)
    {
        _resourceAmounts = resourceAmounts;
    }

    public void Copy(ResourceData resourceData)
    {
        _resourceAmounts = new List<ResourceAmount>();
        resourceData.GetResourceAmounts().ForEach(resourceAmount =>
        {
            _resourceAmounts.Add(new ResourceAmount(resourceAmount));
        });

    }

    private ResourceAmount GetTargetResourceAmount(ResourceSO resource)
    {
        return _resourceAmounts.Find(resourceAmount => resourceAmount.targetResource == resource);
    }

    public List<ResourceAmount> GetResourceAmounts()
    {
        return _resourceAmounts;
    }


    public bool HasEnough(ResourceAmount resourceAmount)
    {
        return HasEnough(resourceAmount.targetResource, resourceAmount.amount);
    }

    public bool HasEnough(ResourceSO resource, float amount)
    {
        bool hasEnough = false;
        ResourceAmount currentResourceAmount = GetTargetResourceAmount(resource);

        if (currentResourceAmount != null)
        {
            if (currentResourceAmount.amount >= amount)
            {
                hasEnough = true;
            }
        }

        return hasEnough;
    }
    public bool HasEnough(List<ResourceAmount> resourceAmounts)
    {
        bool hasEnough = true;
        for (int i = 0; i < resourceAmounts.Count; i++)
        {
            ResourceAmount currentResourceAmount = resourceAmounts[i];
            if (!HasEnough(currentResourceAmount))
            {
                hasEnough = false;
                break;
            }
        }
        return hasEnough;
    }

    public void SubstractResource(List<ResourceAmount> substractResourceAmount)
    {
        substractResourceAmount.ForEach(resourceAmount =>
        {
            SubstractResource(resourceAmount);
        });
    }

    public void SubstractResource(ResourceAmount resourceAmount)
    {
        ResourceAmount currentResourceAmount = GetTargetResourceAmount(resourceAmount.targetResource);
        if (currentResourceAmount != null)
        {
            currentResourceAmount.SubstractResource(resourceAmount.amount);
        }
    }

    public void AddResource(ResourceAmount resourceAmount)
    {
        ResourceAmount currentResourceAmount = GetTargetResourceAmount(resourceAmount.targetResource);
        if (currentResourceAmount != null)
        {
            currentResourceAmount.AddResource(resourceAmount.amount);
        }
    }
}
