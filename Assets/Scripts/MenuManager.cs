using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject menuCanvas;

    private bool menuActive = false;

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
    }
}
