using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Spawner : MonoBehaviour

{
    public GameManager manager;

    private int _currentHp;

    [SerializeField]

    private TextMeshProUGUI _hpText, _nameText, _type1Text, _type2Text;

    [SerializeField]

    private Image _pokemonImage;

    public PokemonSE currentPokemon;

    [SerializeField]

    private PokemonSE[] _encounters;

    public bool catched =false;

    void Start()

    {

        Spawn(_encounters[Random.Range(0, _encounters.Length)]);

    }

    public void ReduceHp(int damage)

    {

        _currentHp -= damage;

        _hpText.text = _currentHp.ToString("000");

        if (_currentHp <= 0)

        {
            manager.pokedollars += currentPokemon.moneyDrop;
            Spawn(_encounters[Random.Range(0, _encounters.Length)]);
        }

        if (catched)
        {
            Spawn(_encounters[Random.Range(0, _encounters.Length)]);
            catched = false;
        }

        }

    private void Spawn(PokemonSE newPokemon)

    {

        currentPokemon = newPokemon;

        _currentHp = currentPokemon.totalHp;

        _hpText.text = currentPokemon.totalHp.ToString("00");

        _nameText.text = currentPokemon.pokemonName.ToString();

        _type1Text.text = currentPokemon.type1.ToString();

        _type2Text.text = currentPokemon.type2.ToString();

        if (_type2Text.text == "None")
        {
            _type2Text.SetText("");
        }

        _pokemonImage.sprite = currentPokemon.sprite;
        
        switch (currentPokemon.type1)

        {

            case PokemonType.Eau:

                _type1Text.color = new Color(36f / 255f, 129f / 255f, 239f / 255f);

                break;

            case PokemonType.Feu:

                _type1Text.color = new Color(231f / 255f, 35f / 255f, 36f / 255f);

                break;

            case PokemonType.Psy:

                _type1Text.color = new Color(239f / 255f, 63f / 255f, 122f / 255f);

                break;

            case PokemonType.Ténèbres:

                _type1Text.color = new Color(79f / 255f, 63f / 255f, 61f / 255f);

                break;

            case PokemonType.Acier:

                _type1Text.color = new Color(96f / 255f, 162f / 255f, 185f / 255f);

                break;

            case PokemonType.Combat:

                _type1Text.color = new Color(255f / 255f, 129f / 255f, 0f / 255f);

                break;

            case PokemonType.Normal:

                _type1Text.color = new Color(158f / 255f, 161f / 255f, 158f / 255f);

                break;

            case PokemonType.Électrik:

                _type1Text.color = new Color(250f / 255f, 193f / 255f, 0f / 255f);

                break;

            case PokemonType.Plante:

                _type1Text.color = new Color(61f/255f, 162f/255f, 36f/255f);

                break;

            case PokemonType.Dragon:

                _type1Text.color = new Color(79f / 255f, 96f / 255f, 226f / 255f);

                break;

            case PokemonType.Glace:

                _type1Text.color = new Color(61f / 255f, 217f / 255f, 255f / 255f);

                break;

            case PokemonType.Insecte:

                _type1Text.color = new Color(146f / 162f, 96f / 255f, 18f / 255f);

                break;

            case PokemonType.Poison:

                _type1Text.color = new Color(146f / 255f, 63f / 255f, 204f / 255f);

                break;

            case PokemonType.Roche:

                _type1Text.color = new Color(176f / 255f, 170f / 255f, 130f / 255f);

                break;

            case PokemonType.Sol:

                _type1Text.color = new Color(146f / 255f, 80f / 255f, 27f / 255f);

                break;

            case PokemonType.Spectre:

                _type1Text.color = new Color(112f / 255f, 63f / 255f, 112f / 255f);

                break;

            case PokemonType.Vol:

                _type1Text.color = new Color(130f / 255f, 186f / 255f, 239f / 255f);

                break;

            default:

                break;

        }

        switch (currentPokemon.type2)

        {

            case PokemonType.Eau:

                _type2Text.color = new Color(36f / 255f, 129f / 255f, 239f / 255f);

                break;

            case PokemonType.Feu:

                _type2Text.color = new Color(231f / 255f, 35f / 255f, 36f / 255f);

                break;

            case PokemonType.Psy:

                _type2Text.color = new Color(239f / 255f, 63f / 255f, 122f / 255f);

                break;

            case PokemonType.Ténèbres:

                _type2Text.color = new Color(79f / 255f, 63f / 255f, 61f / 255f);

                break;

            case PokemonType.Acier:

                _type2Text.color = new Color(96f / 255f, 162f / 255f, 185f / 255f);

                break;

            case PokemonType.Combat:

                _type2Text.color = new Color(255f / 255f, 129f / 255f, 0f / 255f);

                break;

            case PokemonType.Normal:

                _type2Text.color = new Color(158f / 255f, 161f / 255f, 158f / 255f);

                break;

            case PokemonType.Électrik:

                _type2Text.color = new Color(250f / 255f, 193f / 255f, 0f / 255f);

                break;

            case PokemonType.Plante:

                _type2Text.color = new Color(61f / 255f, 162f / 255f, 36f / 255f);

                break;

            case PokemonType.Dragon:

                _type2Text.color = new Color(79f / 255f, 96f / 255f, 226f / 255f);

                break;

            case PokemonType.Glace:

                _type2Text.color = new Color(61f / 255f, 217f / 255f, 255f / 255f);

                break;

            case PokemonType.Insecte:

                _type2Text.color = new Color(146f / 162f, 96f / 255f, 18f / 255f);

                break;

            case PokemonType.Poison:

                _type2Text.color = new Color(146f / 255f, 63f / 255f, 204f / 255f);

                break;

            case PokemonType.Roche:

                _type2Text.color = new Color(176f / 255f, 170f / 255f, 130f / 255f);

                break;

            case PokemonType.Sol:

                _type2Text.color = new Color(146f / 255f, 80f / 255f, 27f / 255f);

                break;

            case PokemonType.Spectre:

                _type2Text.color = new Color(112f / 255f, 63f / 255f, 112f / 255f);

                break;

            case PokemonType.Vol:

                _type2Text.color = new Color(130f / 255f, 186f / 255f, 239f / 255f);

                break;

            default:

                break;
            
        }

    }

}

