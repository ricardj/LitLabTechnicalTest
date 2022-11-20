using UnityEngine;
using UnityEngine.Events;

public class SpawnPlayerInstance : IAction<VoidAction>
{
    [SerializeField] PlayerSO _playerModel;
    [SerializeField] PlayerInstance _currentPlayerInstance;
    [SerializeField] PlayerManager _playerManager;

    public override void ExecuteAction(VoidAction data = null, UnityAction onFinish = null)
    {
        _currentPlayerInstance = _playerModel.GetInstance();
        _playerManager.SetupPlayerInstance(_currentPlayerInstance);
    }
}