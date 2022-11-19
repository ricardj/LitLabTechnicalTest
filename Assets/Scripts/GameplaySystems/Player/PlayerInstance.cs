using System;
using UnityEngine;

[Serializable]
public class PlayerInstance : Instance<PlayerSO>
{
    [SerializeField] string playerName;
    [SerializeField] ResourceAmount currencyAmount;
    [SerializeField] ResourceAmount healthAmount;
    [SerializeField] ResourceAmount levelAmount;

    public PlayerInstance(PlayerSO model) : base(model)
    {
    }
}