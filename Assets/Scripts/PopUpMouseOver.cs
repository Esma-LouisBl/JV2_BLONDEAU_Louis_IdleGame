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
        if (team.members[place] != null)
        {
            if (team.members[place].type2 != PokemonType.None)
            {
                _infos.text = team.members[place].pokemonName + "\n" + team.members[place].type1 + " " + team.members[place].type2 + "\nAttaque : " + team.atks[place].ToString() + "\nCooldown : " + team.speeds[place].ToString();
            }
            else
            {
                _infos.text = team.members[place].pokemonName + "\n" + team.members[place].type1 + "\nAttaque : " + team.atks[place].ToString() + "\nCooldown : " + team.speeds[place].ToString();
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
