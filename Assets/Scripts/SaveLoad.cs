using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public GameManager manager;
    public Team team;
    public Spawner spawner;
    public ChoiceBand band;
    public ChoiceScarf scarf;
    public IncreaseClickDamage macho;

    // Start is called before the first frame update
    public void Save()
    {
        PlayerPrefs.SetInt("PokeDollars", manager.pokedollars);
        PlayerPrefs.SetInt("PokeBalls", manager.pokeballs);
        PlayerPrefs.SetInt("ClickDamage", manager.clickDamage);
        PlayerPrefs.SetInt("Level", manager.level);
        PlayerPrefs.SetInt("PriceBand", band.price);
        PlayerPrefs.SetInt("PowerBand", band.power);
        PlayerPrefs.SetInt("PriceScarf", scarf.price);
        PlayerPrefs.SetFloat("PowerScarf", scarf.power);
        PlayerPrefs.SetInt("PowerMacho", macho.power);
        PlayerPrefs.SetInt("PriceMacho", macho.price);

        if (team.members[0] != null)
        {
            PlayerPrefs.SetInt("Team0", team.members[0].id);
            PlayerPrefs.SetInt("Atk0", team.atk0);
            PlayerPrefs.SetFloat("Speed0", team.speed0);
        }
        else 
        {
            PlayerPrefs.SetInt("Team0", 0);
        }

        if (team.members[1] != null)
        {
            PlayerPrefs.SetInt("Team1", team.members[1].id);
            PlayerPrefs.SetInt("Atk1", team.atk1);
            PlayerPrefs.SetFloat("Speed1", team.speed1);
        }
        else
        {
            PlayerPrefs.SetInt("Team1", 0);
        }

        if (team.members[2] != null)
        {
            PlayerPrefs.SetInt("Team2", team.members[2].id);
            PlayerPrefs.SetInt("Atk2", team.atk2);
            PlayerPrefs.SetFloat("Speed2", team.speed2);
        }
        else
        {
            PlayerPrefs.SetInt("Team2", 0);
        }

    }

    public void Load()
    {
        manager.pokedollars = PlayerPrefs.GetInt("PokeDollars");
        manager.pokeballs = PlayerPrefs.GetInt("PokeBalls");
        manager.clickDamage = PlayerPrefs.GetInt("ClickDamage");
        manager.level = PlayerPrefs.GetInt("Level");
        band.power = PlayerPrefs.GetInt("PowerBand");
        band.price = PlayerPrefs.GetInt("PriceBand");
        scarf.power = PlayerPrefs.GetFloat("PowerScarf");
        scarf.price = PlayerPrefs.GetInt("PriceScarf");
        macho.power = PlayerPrefs.GetInt("PowerMacho");
        macho.price = PlayerPrefs.GetInt("PriceMacho");



        foreach (PokemonSE pokemon in spawner.encounters)
        {
            if (pokemon.id == PlayerPrefs.GetInt("Team0"))
            {
                team.members[0] = pokemon;
                team.atk0 = PlayerPrefs.GetInt("Atk0");
                team.speed0 = PlayerPrefs.GetFloat("Speed0");
            }
            if (pokemon.id == PlayerPrefs.GetInt("Team1"))
            {
                team.members[1] = pokemon;
                team.atk1 = PlayerPrefs.GetInt("Atk1");
                team.speed1 = PlayerPrefs.GetFloat("Speed1");
            }
            if (pokemon.id == PlayerPrefs.GetInt("Team2"))
            {
                team.members[2] = pokemon;
                team.atk2 = PlayerPrefs.GetInt("Atk2");
                team.speed2 = PlayerPrefs.GetFloat("Speed2");
            }
        }

        if (PlayerPrefs.GetInt("Team0") == 0)
        {
            team.members[0] = null;
        }
        if (PlayerPrefs.GetInt("Team1") == 0)
        {
            team.members[1] = null;
        }
        if (PlayerPrefs.GetInt("Team2") == 0)
        {
            team.members[2] = null;
        }
    }
}
