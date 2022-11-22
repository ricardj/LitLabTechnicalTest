using DG.Tweening;
using TMPro;
using UnityEngine;

public class AuttoBattleGUICombat : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _resultText;
    [SerializeField] Color _winColor = Color.green;
    [SerializeField] Color _looseColor = Color.red;

    public void ShowWin()
    {
        _resultText.text = "WIN !";
        _resultText.color = _winColor;
        ShowResult();
    }

    public void ShowLoose()
    {
        _resultText.text = "LOOSE";
        _resultText.color = _looseColor;
        ShowResult();
    }

    private void ShowResult()
    {
        _resultText.gameObject.SetActive(true);
        _resultText.transform.localScale = Vector3.zero;
        _resultText.transform.DOScale(Vector3.one, 0.7f).SetEase(Ease.OutElastic).OnComplete(() =>
        {
            _resultText.transform.DOScale(Vector3.zero, 0.3f).SetDelay(0.4f).OnComplete(() =>
            {
                _resultText.gameObject.SetActive(false);
            });
        });

    }
}