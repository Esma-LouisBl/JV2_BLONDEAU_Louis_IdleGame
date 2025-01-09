using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public GameObject shop1Canvas;
    public GameObject shop2Canvas;

    [SerializeField]
    private TextMeshProUGUI _noMoney1;

    private void Start()
    {
        shop1Canvas.SetActive(false);
        shop2Canvas.SetActive(false);
    }
    void Update()
    {

    }

    public void ToggleMenu()
    {
        shop2Canvas.SetActive(true);
        shop1Canvas.SetActive(false);
    }

    public void CloseMenu()
    {
        shop2Canvas.SetActive(false);
        shop1Canvas.SetActive(true);
        _noMoney1.enabled = false;
    }
}
