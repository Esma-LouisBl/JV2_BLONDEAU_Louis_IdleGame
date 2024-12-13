using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Team : MonoBehaviour
{
    public Spawner spawner;
    public PokemonSE[] members = new PokemonSE[3];

    public bool ready0;
    public bool ready1;
    public bool ready2;

    public float speed0;
    public float speed1;
    public float speed2;
    public List<float> speeds = new List<float>();

    public int atk0;
    public int atk1;
    public int atk2;
    public List<float> atks = new List<float>();

    [SerializeField]
    private Sprite _pokemonDefaultSprite;
    [SerializeField]
    private Image _pokemon0Sprite;
    [SerializeField]
    private Image _pokemon1Sprite;
    [SerializeField]
    private Image _pokemon2Sprite;
    // Start is called before the first frame update
    void Start()
    {
        ready0 = true;
        ready1 = true;
        ready2 = true;

        speeds.Add(speed0);
        speeds.Add(speed1);
        speeds.Add(speed2);

        atks.Add(atk0);
        atks.Add(atk1);
        atks.Add(atk2);

        speed0 = members[0].cooldown;

        atk0 = members[0].atq;
    }

    // Update is called once per frame
    void Update()
    {
        if (members[0] != null)
        {
            _pokemon0Sprite.sprite = members[0].sprite;
        }

        if (members[1] != null)
        {
            _pokemon1Sprite.sprite = members[1].sprite;
        }

        if (members[2] != null)
        {
            _pokemon2Sprite.sprite = members[2].sprite;
        }

        if (ready0 == true)
        {
            if (members[0] != null)
            {
                ready0 = false;
                StartCoroutine(AutoClick0());
            }
            else
            {
                _pokemon0Sprite.sprite = _pokemonDefaultSprite;
            }
        }

        if (ready1 == true)
        {
            if (members[1] != null)
            {
                _pokemon1Sprite.sprite = members[1].sprite;
                ready1 = false;
                StartCoroutine(AutoClick1());
            }
            else
            {
                _pokemon1Sprite.sprite = _pokemonDefaultSprite;
            }
        }

        if (ready2 == true)
        {
            if (members[2] != null)
            {
                _pokemon2Sprite.sprite = members[2].sprite;
                ready2 = false;
                StartCoroutine(AutoClick2());
            }
            else
            {
                _pokemon2Sprite.sprite = _pokemonDefaultSprite;
            }
        }
    }

    private IEnumerator AutoClick0()
    {
        while (members[0]!=null)
        {
            spawner.ReduceHp(atk0);
            yield return new WaitForSeconds(speed0);
        }
        ready0 = true;
    }

    private IEnumerator AutoClick1()
    {
        while (members[1] != null)
        {
            spawner.ReduceHp(atk1);
            yield return new WaitForSeconds(speed1);
        }
        ready1 = true;
    }

    private IEnumerator AutoClick2()
    {
        while (members[2] != null)
        {
            spawner.ReduceHp(atk2);
            yield return new WaitForSeconds(speed2);
        }
        ready2 = true;
    }

}
