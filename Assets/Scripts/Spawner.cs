using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Spawner : MonoBehaviour

{
    public GameManager manager;

    public int currentHp;

    [SerializeField]

    private TextMeshProUGUI _hpText, _nameText, _type1Text, _type2Text;

    [SerializeField]

    private Image _pokemonImage, _lifeBar;

    private AudioSource _audioSource;

    [SerializeField]
    private Gradient _lifeGradient;

    public PokemonSE currentPokemon;
    public int maxHp;

    [SerializeField]

    public PokemonSE[] encounters;
    private int _wildRarity;

    public AmuletCoin amuletCoin;

    public bool catched =false;

    void Start()

    {
        _audioSource = GetComponent<AudioSource>();

        _wildRarity = Random.Range(1,101);
        if (_wildRarity == 1)
        {
            _wildRarity = 4;
        }
        else if (_wildRarity < 11) 
        {
            _wildRarity = 3;
        }
        else if (_wildRarity > 10 && _wildRarity < 51)
        {
            _wildRarity = 2;
        }
        else if (_wildRarity > 50)
        {
            _wildRarity = 1;
        }

        Spawn(encounters[Random.Range(0, encounters.Length)]);

        while (currentPokemon.rarity != _wildRarity)
        {
            Spawn(encounters[Random.Range(0, encounters.Length)]);
        }
        _audioSource.clip = currentPokemon.cry;
        _audioSource.Play();

    }

    private void Update()
    {
        _lifeBar.fillAmount = (float)currentHp / (float)maxHp;
        _lifeBar.color = _lifeGradient.Evaluate((float)currentHp / (float)maxHp);
    }

    public void ReduceHp(int damage)

    {

        currentHp -= damage;

        _hpText.text = currentHp.ToString("000") + "/" + maxHp;

        if (currentHp <= 0)

        {
            manager.pokedollars += Mathf.RoundToInt(currentPokemon.moneyDrop * (1 + 0.1f * Mathf.Log(manager.level + 1)) * (amuletCoin.power-0.1f));
            manager.level++;
            _wildRarity = Random.Range(1, 101);
            if (_wildRarity == 1)
            {
                _wildRarity = 4;
            }
            else if (_wildRarity < 11)
            {
                _wildRarity = 3;
            }
            else if (_wildRarity > 10 && _wildRarity < 51)
            {
                _wildRarity = 2;
            }
            else if (_wildRarity > 50)
            {
                _wildRarity = 1;
            }

            Spawn(encounters[Random.Range(0, encounters.Length)]);

            while (currentPokemon.rarity != _wildRarity)
            {
                Spawn(encounters[Random.Range(0, encounters.Length)]);
            }
            _audioSource.clip = currentPokemon.cry;
            _audioSource.Play();
        }

        if (catched)
        {
            manager.level++;
            _wildRarity = Random.Range(1, 101);
            if (_wildRarity == 1)
            {
                _wildRarity = 4;
            }
            else if (_wildRarity < 11)
            {
                _wildRarity = 3;
            }
            else if (_wildRarity > 10 && _wildRarity < 51)
            {
                _wildRarity = 2;
            }
            else if (_wildRarity > 50)
            {
                _wildRarity = 1;
            }

            Spawn(encounters[Random.Range(0, encounters.Length)]);

            while (currentPokemon.rarity != _wildRarity)
            {
                Spawn(encounters[Random.Range(0, encounters.Length)]);
            }
            _audioSource.clip = currentPokemon.cry;
            _audioSource.Play();
            catched = false;
        }

    }

    public void ReduceHpClick()

    {

        currentHp -= manager.clickDamage;

        _hpText.text = currentHp.ToString("000") + "/" + maxHp;

        if (currentHp <= 0)

        {
            manager.pokedollars += Mathf.RoundToInt(currentPokemon.moneyDrop * (1 + 0.1f * Mathf.Log(manager.level + 1)) * (amuletCoin.power-0.1f));
            manager.level++;
            _wildRarity = Random.Range(1, 101);
            if (_wildRarity == 1)
            {
                _wildRarity = 4;
            }
            else if (_wildRarity < 11)
            {
                _wildRarity = 3;
            }
            else if (_wildRarity > 10 && _wildRarity < 51)
            {
                _wildRarity = 2;
            }
            else if (_wildRarity > 50)
            {
                _wildRarity = 1;
            }

            Spawn(encounters[Random.Range(0, encounters.Length)]);

            while (currentPokemon.rarity != _wildRarity)
            {
                Spawn(encounters[Random.Range(0, encounters.Length)]);
            }
            _audioSource.clip = currentPokemon.cry;
            _audioSource.Play();
        }

        if (catched)
        {
            manager.level++;
            _wildRarity = Random.Range(1, 101);
            if (_wildRarity == 1)
            {
                _wildRarity = 4;
            }
            else if (_wildRarity < 11)
            {
                _wildRarity = 3;
            }
            else if (_wildRarity > 10 && _wildRarity < 51)
            {
                _wildRarity = 2;
            }
            else if (_wildRarity > 50)
            {
                _wildRarity = 1;
            }

            Spawn(encounters[Random.Range(0, encounters.Length)]);

            while (currentPokemon.rarity != _wildRarity)
            {
                Spawn(encounters[Random.Range(0, encounters.Length)]);
            }
            _audioSource.clip = currentPokemon.cry;
            _audioSource.Play();
            catched = false;
        }

    }

    private void Spawn(PokemonSE newPokemon)

    {

        currentPokemon = newPokemon;

        maxHp = Mathf.RoundToInt(currentPokemon.totalHp + (manager.level * (Random.Range(10, 20))/10));

        currentHp = maxHp;

        _hpText.text = currentHp.ToString("000") + "/" + maxHp;

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

            case PokemonType.Tenebres:

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

            case PokemonType.Electrik:

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

            case PokemonType.Tenebres:

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

            case PokemonType.Electrik:

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

