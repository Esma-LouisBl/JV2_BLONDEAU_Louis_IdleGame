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
