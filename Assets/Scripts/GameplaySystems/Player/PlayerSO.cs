using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CyberMonsters/New Player Model")]
public class PlayerSO : ModelSO<PlayerInstance>, INameable, IResourceBank
{
    [SerializeField] string _playerName;
    [SerializeField] ResourceData _playerResources;

    public override PlayerInstance GetInstance()
    {
        return new PlayerInstance(this);
    }

    public string GetName()
    {
        return _playerName;
    }

    public ResourceData GetResourceData()
    {
        return _playerResources;
    }
}
