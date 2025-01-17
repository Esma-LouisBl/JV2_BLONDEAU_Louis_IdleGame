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

    [SerializeField]
    private TextMeshProUGUI _error, _failed;

    private int _chance;
    private float _realCatchRate;
    // Start is called before the first frame update
    void Start()
    {
        _error.enabled = false;
        _failed.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        ballsNumber.text = manager.pokeballs.ToString();
    }

    public void ThrowBall()
    {
        if (team.members[2] != null && team.members[1] != null && team.members[0] != null)
        {
            StartCoroutine(ErrorMessage());
        }

        else {
            if (manager.pokeballs > 0)
            {
                manager.pokeballs--;
                _chance = Random.Range(1, 101);
                float pourcent = (float)spawner.currentHp / (float)spawner.maxHp;
                _realCatchRate = spawner.currentPokemon.catchRate*(2-pourcent);
                if (_chance <= _realCatchRate)
                {
                    if (team.members[0] == null)
                    {
                        team.members[0] = spawner.currentPokemon;
                        team.speed0 = spawner.currentPokemon.cooldown;
                        team.atk0 = spawner.currentPokemon.atq;
                        spawner.catched = true;
                    }
                    else if (team.members[1] == null)
                    {
                        team.members[1] = spawner.currentPokemon;
                        team.speed1 = spawner.currentPokemon.cooldown;
                        team.atk1 = spawner.currentPokemon.atq;
                        spawner.catched = true;
                    }
                    else if (team.members[2] == null)
                    {
                        team.members[2] = spawner.currentPokemon;
                        team.speed2 = spawner.currentPokemon.cooldown;
                        team.atk2 = spawner.currentPokemon.atq;
                        spawner.catched = true;
                    }
                }
                else
                {
                    StartCoroutine(Failed());
                }
            }
        }
    }

    private IEnumerator ErrorMessage()
    {
        _error.enabled = true;
        yield return new WaitForSeconds(2);
        _error.enabled = false;
    }

    private IEnumerator Failed()
    {
        _failed.enabled = true;
        yield return new WaitForSeconds(2);
        _failed.enabled = false;
    }
}
