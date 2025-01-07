using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HelpButton : MonoBehaviour
{
    [SerializeField]
    private Image _frame;
    [SerializeField]
    private TextMeshProUGUI _text;
    [SerializeField]
    private Button _close;

    // Start is called before the first frame update
    void Start()
    {
        _frame.enabled = false;
        _text.enabled = false;
        _close.enabled = false;
        _close.image.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        _frame.enabled = true;
        _text.enabled = true;
        _close.enabled = true;
        _close.image.enabled = true;
    }
}
