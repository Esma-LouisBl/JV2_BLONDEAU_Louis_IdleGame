using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrintMoney : MonoBehaviour
{
    public GameManager manager;
    [SerializeField]
    private TextMeshProUGUI money;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        money.text = manager.pokedollars.ToString() + " $";
    }
}
