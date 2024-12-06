using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Team : MonoBehaviour
{
    public Spawner spawner;
    public PokemonSE[] members = new PokemonSE[3];

    [SerializeField]
    private Image _pokemon0Sprite;
    [SerializeField]
    private Image _pokemon1Sprite;
    [SerializeField]
    private Image _pokemon2Sprite;
    // Start is called before the first frame update
    void Start()
    {
        if (members[0] != null)
        {
            _pokemon0Sprite.sprite = members[0].sprite;
            StartCoroutine(AutoClick0());
        }

        if (members[1] != null)
        {
            _pokemon1Sprite.sprite = members[1].sprite;
            StartCoroutine(AutoClick1());
        }

        if (members[2] != null)
        {
            _pokemon2Sprite.sprite = members[2].sprite;
            StartCoroutine(AutoClick2());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator AutoClick0()
    {
        while (members[0]!=null)
        {
            spawner.ReduceHp(members[0].atq);
            yield return new WaitForSeconds(members[0].cooldown);
        }
        yield break;
    }

    private IEnumerator AutoClick1()
    {
        while (true)
        {
            spawner.ReduceHp(members[1].atq);
            yield return new WaitForSeconds(members[1].cooldown);
        }

    }

    private IEnumerator AutoClick2()
    {
        while (true)
        {
            spawner.ReduceHp(members[2].atq);
            yield return new WaitForSeconds(members[2].cooldown);
        }
    }
}
