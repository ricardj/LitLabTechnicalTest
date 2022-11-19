using System;
using UnityEngine.Events;

public interface IAction
{

    void ExecuteAction(UnityAction onFinish = null);
}
