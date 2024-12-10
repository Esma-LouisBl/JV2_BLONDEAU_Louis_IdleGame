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
            spawner.ReduceHp(members[0].atq);
            yield return new WaitForSeconds(members[0].cooldown);
        }
        ready0 = true;
    }

    private IEnumerator AutoClick1()
    {
        while (members[1] != null)
        {
            spawner.ReduceHp(members[1].atq);
            yield return new WaitForSeconds(members[1].cooldown);
        }
        ready1 = true;
    }

    private IEnumerator AutoClick2()
    {
        while (members[2] != null)
        {
            spawner.ReduceHp(members[2].atq);
            yield return new WaitForSeconds(members[2].cooldown);
        }
        ready2 = true;
    }

}
