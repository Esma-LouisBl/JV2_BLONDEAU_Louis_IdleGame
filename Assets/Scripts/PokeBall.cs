using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class PokeBall : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameManager manager;

    public TextMeshProUGUI priceText;

    [SerializeField]
    private int _price;
    [SerializeField]
    private TextMeshProUGUI _infos, _noMoney;
    // Start is called before the first frame update
    void Start()
    {
        _price = 20;
        _infos.enabled = false;
        _noMoney.enabled = false;
        _infos.text = "Les Poke Balls permettent de capturer des Pokemon.";
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
            manager.pokeballs ++;
            _infos.text = "Les Poke Balls permettent de capturer des Pokemon.";
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
