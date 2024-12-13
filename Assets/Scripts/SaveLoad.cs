using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public GameManager manager;
    // Start is called before the first frame update
    public void Save()
    {
        PlayerPrefs.SetInt("PokeDollars", manager.pokedollars);
        PlayerPrefs.SetInt("PokeBalls", manager.pokeballs);
        PlayerPrefs.SetInt("ClickDamage", manager.clickDamage);
        PlayerPrefs.SetInt("Level", manager.level);
    }

    public void Load()
    {
        manager.pokedollars = PlayerPrefs.GetInt("PokeDollars");
        manager.pokeballs = PlayerPrefs.GetInt("PokeBalls");
        manager.clickDamage = PlayerPrefs.GetInt("ClickDamage");
        manager.level = PlayerPrefs.GetInt("Level");
    }
}
