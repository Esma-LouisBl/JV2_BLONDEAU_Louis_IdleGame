using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Spawner : MonoBehaviour

{

    private int _currentHp;

    [SerializeField]

    private TextMeshProUGUI _hpText, _nameText, _type1Text, _type2Text;

    [SerializeField]

    private Image _pokemonImage;

    [SerializeField]

    private PokemonSE _currentPokemon;

    [SerializeField]

    private PokemonSE[] _encounters;

    void Start()

    {

        Spawn(_encounters[Random.Range(0, _encounters.Length)]);

    }

    public void ReduceHp()

    {

        _currentHp -= 10;

        _hpText.text = _currentHp.ToString("000");

        if (_currentHp <= 0)

        {

            Spawn(_encounters[Random.Range(0, _encounters.Length)]);

        }

    }

    private void Spawn(PokemonSE newPokemon)

    {

        _currentPokemon = newPokemon;

        _currentHp = _currentPokemon.totalHp;

        _hpText.text = _currentPokemon.totalHp.ToString("00");

        _nameText.text = _currentPokemon.pokemonName.ToString();

        _type1Text.text = _currentPokemon.type1.ToString();

        _type2Text.text = _currentPokemon.type2.ToString();

        if (_type2Text.text == "None")
        {
            _type2Text.SetText("");
        }

        _pokemonImage.sprite = _currentPokemon.sprite;
        
        switch (_currentPokemon.type1)

        {

            case PokemonType.Eau:

                Camera.main.backgroundColor = Color.blue;

                break;

            case PokemonType.Feu:

                Camera.main.backgroundColor = Color.red;

                break;

            case PokemonType.Psy:

                Camera.main.backgroundColor = Color.magenta;

                break;

            case PokemonType.Ténèbres:

                Camera.main.backgroundColor = Color.black;

                break;

            case PokemonType.Acier:

                Camera.main.backgroundColor = Color.gray;

                break;

            case PokemonType.Combat:

                Camera.main.backgroundColor = Color.grey;

                break;

            case PokemonType.Normal:

                Camera.main.backgroundColor = Color.white;

                break;

            case PokemonType.Électrik:

                Camera.main.backgroundColor = Color.yellow;

                break;

            case PokemonType.Plante:

                _type1Text.color = new Color(61f/255f, 162f/255f, 36f/255f);

                break;

            case PokemonType.Dragon:

                Camera.main.backgroundColor = Color.white;

                break;

            default:

                break;

        }

    }

}

