
using System;
using UnityEngine;

[Serializable]
public class ResourceAmount
{
    public ResourceSO targetResource;
    public float amount;
    private ResourceAmount resourceAmount;

    public ResourceAmount(ResourceAmount resourceAmount)
    {
        this.targetResource = resourceAmount.targetResource;
        this.amount = resourceAmount.amount;
    }

    public void SubstractResource(float amount)
    {
        this.amount -= amount;
        this.amount = Mathf.Clamp(this.amount, 0, this.amount);
    }
    public void AddResource(float amount)
    {
        this.amount += amount;
    }
}
