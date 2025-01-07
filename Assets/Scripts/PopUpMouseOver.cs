using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class PopUpMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Team team;

    [SerializeField]
    private TextMeshProUGUI _infos;

    public int place;
    // Start is called before the first frame update
    void Start()
    {
        _infos.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (team.members[0] != null)
        {
            if (place == 0)
            {
                if (team.members[0].type2 != PokemonType.None)
                {
                    _infos.text = team.members[0].pokemonName + "\n" + team.members[0].type1 + " " + team.members[0].type2 + "\nAttaque : " + team.atk0.ToString() + "\nCooldown : " + team.speed0.ToString();
                }
                else
                {
                    _infos.text = team.members[0].pokemonName + "\n" + team.members[0].type1 + "\nAttaque : " + team.atk0.ToString() + "\nCooldown : " + team.speed0.ToString();
                }

            }
        }

        if (team.members[1] != null)
        {
            if (place == 1)
            {
                if (team.members[1].type2 != PokemonType.None)
                {
                    _infos.text = team.members[1].pokemonName + "\n" + team.members[1].type1 + " " + team.members[1].type2 + "\nAttaque : " + team.atk1.ToString() + "\nCooldown : " + team.speed1.ToString();
                }
                else
                {
                    _infos.text = team.members[1].pokemonName + "\n" + team.members[1].type1 + "\nAttaque : " + team.atk1.ToString() + "\nCooldown : " + team.speed1.ToString();
                }

            }
        }

        if (team.members[2] != null)
        {
            if (place == 2)
            {
                if (team.members[2].type2 != PokemonType.None)
                {
                    _infos.text = team.members[2].pokemonName + "\n" + team.members[2].type1 + " " + team.members[2].type2 + "\nAttaque : " + team.atk2.ToString() + "\nCooldown : " + team.speed2.ToString();
                }
                else
                {
                    _infos.text = team.members[2].pokemonName + "\n" + team.members[2].type1 + "\nAttaque : " + team.atk2.ToString() + "\nCooldown : " + team.speed2.ToString();
                }

            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //new System.NotImplementedException();
        _infos.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //new System.NotImplementedException();
        _infos.enabled = false;
    }
}
