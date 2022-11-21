using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    [SerializeField] PlayerInstance _currentPlayerInstance;
    [SerializeField] PlayerGUI _playerGUI;

    public void SetupPlayerInstance(PlayerInstance currentPlayerInstance)
    {
        this._currentPlayerInstance = currentPlayerInstance;
        _playerGUI.Setup(_currentPlayerInstance.GetResourceData());
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
}
