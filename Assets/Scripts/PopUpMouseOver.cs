using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class PopUpMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Team team;

    [SerializeField]
    private TextMeshProUGUI _infos;
    // Start is called before the first frame update
    void Start()
    {
        _infos.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        _infos.text = "Attaque : " + team.members[0].atq.ToString() + "\nCooldown : " + team.members[0].cooldown.ToString();
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
