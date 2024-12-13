using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public GameObject menuCanvas;

    private bool menuActive = false;

    [SerializeField]
    private TextMeshProUGUI _noMoney1, _noMoney2, _noMoney3;

    void Update()
    {

    }

    public void ToggleMenu()
    {
        menuActive = !menuActive;
        menuCanvas.SetActive(menuActive);
    }

    public void CloseMenu()
    {
        menuActive = false;
        menuCanvas.SetActive(false);
        _noMoney1.enabled = false;
        _noMoney2.enabled = false;
        _noMoney3.enabled = false;
    }
}
