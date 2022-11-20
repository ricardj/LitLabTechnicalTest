using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopPurchaseablePanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _purchaseableText;
    [SerializeField] Button _purchaseableButton;
    [SerializeField] IShopPurchaseable _currentPurchaseable;

    public ShopPurchaseableEvent OnShopPurchaseableSelected;

    void Start()
    {
        _purchaseableButton.onClick.AddListener(() => OnShopPurchaseableSelected.Invoke(_currentPurchaseable));
    }

    public void Setup(IShopPurchaseable shopPurchaseable)
    {
        _purchaseableText.text = shopPurchaseable.GetName();
        _currentPurchaseable = shopPurchaseable;
    }

    public IShopPurchaseable GetCurrentPurchaseable()
    {
        return _currentPurchaseable;
    }
}
