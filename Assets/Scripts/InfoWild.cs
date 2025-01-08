using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class InfoWild : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private TextMeshProUGUI _infos;

    public Spawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        _infos.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        _infos.text = "Attaque : " + spawner.currentPokemon.atq + "\nCooldown : " + spawner.currentPokemon.cooldown;
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
