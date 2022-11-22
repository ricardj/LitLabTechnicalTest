using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    [SerializeField] PlayerInstance _currentPlayerInstance;
    [SerializeField] PlayerGUI _playerGUI;
    [SerializeField] ResourceSO _levelResource;

    public void SetupPlayerInstance(PlayerInstance currentPlayerInstance)
    {
        this._currentPlayerInstance = currentPlayerInstance;
        _playerGUI.Setup(_currentPlayerInstance.GetResourceData());
    }

    public bool PlayerHasEnough(ResourceAmount resourceAmount)
    {
        return this._currentPlayerInstance.GetResourceData().HasEnough(resourceAmount);
    }

    public bool PlayerHasEnough(ResourceSO resourceType, float amount)
    {
        return this._currentPlayerInstance.GetResourceData().HasEnough(resourceType, amount);
    }

    public bool PlayerHasEnough(List<ResourceAmount> resourceAmounts)
    {
        return this._currentPlayerInstance.GetResourceData().HasEnough(resourceAmounts);
    }

    public void SubstractResource(List<ResourceAmount> resourceAmounts)
    {
        this._currentPlayerInstance.GetResourceData().SubstractResource(resourceAmounts);
    }

    public void SubstractResource(ResourceAmount resourceAmounts)
    {
        this._currentPlayerInstance.GetResourceData().SubstractResource(resourceAmounts);
    }

    public void AddResource(ResourceAmount resourceAmount)
    {
        this._currentPlayerInstance.GetResourceData().AddResource(resourceAmount);
    }

    public void UpgradeLevel()
    {
        this._currentPlayerInstance.GetResourceData().AddResource(new ResourceAmount(_levelResource, 1));
    }
}
