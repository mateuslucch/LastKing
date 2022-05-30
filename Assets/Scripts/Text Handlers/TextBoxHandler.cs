using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextBoxHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textBox;
    [SerializeField] GameObject textBoxBack;

    private void Start()
    {
        TurnOffTextBox();
    }
    
    public void SetWarningText(string warningText)
    {
        textBox.text = warningText;
    }

    public void TurnOnTextBox()
    {
        textBox.enabled = true;
        textBoxBack.SetActive(true);
    }

    public void TurnOffTextBox()
    {
        textBox.enabled = false;
        textBoxBack.SetActive(false);
    }

}
