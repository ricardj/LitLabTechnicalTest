using UnityEngine;

public abstract class ModelSO<T> : ScriptableObject where T : IInstance
{
    public abstract T GetInstance();
}
