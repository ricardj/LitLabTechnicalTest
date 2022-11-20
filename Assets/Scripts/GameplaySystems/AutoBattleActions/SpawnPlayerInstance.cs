using UnityEngine;
using UnityEngine.Events;

public class SpawnPlayerInstance : IAction<VoidAction>
{
    [SerializeField] PlayerSO _playerModel;
    [SerializeField] PlayerManager _playerManager;

    [SerializeField] PlayerInstance _currentPlayerInstance;

    public override void ExecuteAction(VoidAction data = null, UnityAction onFinish = null)
    {
        _currentPlayerInstance = _playerModel.GetInstance();
        _playerManager.SetupPlayerInstance(_currentPlayerInstance);
    }
}