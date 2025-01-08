using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public GameManager manager;
    public Team team;
    public Spawner spawner;

    // Start is called before the first frame update
    public void Save()
    {
        PlayerPrefs.SetInt("PokeDollars", manager.pokedollars);
        PlayerPrefs.SetInt("PokeBalls", manager.pokeballs);
        PlayerPrefs.SetInt("ClickDamage", manager.clickDamage);
        PlayerPrefs.SetInt("Level", manager.level);

        //if (team.members[0] != null)
        //{
        //    PlayerPrefs.SetString("Team0", team.members[0].pokemonName);
        //    PlayerPrefs.SetInt("Atk0", team.atk0);
        //    PlayerPrefs.SetFloat("Speed0", team.speed0);
        //}

        //if (team.members[1] != null)
        //{
        //    PlayerPrefs.SetString("Team1", team.members[1].pokemonName);
        //    PlayerPrefs.SetInt("Atk1", team.atk1);
        //    PlayerPrefs.SetFloat("Speed1", team.speed1);
        //}

        //if (team.members[2] != null)
        //{
        //    PlayerPrefs.SetString("Team2", team.members[2].pokemonName);
        //    PlayerPrefs.SetInt("Atk2", team.atk2);
        //    PlayerPrefs.SetFloat("Speed2", team.speed2);
        //}

    }

    public void Load()
    {
        manager.pokedollars = PlayerPrefs.GetInt("PokeDollars");
        manager.pokeballs = PlayerPrefs.GetInt("PokeBalls");
        manager.clickDamage = PlayerPrefs.GetInt("ClickDamage");
        manager.level = PlayerPrefs.GetInt("Level");

        //for (int i = 0; i < spawner.encounters.Length; i++)
        //{
        //    PokemonSE pokemon = spawner.encounters[i];
        //    if (pokemon.pokemonName == PlayerPrefs.GetString("Team0"))
        //    {
        //        team.members[0] = pokemon;
        //        team.atk0 = PlayerPrefs.GetInt("Atk0");
        //        team.speed0 = PlayerPrefs.GetFloat("Speed0");
        //    }
        //    if (pokemon.pokemonName == PlayerPrefs.GetString("Team1"))
        //    {
        //        team.members[1] = pokemon;
        //        team.atk1 = PlayerPrefs.GetInt("Atk1");
        //        team.speed1 = PlayerPrefs.GetFloat("Speed1");
        //    }
        //    if (pokemon.pokemonName == PlayerPrefs.GetString("Team2"))
        //    {
        //        team.members[2] = pokemon;
        //        team.atk2 = PlayerPrefs.GetInt("Atk2");
        //        team.speed2 = PlayerPrefs.GetFloat("Speed2");
        //    }
        //}
    }
}
