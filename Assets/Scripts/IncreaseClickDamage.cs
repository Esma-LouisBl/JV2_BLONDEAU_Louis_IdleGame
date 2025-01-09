using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class IncreaseClickDamage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameManager manager;

    public TextMeshProUGUI priceText;

    [SerializeField]
    public int price, power;
    [SerializeField]
    private TextMeshProUGUI _infos, _noMoney;
    // Start is called before the first frame update
    void Start()
    {
        price = 15;
        power = 1;
        _infos.enabled = false;
        _noMoney.enabled = false;
        _infos.text = "Achetez un Bracelet Macho pour augmenter de " + power + " la puissance de votre clic (puissance actuelle : " + manager.clickDamage + ")";
    }

    // Update is called once per frame
    void Update()
    {
        priceText.text = price.ToString() + " $";
        _infos.text = "Achetez un Bracelet Macho pour augmenter de " + power + " la puissance de votre clic (puissance actuelle : " + manager.clickDamage + ")";
    }

    public void Purchase()
    {
        if (manager.pokedollars >= price)
        {
            manager.pokedollars -= price;
            manager.clickDamage += power;
            power++;
            price *= 2;
            _infos.text = "Achetez un Bracelet Macho pour augmenter de " + power + " la puissance de votre clic (puissance actuelle : " + manager.clickDamage + ")";
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
