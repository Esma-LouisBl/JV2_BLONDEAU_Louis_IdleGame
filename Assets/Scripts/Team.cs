using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{
    public Spawner spawner;
    public PokemonSE[] members = new PokemonSE[3];
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(members[0]);
        if (members[0] != null)
        {
            StartCoroutine(AutoClick0());
        }

        if (members[1] != null)
        {
            StartCoroutine(AutoClick1());
        }

        if (members[2] != null)
        {
            StartCoroutine(AutoClick2());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator AutoClick0()
    {
        while (true)
        {
            spawner.ReduceHp(10);
            yield return new WaitForSeconds(2);
        }
    }

    private IEnumerator AutoClick1()
    {
        yield return new WaitForSeconds(members[2].cooldown);
    }

    private IEnumerator AutoClick2()
    {
        yield return new WaitForSeconds(members[3].cooldown);
    }
}
