using System;

[Serializable]
public class PlayerInstance : IInstance
{
    public string playerName;
    public ResourceAmount currencyAmount;
    public ResourceAmount healthAmount;
    public ResourceAmount levelAmount;

}