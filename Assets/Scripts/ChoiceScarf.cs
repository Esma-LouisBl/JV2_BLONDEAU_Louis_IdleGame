using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEditor.PackageManager;

public class ChoiceScarf : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameManager manager;
    public Team team;

    public TextMeshProUGUI priceText;

    [SerializeField]
    private int _price;

    [SerializeField]
    private float _power;
    [SerializeField]
    private TextMeshProUGUI _infos, _noMoney;
    // Start is called before the first frame update
    void Start()
    {
        _price = 250;
        _power = 0.2f;
        _infos.enabled = false;
        _noMoney.enabled = false;
        _infos.text = "Achetez un Mouchoir Choix pour diminuer de " + _power + " le cooldown de tous vos Pokémon.";
    }

    // Update is called once per frame
    void Update()
    {
        priceText.text = _price.ToString() + " $";
    }

    public void Purchase()
    {
        if (manager.pokedollars >= _price)
        {
            manager.pokedollars -= _price;
            if (team.speed0 - _power > 0)
            { 
                team.speed0 -= _power; 
            }
            else
            {
                team.speed0 = 0.1f;
            }
            if (team.speed1 - _power > 0)
            {
                team.speed1 -= _power;
            }
            else
            {
                team.speed1 = 0.1f;
            }
            if (team.speed2 - _power > 0)
            {
                team.speed2 -= _power;
            }
            else
            {
                team.speed2 = 0.1f;
            }
            _price *= 2;
            _infos.text = "Achetez un Mouchoir Choix pour diminuer de " + _power + " le cooldown de tous vos Pokémon.";
        }
        else 
        {
            StartCoroutine(NoMoneyMessage());
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
    private IEnumerator NoMoneyMessage()
    {
        _noMoney.enabled = true;
        yield return new WaitForSeconds(2);
        _noMoney.enabled = false;
    }
}
