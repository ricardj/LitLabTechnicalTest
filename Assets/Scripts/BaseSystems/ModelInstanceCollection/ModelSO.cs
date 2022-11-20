using UnityEngine;

public abstract class ModelSO<T> : ScriptableObject
{
    public abstract T GetInstance();
}
