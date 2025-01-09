using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class AmuletCoin : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameManager manager;

    public TextMeshProUGUI priceText;

    [SerializeField]
    public int price;

    [SerializeField]
    public float power;

    [SerializeField]
    private TextMeshProUGUI _infos, _noMoney;
    // Start is called before the first frame update
    void Start()
    {
        price = 2000;
        power = 1.1f;
        _infos.enabled = false;
        _noMoney.enabled = false;
        _infos.text = "Achetez une Piece Rune pour multiplier vos gains d'argent par " + power + " (multiplicateur actuel : " + (power-0.1f) + ")";
    }

    // Update is called once per frame
    void Update()
    {
        priceText.text = price.ToString() + " $";
        _infos.text = "Achetez une Piece Rune pour multiplier vos gains d'argent par " + power + " (multiplicateur actuel : " + (power - 0.1f) + ")";
    }

    public void Purchase()
    {
        if (manager.pokedollars >= price)
        {
            manager.pokedollars -= price;
            power += 0.1f;
            price = Mathf.RoundToInt(price * 1.5f);
            _infos.text = "Achetez une Piece Rune pour multiplier vos gains d'argent par " + power + " (multiplicateur actuel : " + (power - 0.1f) + ")";
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
