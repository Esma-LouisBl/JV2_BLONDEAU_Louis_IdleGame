using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ChoiceBand : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameManager manager;
    public Team team;

    public TextMeshProUGUI priceText;

    [SerializeField]
    public int price, power;
    [SerializeField]
    private TextMeshProUGUI _infos, _noMoney;
    // Start is called before the first frame update
    void Start()
    {
        price = 250;
        power = 3;
        _infos.enabled = false;
        _noMoney.enabled = false;
        _infos.text = "Achetez un Bandeau Choix pour augmenter de " + power + " les dégâts de tous vos Pokémon.";
    }

    // Update is called once per frame
    void Update()
    {
        priceText.text = price.ToString() + " $";
        _infos.text = "Achetez un Bandeau Choix pour augmenter de " + power + " les dégâts de tous vos Pokémon.";
    }

    public void Purchase()
    {
        if (manager.pokedollars >= price)
        {
            manager.pokedollars -= price;
            team.atk0 += power;
            team.atk1 += power;
            team.atk2 += power;
            power *= 2;
            price *= 2;
            _infos.text = "Achetez un Bandeau Choix pour augmenter de " + power + " les dégâts de tous vos Pokémon.";
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
