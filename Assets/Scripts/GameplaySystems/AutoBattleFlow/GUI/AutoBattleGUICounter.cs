using TMPro;
using UnityEngine;

public class AutoBattleGUICounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _counterText;

    public void UpdateCounter(string message)
    {
        _counterText.text = message;
    }
}
