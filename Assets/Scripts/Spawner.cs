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

        _pokemonImage.sprite = _currentPokemon.sprite;
        
        /*switch (_currentPokemon.type)

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

            case PokemonType.Obscurite:

                Camera.main.backgroundColor = Color.black;

                break;

            case PokemonType.Metal:

                Camera.main.backgroundColor = Color.gray;

                break;

            case PokemonType.Combat:

                Camera.main.backgroundColor = Color.grey;

                break;

            case PokemonType.Incolore:

                Camera.main.backgroundColor = Color.white;

                break;

            case PokemonType.Electric:

                Camera.main.backgroundColor = Color.yellow;

                break;

            case PokemonType.Plante:

                Camera.main.backgroundColor = Color.green;

                break;

            case PokemonType.Dragon:

                Camera.main.backgroundColor = Color.white;

                break;

            default:

                break;

        }*/

    }

}

