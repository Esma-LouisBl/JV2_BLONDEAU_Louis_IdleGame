using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;

public class IncreaseClickDamage : MonoBehaviour
{

    public GameManager manager;

    public TextMeshProUGUI priceText, powerText;

    [SerializeField]
    private int _price, _power;
    // Start is called before the first frame update
    void Start()
    {
        _price = 15;
        _power = 1;
    }

    // Update is called once per frame
    void Update()
    {
        priceText.text = _price.ToString() + " $";
        powerText.text = _power.ToString();
    }

    public void Purchase()
    {
        if (manager.pokedollars >= _price) 
        { 
            manager.pokedollars -= _price;
            manager.clickDamage += _power;
            _power ++;
            _price *= 2;
        }
    }
}
