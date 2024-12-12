using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEditor.PackageManager;

public class IncreaseClickDamage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameManager manager;

    public TextMeshProUGUI priceText;

    [SerializeField]
    private int _price, _power;
    [SerializeField]
    private TextMeshProUGUI _infos, _noMoney;
    // Start is called before the first frame update
    void Start()
    {
        _price = 15;
        _power = 1;
        _infos.enabled = false;
        _noMoney.enabled = false;
        _infos.text = "Achetez un Bracelet Macho pour augmenter de " + _power + " la puissance de votre clic (puissance actuelle : " + manager.clickDamage + ")";
    }

    // Update is called once per frame
    void Update()
    {
        priceText.text = _price.ToString() + " $";
        Debug.Log(_infos.text);
    }

    public void Purchase()
    {
        if (manager.pokedollars >= _price)
        {
            manager.pokedollars -= _price;
            manager.clickDamage += _power;
            _power++;
            _price *= 2;
            _infos.text = "Achetez un Bracelet Macho pour augmenter de " + _power + " la puissance de votre clic (puissance actuelle : " + manager.clickDamage + ")";
        }
        else 
        {
            StartCoroutine(NoMoneyMessage());
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("oui");
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
