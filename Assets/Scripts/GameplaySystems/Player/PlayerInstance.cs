using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerInstance : Instance<PlayerSO>, IResourceBank
{
    [SerializeField] string _playerName;
    [SerializeField] ResourceData _playerResourceData;

    public PlayerInstance(PlayerSO model) : base(model)
    {
        _playerName = model.GetName();
        _playerResourceData = new ResourceData();
        _playerResourceData.Copy(model.GetResourceData());
    }

    public ResourceData GetResourceData()
    {
        return _playerResourceData;
    }
}