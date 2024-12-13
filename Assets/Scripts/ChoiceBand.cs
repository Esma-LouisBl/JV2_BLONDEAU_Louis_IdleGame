using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEditor.PackageManager;

public class ChoiceBand : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameManager manager;
    public Team team;

    public TextMeshProUGUI priceText;

    [SerializeField]
    private int _price, _power;
    [SerializeField]
    private TextMeshProUGUI _infos, _noMoney;
    // Start is called before the first frame update
    void Start()
    {
        _price = 250;
        _power = 3;
        _infos.enabled = false;
        _noMoney.enabled = false;
        _infos.text = "Achetez un Bandeau Choix pour augmenter de " + _power + " les dégâts de tous vos Pokémon.";
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
            team.atk0 += _power;
            team.atk1 += _power;
            team.atk2 += _power;
            _power *= 2;
            _price *= 2;
            _infos.text = "Achetez un Bandeau Choix pour augmenter de " + _power + " les dégâts de tous vos Pokémon.";
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
