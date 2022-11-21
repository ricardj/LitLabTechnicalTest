
using System;
using UnityEngine;

[Serializable]
public class ResourceAmount
{
    public ResourceSO targetResource;
    public float amount;

    public ResourceAmountEvent OnResourceAmountUpdated = new ResourceAmountEvent();


    public ResourceAmount(ResourceAmount resourceAmount)
    {
        this.targetResource = resourceAmount.targetResource;
        this.amount = resourceAmount.amount;
    }

    public void SubstractResource(float substractAmount)
    {

        this.amount -= substractAmount;
        this.amount = Mathf.Clamp(this.amount, 0, this.amount);
        OnResourceAmountUpdated.Invoke(this);
    }
    public void AddResource(float amount)
    {
        this.amount += amount;
        OnResourceAmountUpdated.Invoke(this);
    }

    public float GetAmount()
    {
        return amount;
    }
}
