using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Catch : MonoBehaviour
{
    public Spawner spawner;
    public GameManager manager;
    public Team team;
    public TextMeshProUGUI ballsNumber;

    private int _chance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ballsNumber.text = manager.pokeballs.ToString();
    }

    public void ThrowBall()
    {
        if (manager.pokeballs > 0)
        { 
            manager.pokeballs--;
            team.ready0 = false;
            team.ready1 = false;
            team.ready2 = false;
            _chance = Random.Range(1, 101);
            Debug.Log(_chance);
            if (_chance <= spawner.currentPokemon.catchRate)
            {
                if (team.members[1] == null)
                {
                    team.members[1] = spawner.currentPokemon;
                    spawner.catched = true;
                }
                else if (team.members[2] == null)
                {
                    team.members[2] = spawner.currentPokemon;
                    spawner.catched = true;
                }
            }
            team.ready0 = true;
            team.ready1 = true;
            team.ready2 = true;
        }
    }
}
