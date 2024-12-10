using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int pokeballs;
    public int pokedollars;
    public int level = 1;

    public MenuManager menuManager;
    // Start is called before the first frame update
    void Start()
    {
        menuManager.CloseMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
