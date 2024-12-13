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
    private TextMeshProUGUI _error;

    private int _chance;
    private float _realCatchRate;
    // Start is called before the first frame update
    void Start()
    {
        _error.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        ballsNumber.text = manager.pokeballs.ToString();
    }

    public void ThrowBall()
    {
        if (team.members[2] != null)
        {
            StartCoroutine(ErrorMessage());
        }

        else {
            if (manager.pokeballs > 0)
            {
                manager.pokeballs--;
                team.ready0 = false;
                team.ready1 = false;
                team.ready2 = false;
                _chance = Random.Range(1, 101);
                float pourcent = (float)spawner.currentHp / (float)spawner.maxHp;
                _realCatchRate = spawner.currentPokemon.catchRate*(2-pourcent);
                Debug.Log(_realCatchRate);
                if (_chance <= _realCatchRate)
                {
                    if (team.members[0] == null)
                    {
                        team.members[0] = spawner.currentPokemon;
                        spawner.catched = true;
                    }
                    else if (team.members[1] == null)
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

    private IEnumerator ErrorMessage()
    {
        _error.enabled = true;
        yield return new WaitForSeconds(2);
        _error.enabled = false;
    }
}
