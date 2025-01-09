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
    public int price;

    [SerializeField]
    public float power;
    [SerializeField]
    private TextMeshProUGUI _infos, _noMoney;
    // Start is called before the first frame update
    void Start()
    {
        price = 250;
        power = 0.1f;
        _infos.enabled = false;
        _noMoney.enabled = false;
        _infos.text = "Achetez un Mouchoir Choix pour diminuer de " + power + " le cooldown de tous vos Pok�mon.";
    }

    // Update is called once per frame
    void Update()
    {
        priceText.text = price.ToString() + " $";
        _infos.text = "Achetez un Mouchoir Choix pour diminuer de " + power + " le cooldown de tous vos Pok�mon.";
    }

    public void Purchase()
    {
        if (manager.pokedollars >= price)
        {
            manager.pokedollars -= price;
            power = Mathf.Round(power * 10.0f) * 0.1f;
            if (team.speed0 - power > 0)
            { 
                team.speed0 -= power;
                team.speed0 = Mathf.Round(team.speed0 * 10.0f) * 0.1f;
            }
            else
            {
                team.speed0 = 0.1f;
            }
            if (team.speed1 - power > 0)
            {
                team.speed1 -= power;
                team.speed1 = Mathf.Round(team.speed1 * 10.0f) * 0.1f;
            }
            else
            {
                team.speed1 = 0.1f;
            }
            if (team.speed2 - power > 0)
            {
                team.speed2 -= power;
                team.speed2 = Mathf.Round(team.speed2 * 10.0f) * 0.1f;
            }
            else
            {
                team.speed2 = 0.1f;
            }
            price *= 2;
            _infos.text = "Achetez un Mouchoir Choix pour diminuer de " + power + " le cooldown de tous vos Pok�mon.";

            power += 0.1f;
            power = Mathf.Round(power * 10.0f) * 0.1f;
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
