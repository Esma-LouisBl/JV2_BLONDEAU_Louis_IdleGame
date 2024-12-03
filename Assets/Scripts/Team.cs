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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator AutoClick1()
    {
        spawner.ReduceHp(members[0].atq);
        yield return new WaitForSeconds(members[0].cooldown);
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
