using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HelpButtonClose : MonoBehaviour
{
    [SerializeField]
    private Image _frame;
    [SerializeField]
    private TextMeshProUGUI _text;
    [SerializeField]
    private Button _close;


    // Update is called once per frame
    void Update()
    {

    }

    public void Close()
    {
        _frame.enabled = false;
        _text.enabled = false;
        _close.enabled = false;
        _close.image.enabled = false;
    }
}
