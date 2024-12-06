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
        StartCoroutine(AutoClick1());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator AutoClick1()
    {
        while (true)
        {
            Debug.Log(members[0].atq);
            spawner.ReduceHp(10);
            yield return new WaitForSeconds(2);
        }
    }

    private IEnumerator AutoClick2()
    {
        yield return new WaitForSeconds(members[2].cooldown);
    }

    private IEnumerator AutoClick3()
    {
        yield return new WaitForSeconds(members[3].cooldown);
    }
}
