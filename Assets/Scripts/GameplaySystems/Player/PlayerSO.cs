using UnityEngine;

[CreateAssetMenu(menuName ="CyberMonsters/New Player Model")]
public class PlayerSO : ModelSO<PlayerInstance>
{


    public override PlayerInstance GetInstance()
    {
        return new PlayerInstance(this)
        {

        };
    }
}
