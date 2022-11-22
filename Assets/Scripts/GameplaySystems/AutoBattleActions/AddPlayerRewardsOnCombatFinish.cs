using UnityEngine;
using UnityEngine.Events;

public class AddPlayerRewardsOnCombatFinish : IAction<VoidAction>
{
    [SerializeField] CombatManager _combatManager;
    [SerializeField] PlayerManager _playerManager;
    [SerializeField] ResourceAmount _winReward;
    [SerializeField] ResourceAmount _bounsReward;
    [SerializeField] ResourceAmount _loosePunishment;

    [SerializeField]
    [ReadOnly]
    int _winStreak = 0;

    public void Start()
    {
        _combatManager.OnCombatWin.AddListener(() =>
        {
            _playerManager.AddResource(_winReward);
            for (int i = 0; i < _winStreak; i++)
            {
                _playerManager.AddResource(_bounsReward);
            }
            _winStreak++;

        });
        _combatManager.OnCombatLoose.AddListener(() =>
        {
            _winStreak = 0;
            _playerManager.SubstractResource(_loosePunishment);
        });
    }

    public override void ExecuteAction(VoidAction data = null, UnityAction onFinish = null)
    {

    }
}